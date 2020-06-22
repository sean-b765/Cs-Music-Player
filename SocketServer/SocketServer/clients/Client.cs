using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.clients
{
    abstract class Client
    {
        protected string user;
        protected byte[] salt;
        protected byte[] hash;
        protected bool loggedIn;

        public string User { get => user; set => user = value; }
        public byte[] Salt { get => salt; set => salt = value; }
        public byte[] Hash { get => hash; set => hash = value; }
        public bool LoggedIn { get => loggedIn; set => loggedIn = value; }


        public abstract bool Matches(string user, string pass);
    }
}
