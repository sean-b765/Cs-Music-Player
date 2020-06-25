using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Playlist.cs - contains the SortedSet<> binary tree which stores Media objects,
 *                  and relevant methods
 * Author: Sean Boaden | 30010353
 */

namespace SocketClient.player
{
    [Serializable]
    class Playlist
    {
        // C# SortedSet<> is MSDN's implementation of red-black tree (self-balancing BST)
        SortedSet<Media> list = new SortedSet<Media>();
        int id;
        string name;

        // Default constructor
        public Playlist(string name, int id)
        {
            Name = name;
            Id = id;
        }

        // returns media at index
        //  useful when iterating through BST
        public Media MediaAt(int index)
        {
            return list.ElementAt(index);
        }

        // add obj array
        public void AddAll(Media[] mediaArr)
        {
            for (int i = 0; i < mediaArr.Length; i++)
            {
                list.Add(mediaArr[i]);
            }
        }

        // add single obj
        public void Add(Media media) {
            List.Add(media);
        }

        // remove the media
        public void Remove(Media media)
        {
            list.Remove(media);
        }

        // ToString() method
        public override string ToString()
        {
            return Name;
        }

        // Encapsulation
        public SortedSet<Media> List { get => list; set => list = value; }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
    }
}
