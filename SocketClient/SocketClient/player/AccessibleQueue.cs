using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * AccessibleQueue - uses a List to perform Queue-like operations
 */

namespace SocketClient.player
{
    class AccessibleQueue
    {

        private List<Media> queue = new List<Media>();

        public List<Media> Queue { get => queue; set => queue = value; }


        // removes and returns item from top of queue
        public Media Pop()
        {
            Media rtn = null;
            rtn = Queue.ElementAt(0);
            Queue.RemoveAt(0);
            return rtn;
        }

        // will add on to end of list
        public void Enqueue(Media media)
        {
            Queue.Add(media);
        }

        // will find the occurence of the object in the queue,
        //  and remove it
        public void Dequeue(Media media)
        {
            Queue.Remove(media);
        }

        public bool Contains(Media media)
        {
            if (Queue.Contains(media))
                return true;
            else
                return false;
        }

        public List<Media> Get()
        {
            return Queue;
        }
    }
}
