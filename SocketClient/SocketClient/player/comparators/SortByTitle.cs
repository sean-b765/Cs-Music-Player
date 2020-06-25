using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * SortByTitle.cs - custom Title comparer
 * Author: Sean Boaden | 30010353
 */

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
