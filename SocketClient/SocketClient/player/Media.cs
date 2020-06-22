using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Media.cs - the media files imported by user (mp3, mp4, etc.)
 * 30010353
 */

namespace SocketClient.player
{
    [Serializable]
    class Media : IComparable
    {
        // Not serialized
        static int count = 0;

        // Serialized
        private int    id;
        private string url;
        private string title;
        private string artist;
        private double duration;
        private bool   playing;

        // Default constructor
        public Media(string url)
        {
            Url = url;
            Id = count;
            count++;
        }

        // Overloaded constructor
        public Media(string url, string title, string artist, double duration)
        {
            Url = url;
            Title = title;
            Artist = artist;
            Duration = duration;
            Id = count;
            count++;
        }

        // Encapsulation
        public int Id { get => id; set => id = value; }
        public string Url { get => url; set => url = value; }
        public string Title { get => title; set => title = value; }
        public string Artist { get => artist; set => artist = value; }
        public double Duration { get => duration; set => duration = value; }
        public bool Playing { get => playing; set => playing = value; }


        // Return duration (total seconds) as a readable minutes / seconds string
        public string DurationStr()
        {
            int m = (int) (Duration / 60);
            int s = (int) (Duration - (m * 60));
            return m + "m " + s + "s";
        }

        // IComparable method
        public int CompareTo(object obj)
        {
            return this.Title.CompareTo(((Media)obj).Title);
        }

        // Override ToString() to return song info
        public override string ToString()
        {
            return Title + " - " + DurationStr();
        }
    }
}
