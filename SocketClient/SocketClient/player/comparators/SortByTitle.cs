﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient.player.comparators
{
    class SortByTitle : IComparer<Media>
    {
        public int Compare(Media x, Media y)
        {
            return (x.Title.CompareTo(y.Title));
        }
    }
}
