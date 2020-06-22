using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * ProgramState.cs
 *  contains all data to serialize, in one object
 */

namespace SocketClient.player
{
    [Serializable]
    class ProgramState
    {
        // Variables which need to be saved for client
        List<Playlist> library = new List<Playlist>();
        Playlist selectedPlaylist = null;
        Media currentlyPlaying;

        public ProgramState(List<Playlist> library, Playlist selected, Media currentMedia)
        {
            Library = library;
            SelectedPlaylist = selected;
            CurrentlyPlaying = currentMedia;
        }

        // Encapsulation
        public List<Playlist> Library { get => library; set => library = value; }
        public Playlist SelectedPlaylist { get => selectedPlaylist; set => selectedPlaylist = value; }
        public Media CurrentlyPlaying { get => currentlyPlaying; set => currentlyPlaying = value; }
    }
}
