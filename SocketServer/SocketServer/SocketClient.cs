using SocketServer.clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

/*
 * Programming III
 * AT3 Project
 * by Sean Boaden | 30010353
 * 
 * SocketClient.cs
 */

namespace SocketServer
{
    class SocketClient
    {
        Socket clientSocket;
        Client client;

        Server server;

        Server.MessageReceivedHandler messageReceived;
        Server.ClientDisconnectedHandler clientDisconnected;
        Server.ClientConnectedHandler clientConnected;
        Server.UpdateUIHandler updateUI;

        // Default Constructor
        //  must pass events from Server.cs when a client connects.
        public SocketClient(Socket clientSocket, Server server, Server.MessageReceivedHandler messageReceived, 
            Server.ClientDisconnectedHandler clientDisconnected, Server.ClientConnectedHandler clientConnected,
            Server.UpdateUIHandler updateUI)
        {
            // set delegates
            this.clientSocket = clientSocket;
            this.clientConnected = clientConnected;
            this.messageReceived = messageReceived;
            this.clientDisconnected = clientDisconnected;
            this.updateUI = updateUI;

            this.client = ClientFactory.NewGuest("Unnamed Client", "");

            this.server = server;

            // notify other threads that client has connected...
            if (clientConnected != null)
                clientConnected();
        }

        // Read input from Client-side
        public void Read()
        {
            byte[] buffer   = new byte[8196];
            string data     = null;

            while (true)
            {
                try
                {
                    int numBytes = clientSocket.Receive(buffer);
                    data = ASCIIEncoding.ASCII.GetString(buffer, 0, numBytes);

                    if (data.IndexOf("<EOF>") > -1)
                        break;

                    // trigger message received event
                    if (messageReceived != null)
                    {
                        if (data.StartsWith("[LOGIN_REQUEST]"))
                        {
                            string content = data.Replace("[LOGIN_REQUEST]", "");
                            string[] user_pass = content.Split(',');
                            // attempt login with the user,pass string
                            AttemptLogin(user_pass);
                        }
                        // trigger server message received from client
                        messageReceived(data);
                    }
                } catch (Exception)
                {
                    break;
                }
            } // end of Client connection

            // trigger client disconnected event
            if (clientDisconnected != null && client != null)
                clientDisconnected(client);

        }

        private void AttemptLogin(string[] user_pass)
        {
            string user = user_pass[0];
            string pass = user_pass[1];

            foreach (Client c in server.GetClients())
            {
                if (c.User == user)
                {
                    // use hashing techniques in Matches() function to validate user
                    if (c.Matches(user, pass))
                    {
                        clientSocket.Send(ASCIIEncoding.ASCII.GetBytes("[@" + user + "] You have successfully logged in."));
                        // we have logged in, set the proper client object
                        //  and notify UI update
                        this.client = c;
                        client.LoggedIn = true;
                        if (updateUI != null)
                            updateUI();
                    } else
                    {
                        // incorrect password
                        clientSocket.Send(ASCIIEncoding.ASCII.GetBytes("[@" + user + "] Incorrect login."));
                    }
                } else
                {
                    // incorrect username
                    clientSocket.Send(ASCIIEncoding.ASCII.GetBytes("[@" + user + "] Incorrect login."));
                }
            }
        }
    }
}
