using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * SortByArtist.cs - custom Artist field comparer
 * 30010353
 */

namespace SocketClient.player.comparators
{
    class SortByArtist : IComparer<Media>
    {
        public int Compare(Media x, Media y)
        {
            return (x.Artist.CompareTo(y.Artist));
        }
    }
}
