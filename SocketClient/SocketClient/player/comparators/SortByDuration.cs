﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * SortByDuration.cs - custom Duration comparer
 * Author: Sean Boaden | 30010353
 */

namespace SocketClient.player.comparators
{
    class SortByDuration : IComparer<Media>
    {
        public int Compare(Media x, Media y)
        {
            return (int) (x.Duration - y.Duration);
        }
    }
}
