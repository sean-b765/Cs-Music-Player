﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * ProgramState.cs
 *  contains all data to serialize on Player close, in one object
 * Author: Sean Boaden | 30010353
 */

namespace SocketClient.player
{
    [Serializable]
    class ProgramState
    {
        // Variables which need to be saved for client
        List<Playlist> library = new List<Playlist>();
        Playlist selectedPlaylist = null;

        // Default Constructor
        public ProgramState(List<Playlist> library, Playlist selected)
        {
            Library = library;
            SelectedPlaylist = selected;
        }

        // Encapsulation
        public List<Playlist> Library { get => library; set => library = value; }
        public Playlist SelectedPlaylist { get => selectedPlaylist; set => selectedPlaylist = value; }
    }
}
