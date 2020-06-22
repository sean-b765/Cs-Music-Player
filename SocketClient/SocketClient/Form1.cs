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

namespace SocketClient
{
    public partial class Form1 : Form
    {
        Socket socket = null;

        public delegate void MessageReceivedHandler(string message);
        public event MessageReceivedHandler MessageReceived;

        Thread readThread = null;

        string user = "", pass = "";
        bool isLoggedIn = false;

        public Form1()
        {
            InitializeComponent();
            MessageReceived += Form1_MessageReceived;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            ShowControls();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (socket.Connected)
                {
                    // disconnect
                    socket.Close();
                    loginPanel.Visible = false;
                    isLoggedIn = false;
                    ShowControls();
                }
                else
                {
                    Connect();
                }
            } catch (NullReferenceException)
            {
                // the socket was not initialised (first-time connecting)
                //  so connect
                Connect();
            }
        }

        void Connect()
        {
            IPAddress ip = IPAddress.Parse(TxtHost.Text);

            if (int.TryParse(TxtPort.Text, out int port))
            {
                IPEndPoint localEndPoint = new IPEndPoint(ip, port);

                // connect the socket to the IP address
                socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    socket.Connect(localEndPoint);
                    LblStatus.Text = "Connected to " + socket.RemoteEndPoint.ToString();

                    // show login stuff
                    loginPanel.Visible = true;
                    BtnConnect.Text = "Disconnect";

                    // start the Read() thread
                    readThread = new Thread(Read);
                    readThread.IsBackground = true;
                    readThread.Start();
                }
                catch (ArgumentNullException)
                {
                    LblStatus.Text = "Hostname null";
                }
                catch (ArgumentOutOfRangeException)
                {
                    LblStatus.Text = "Invalid port.";
                }
                catch (SocketException)
                {
                    LblStatus.Text = "Error when attempting to connect.";
                }
            }
            else
            {
                LblStatus.Text = "Invalid Port.";
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // send a login request
            if (TxtUser.Text.Length > 3 && TxtPass.Text.Length > 3)
            {
                socket.Send(ASCIIEncoding.ASCII.GetBytes("[LOGIN_REQUEST]" + TxtUser.Text + "," + TxtPass.Text));
                // set local user/pass variables
                user = TxtUser.Text;
                pass = TxtPass.Text;
                // clear the textboxes
                TxtPass.Clear();
                TxtUser.Clear();
            } else
            {
                LblStatus.Text = "Please enter a valid user/pass.";
            }
        }

        void ShowControls()
        {
            if (isLoggedIn)
            {
                panelControls.Visible = true;
            } else
            {
                panelControls.Visible = false;
            }
        }

        private void Form1_MessageReceived(string message)
        {
            Invoke(new Form1.MessageReceivedHandler(DisplayMessageReceived), message);
        }
        private void DisplayMessageReceived(string message)
        {
            if (message.StartsWith("[SERVER_CLOSED]"))
            {
                LblStatus.Text = "Server closed.";
                loginPanel.Visible = false;
                BtnConnect.Text = "Connect";
                socket.Close();
                readThread = null;
                isLoggedIn = false;
                ShowControls();
            } else if (message.StartsWith("[@" + user + "]"))
            {
                LblStatus.Text = message.Replace("[@" + user + "] ", "");
                if (message.Contains("You have successfully logged in."))
                {
                    isLoggedIn = true;
                    // we know for sure the user is logged in correctly
                    ShowControls();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var player = new player.Player();
            player.Show();
        }

        void Read()
        {
            byte[] buffer   = new byte[8196];
            string data     = null;
            while (true)
            {
                try
                {
                    int numBytes = socket.Receive(buffer);
                    data = ASCIIEncoding.ASCII.GetString(buffer, 0, numBytes);

                    if (data.IndexOf("<EOF>") > -1)
                        break;

                    if (MessageReceived != null)
                        MessageReceived(data);
                } catch (Exception)
                {
                    // there was an error receiving input from socket,
                    //  break while loop as the connection is most likely closed
                    break;
                }
            }
            // Alert UI thread that the server stopped responding,
            //  since the socket has closed
            if (MessageReceived != null)
                MessageReceived("[SERVER_CLOSED]");
        }
    }
}
