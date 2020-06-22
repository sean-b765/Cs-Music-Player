using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.clients
{
    class RegisteredClient : Client
    {
        // Usage:
        //  RegisteredClient.Matches(input, input);
        public override bool Matches(string user, string pass)
        {
            return ClientFactory.Matches(pass, salt, hash);
        }
    }
}
