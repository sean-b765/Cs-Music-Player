﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.clients
{
    class Guest : Client
    {
        public override bool Matches(string user, string pass)
        {
            return ClientFactory.Matches(pass, salt, hash);
        }
    }
}
