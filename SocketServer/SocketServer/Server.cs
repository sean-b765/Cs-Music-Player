using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocketServer.clients;

/*
 * Programming III
 * AT3 Project
 * by Sean Boaden | 30010353
 * 
 * Server.cs
 */

namespace SocketServer
{
    class Server
    {
        Socket socket;
        string host;
        int port;

        List<Client> connectedClients = new List<Client>();

        // Application events

        public delegate void MessageReceivedHandler(string message);
        public event MessageReceivedHandler MessageReceived;

        public delegate void ClientDisconnectedHandler(Client client);
        public event ClientDisconnectedHandler ClientDisconnected;

        public delegate void ClientConnectedHandler();
        public event ClientConnectedHandler ClientConnected;

        public delegate void UpdateUIHandler();
        public event UpdateUIHandler UpdateUI;

        // Default constructor
        public Server() { }

        // Overloaded constructor,
        //  will initialise the Socket with arguments, or
        //  throw an exception if unable to initialise.
        public Server(string host, int port)
        {
            this.host = host;
            this.port = port;

            if (Initialise())
            {
                // add a default admin account -> user: admin, pass: admin
                connectedClients.Add(ClientFactory.NewAdmin("admin", "admin"));
            }
            else
            {
                // throw an exception, to stop the server in Form1
                throw new SocketException();
            }
        }

        bool Initialise()
        {
            // parse localhost IP
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint localEndPoint = new IPEndPoint(ip, port);

            try
            {
                socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (SocketException se)
            {
                return false;
            }

            socket.Bind(localEndPoint);

            ClientDisconnected += Server_ClientDisconnected;
            ClientConnected += Server_ClientConnected;

            return true;
        }

        private void Server_ClientConnected()
        { }

        private void Server_ClientDisconnected(Client client)
        {
            if (connectedClients.Contains(client))
            {
                client.LoggedIn = false;
            }
        }

        public void Listen()
        {
            // Place socket in listening state,
            //  with maximum 10 pending connections
            socket.Listen(10);

            while (true)
            {
                Socket clientSocket = null;
                try
                {
                    clientSocket = socket.Accept();
                } catch (Exception)
                {
                    // if there was an error, 
                    //  skip thread initialisation 
                    continue;
                }

                // Start the client thread
                if (clientSocket != null)
                {
                    // Instantiate new user account to be associated with SocketClient
                    //connectedClients.Add

                    // Create SocketClient object and pass the delegate (method pointer),
                    //  to receive messages from client
                    SocketClient client = new SocketClient(clientSocket, this, MessageReceived, 
                        ClientDisconnected, ClientConnected, UpdateUI);

                    ThreadStart threadStart = new ThreadStart(client.Read);
                    Thread clientThread = new Thread(threadStart)
                    {
                        IsBackground = true
                    };
                    clientThread.Start();
                }
            }
        }

        public void AddClient(Client c)
        {
            // add a default admin record to the clients list
            connectedClients.Add(c);
        }

        public List<Client> GetClients()
        {
            return connectedClients;
        }
    }
}
