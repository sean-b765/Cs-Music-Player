using SocketServer.clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Programming III
 * AT3 Project
 * by Sean Boaden | 30010353
 * 
 * Form1.cs
 */

namespace SocketServer
{
    public partial class Form1 : Form
    {
        Server server = null;

        public Form1()
        {
            InitializeComponent();

            // create formClosed event to dispose the delegate method
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {  }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxtPort.Text, out int port))
            {
                try
                {
                    // Initialise server obj
                    server = new Server("127.0.0.1", port);

                    // Initialise thread to listen for clients
                    ThreadStart threadDelegate = new ThreadStart(server.Listen);
                    Thread thread = new Thread(threadDelegate)
                    {
                        IsBackground = true
                    };

                    // Start server thread
                    thread.Start();

                    LstLog.Items.Add("Server started on port: " + port);
                }
                catch (Exception)
                {
                    // The Server() constructor throws a SocketException if
                    //  failed to initialise socket
                    LstLog.Items.Add("Unable to start server.");
                }
                if (server != null)
                {
                    server.ClientConnected += Server_ClientConnected;
                    server.MessageReceived += Server_MessageReceived;
                    server.ClientDisconnected += Server_ClientDisconnected;
                    server.UpdateUI += Server_UpdateUI;
                }
            }
        }

        // update the UI with relevant things,
        //  connected clients mainly
        private void Server_UpdateUI()
        {
            Invoke(new Server.UpdateUIHandler(UpdateFormUI));
        }

        private void UpdateFormUI()
        {
            if (server.GetClients().Count > 0)
            {
                Clients.Items.Clear();
                foreach (Client c in server.GetClients())
                {
                    if (c.LoggedIn)
                        Clients.Items.Add(c.User);
                    else
                        Clients.Items.Add("[inactive] " + c.User);
                }
            }
        }

        // Client Connected
        private void Server_ClientConnected()
        {
            // Invoke local method to access Form Controls,
            //  otherwise will receive cross-thread error
            Invoke(new Server.ClientConnectedHandler(DisplayClientConnected));
        }
        private void DisplayClientConnected()
        {
            LstLog.Items.Add("+ Client connected");
        }

        // Client Disconnected
        private void Server_ClientDisconnected(Client client)
        {
            Invoke(new Server.ClientDisconnectedHandler(DisplayClientDisconnected), client);
        }
        private void DisplayClientDisconnected(Client client)
        {
            LstLog.Items.Add("- Client disconnected");
            UpdateFormUI();
        }

        // Message Received by Client
        private void Server_MessageReceived(string message)
        {
            Invoke(new Server.MessageReceivedHandler(DisplayMessageReceived), message);
        }
        private void DisplayMessageReceived(string message)
        {
            LstLog.Items.Add(message);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                server.MessageReceived -= Server_MessageReceived;
                server.ClientDisconnected -= Server_ClientDisconnected;
                server.ClientConnected -= Server_ClientConnected;
                server.UpdateUI -= Server_UpdateUI;
            }
            catch (Exception) { }
        }
    }
}
