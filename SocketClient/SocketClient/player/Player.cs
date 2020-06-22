using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using SocketClient.player.algorithms;
using SocketClient.player.comparators;
using CsvHelper;

/*
 * Player.cs - uses Windows Media Player (WMPLib) to play media files
 * 
 * 30010353
 */

namespace SocketClient.player
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }

        // CSVHelper writer
        CsvParser csvWriter = default;

        List<Playlist> library = new List<Playlist>();
        Playlist selectedPlaylist = null;

        // playlist will always contain items from selectedPlaylist.List
        //  but List can be sorted with merge sort, SortedSet is naturally sorted
        List<Media> playlist = new List<Media>();

        // our custom queue class
        AccessibleQueue queue = new AccessibleQueue();

        // song history
        Stack<Media> history = new Stack<Media>();

        // currentlyPlaying media object,
        //  will change on wmPlayer STOPPED event
        Media currentlyPlaying;

        // Merge Sort object
        MergeSort<Media> mergeSort = new MergeSort<Media>();

        bool repeat = false;

        private void Player_Load(object sender, EventArgs e)
        {
            TxtListItem.LostFocus += TxtListItem_LostFocus;
            TxtListItem.KeyDown += TxtListItem_KeyDown;
            // our listbox contains Playlist objects,
            //  set display and value member of listbox items
            LstLibrary.DisplayMember = "Name";
            LstLibrary.ValueMember = "Id";

            LstPlaylist.DataSource = playlist;

            // use Media Id field (int) as value
            LstPlaylist.ValueMember = "Id";
            LstPlaylist.DisplayMember = "Title";

            CmbSorting.SelectedIndex = 0;
        }

        // Adding Playlists
        private void BtnAddPlaylist_Click(object sender, EventArgs e)
        {
            ShowItemEditor(true);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            BtnAddPlaylist_Click(sender, e);
        }

        // Open filedialog to allow user to add multiple files to the playlist
        private void BtnAddMedia_Click(object sender, EventArgs e)
        {
            if (LstLibrary.SelectedIndex != -1)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] files = openFileDialog.FileNames;
                        foreach (string file in files)
                        {
                            // use IWMPMedia interface to extract media details
                            IWMPMedia iwmp = wmPlayer.newMedia(file);
                            // add the new Media object to playlist
                            selectedPlaylist.Add(new Media(file)
                            {
                                Title = iwmp.name,
                                Duration = iwmp.duration,
                                Artist = iwmp.getItemInfo("Author")
                            });
                        }
                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    // update playlist listbox
                    UpdatePlaylist();
                }
            }            
        }

        void PlayMedia(Media media)
        {
            currentlyPlaying = media;
            media.Playing = true;

            if (media.Artist == "")
                LblMedia.Text = media.Title;
            else
                LblMedia.Text = media.Title + " by " + media.Artist;

            wmPlayer.URL = media.Url;
            wmPlayer.Ctlcontrols.play();
        }

        void PlayNext()
        {
            if (LstPlaylist.SelectedIndex != -1)
            {
                currentlyPlaying.Playing = false;
                history.Push(currentlyPlaying);

                if (LstPlaylist.SelectedIndex + 1 != LstPlaylist.Items.Count)
                {
                    LstPlaylist.SelectedIndex++;
                    int mediaId = (int) LstPlaylist.SelectedValue;
                    Media m = GetMediaFromListBoxValue(mediaId);
                    PlayMedia(m);
                } else
                {
                    LstPlaylist.SelectedIndex = 0;
                    int mediaId = (int)LstPlaylist.SelectedValue;
                    Media m = GetMediaFromListBoxValue(mediaId);
                    PlayMedia(m);
                }

            }
        }

        // Update the playlist ListBox to show the media in the selectedPlaylist
        void UpdatePlaylist()
        {
            // a new playlist was selected, or songs added
            playlist.Clear();
            LstPlaylist.DataSource = null;
            // unbind the data source,
            //  alter the data source
            foreach (Media m in selectedPlaylist.List)
            {
                playlist.Add(m);
            }
            // sort the playlist if necessary
            if (mergeSort != null)
            {
                // Update mergeSort ascending/comparer fields
                UpdateSorter();
                if (mergeSort.Comparer != null)
                {
                    Media[] tmp = playlist.ToArray();
                    // sort
                    mergeSort.sort(tmp, mergeSort.Comparer, mergeSort.Ascending);
                    // add back into playlist List

                    playlist.Clear();
                    foreach (Media item in tmp)
                    {
                        playlist.Add(item);
                    }
                }
            }

            // and then rebind the data source
            LstPlaylist.DataSource = playlist;
        }

        // Exists function to check for an already existing playlist
        //  used to avoid duplicate playlists
        bool PlaylistNameExists(string pname)
        {
            if (library.Count == 0)
                return false;
            foreach (Playlist p in library)
            {
                // if name equals, return true
                if (p.Name == pname)
                    return true;
            }
            return false;
        }

        // Will show the ListItem editor textbox,
        //  will need to behave differently if a new playlist
        //  is being added, vs. an existing playlist being editted
        void ShowItemEditor(bool adding)
        {
            int index = 0;
            if (adding)
            {
                // here, we are adding new listbox item
                var newPlaylist = new Playlist("New Playlist " + library.Count, library.Count);
                library.Add(newPlaylist);
                // add playlist obj to library list, then add to ListBox
                LstLibrary.Items.Add(newPlaylist);
                // get the index of the item we just added
                index = LstLibrary.Items.IndexOf(newPlaylist);
                LstLibrary.SelectedIndex = index;
                TxtListItem.Text = ((Playlist)LstLibrary.SelectedItem).Name;
            } else
            {
                // in here, we are editing an existing Listbox item
                if (LstLibrary.SelectedIndex != -1)
                {
                    // find item manually
                    index = LstLibrary.SelectedIndex;
                    foreach (Playlist p in library)
                    {
                        if (p.Name == LstLibrary.Items[index].ToString())
                        {
                            TxtListItem.Text = p.Name;
                        }
                    }
                }
            }
            // positioning and showing the textbox to edit playlist name
            TxtListItem.Location = LstLibrary.Location;
            TxtListItem.Location = new Point(TxtListItem.Location.X, TxtListItem.Location.Y + (index * LstLibrary.ItemHeight));
            TxtListItem.Height = LstLibrary.ItemHeight;
            TxtListItem.Visible = true;
            TxtListItem.Width = LstLibrary.Width;
            TxtListItem.Focus();
            TxtListItem.Select(0, TxtListItem.Text.Length);
        }

        private void TxtListItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtListItem_LostFocus(sender, e);
            }
        }

        // When the ListItem edit textbox loses focus, 
        //  save changes to the selected listbox index
        private void TxtListItem_LostFocus(object sender, EventArgs e)
        {
            if (TxtListItem.Visible)
            {
                if (LstLibrary.SelectedIndex != -1)
                {
                    if (!PlaylistNameExists(TxtListItem.Text))
                    {
                        // we can go ahead and add/edit the playlist
                        Playlist selectedItem = null;
                        // get selected item as Playlist object
                        try
                        {
                            selectedItem = (Playlist)(LstLibrary.SelectedItem);
                        }
                        catch (Exception) { }

                        if (selectedItem != null)
                            selectedItem.Name = TxtListItem.Text;
                        else
                        {
                            // get item manually
                            int selectedIndex = LstLibrary.SelectedIndex;
                            foreach (Playlist p in library)
                            {
                                if (p.Name == LstLibrary.Items[selectedIndex].ToString())
                                {
                                    p.Name = TxtListItem.Text;
                                }
                            }
                        }
                    }
                    else
                    {
                        // cannot choose this name.
                        int index = LstLibrary.SelectedIndex;
                        foreach (Playlist p in library)
                        {
                            if (p.Name == LstLibrary.Items[index].ToString())
                            {
                                TxtListItem.Text = p.Name;
                            }
                        }
                    }


                    LstLibrary.Items[LstLibrary.SelectedIndex] = TxtListItem.Text;
                    UpdatePlaylist();
                    LstLibrary.SelectedIndex = -1;
                    // change selectedindex to -1, since changing visible property (below)
                    //  will make Lost_Focus run again, causing errors
                    TxtListItem.Visible = false;
                }
            }
        }


        // Show the Textbox item editor when double clicking a playlist
        private void LstLibrary_DoubleClick(object sender, EventArgs e)
        {
            // if the user double-clicked an actual playlist
            if (LstLibrary.SelectedIndex != -1)
            {
                ShowItemEditor(false);
            }
        }

        // Close this form
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Update selectedPlaylist on selected index changed
        private void LstLibrary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstLibrary.SelectedIndex != -1)
            {
                for (int i = 0; i < library.Count; i++)
                {
                    if (library[i].Name == LstLibrary.Items[LstLibrary.SelectedIndex].ToString())
                    {
                        selectedPlaylist = library[i];
                        LblPlaylist.Text = selectedPlaylist.Name;
                        break;
                    }
                }
                UpdatePlaylist();
            } else
            {
                LblPlaylist.Text = "My Library";
            }
        }

        // Get the media object at the index,
        //  then play this media
        private void LstPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void LstPlaylist_DoubleClick(object sender, EventArgs e)
        {
            if (LstPlaylist.SelectedIndex != -1)
            {
                if (int.TryParse(LstPlaylist.SelectedValue.ToString(), out int mediaId))
                {
                    // get the Media object from the listbox selected value 
                    //      ( ListBox.ValueMember = "Id" )
                    Media media = GetMediaFromListBoxValue(mediaId);
                    PlayMedia(media);
                }
            }
        }


        ToolStripMenuItem enqueue = new ToolStripMenuItem();
        ToolStripMenuItem dequeue = new ToolStripMenuItem();
        ToolStripMenuItem remove = new ToolStripMenuItem();

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (selectedPlaylist != null)
            {
                if (LstPlaylist.SelectedIndex != -1)
                {
                    remove.Text = "Remove from " + selectedPlaylist.Name;
                    remove.Click += Remove_Media;

                    dequeue.Text = "Remove from Queue";
                    dequeue.Click += Dequeue_Media;

                    enqueue.Text = "Add to Queue";
                    enqueue.Click += Enqueue_Media;

                    int.TryParse(LstPlaylist.SelectedValue.ToString(), out int mediaId);
                    Media media = GetMediaFromListBoxValue(mediaId);

                    // check if the selected media is in queue
                    if (queue.Contains(media))
                        contextMenu.Items.Add(dequeue);
                    else
                        contextMenu.Items.Add(enqueue);

                    contextMenu.Items.Add(remove);
                }
            }
        }
        private void contextMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            remove.Click -= Remove_Media;
            dequeue.Click -= Dequeue_Media;
            enqueue.Click -= Enqueue_Media;

            contextMenu.Items.Clear();
        }

        // Remove the selected media from the playlist
        private void Remove_Media(object sender, EventArgs e)
        {
            if (selectedPlaylist != null)
            {
                if (LstPlaylist.SelectedIndex != -1)
                {
                    // get the selected item
                    int mediaId = (int) LstPlaylist.SelectedValue;
                    Media media = GetMediaFromListBoxValue(mediaId);

                    if (queue.Contains(media))
                    {
                        queue.Dequeue(media);
                    }

                    if (media.Playing)
                    {
                        wmPlayer.Ctlcontrols.stop();
                    }
                }
            }
        }

        // Adding to Queue
        private void Dequeue_Media(object sender, EventArgs e)
        {
            if (selectedPlaylist != null)
            {
                if (LstPlaylist.SelectedIndex != -1)
                {
                    // get the selected media
                    int.TryParse(LstPlaylist.SelectedValue.ToString(), out int mediaId);
                    Media media = GetMediaFromListBoxValue(mediaId);

                    // remove from queue
                    if (queue.Contains(media))
                        queue.Dequeue(media);
                }
                UpdateQueue();
            }
        }
        // Removing from Queue
        private void Enqueue_Media(object sender, EventArgs e)
        {
            if (selectedPlaylist != null)
            {
                if (LstPlaylist.SelectedIndex != -1)
                {
                    // get the selected media
                    int.TryParse(LstPlaylist.SelectedValue.ToString(), out int mediaId);
                    Media media = GetMediaFromListBoxValue(mediaId);

                    // add to queue
                    if (!queue.Contains(media))
                        queue.Enqueue(media);
                }
                UpdateQueue();
            }
        }

        // Update Queue display
        private void UpdateQueue()
        {
            // ListBox queue display method
            LstQueue.Items.Clear();
            foreach (Media media in queue.Queue)
            {
                LstQueue.Items.Add(media);
            }
        }

        // Get media object from listbox Value. ListBox.SelectedValue = media.Id
        Media GetMediaFromListBoxValue(int value)
        {
            for (int i = 0; i < selectedPlaylist.List.Count; i++)
            {
                Media media = selectedPlaylist.List.ElementAt(i);
                if (media.Id == value)
                {
                    return media;
                }
            }
            return null;
        }

        // import user32dll to allow form to move with mouse
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Player_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Player_MouseDown(sender, e);
        }

        // Stop the player if the queue is not empty, or if repeat is selected
        //  otherwise, play from next song
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (repeat || queue.Get().Count > 0)
            {
                wmPlayer.Ctlcontrols.stop();
            } else
            {
                PlayNext();
            }
        }

        // Play from song history Stack
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (history.Count > 0)
            {
                Media prev = history.Pop();

                // need to match the previousMedia Id with the ListBox Item Value,
                //    to set the selected item to the previous song
                for (int i = 0; i < LstPlaylist.Items.Count; i++)
                {
                    Media item = LstPlaylist.Items[i] as Media;
                    if (item.Id == prev.Id)
                    {
                        // set the selected index as we have found the song
                        LstPlaylist.SelectedIndex = i;
                        break;
                    } 
                }
                PlayMedia(prev);
            }
        }

        // Status changed event
        private void wmPlayer_StatusChange(object sender, EventArgs e)
        {
            if (wmPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                // the player is playing
            } else if (wmPlayer.playState == WMPPlayState.wmppsStopped)
            {
                // the player has stopped
                //  add the currentlyplaying to song history Stack
                currentlyPlaying.Playing = false;
                history.Push(currentlyPlaying);

                // if the queue is not empty, play from queue
                if (queue.Get().Count > 0)
                {
                    PlayMedia(queue.Pop());
                    // update the queue
                    UpdateQueue();
                } else
                {
                    // play next song in playlist IF the repeat button is selected
                    if (repeat)
                    {
                        PlayNext();
                    }
                }
            }
        }

        private void BtnRepeat_Click(object sender, EventArgs e)
        {
            if (repeat)
            {
                BtnRepeat.Text = "Repeating";
                repeat = false;
            } else
            {
                BtnRepeat.Text = "Repeat";
                repeat = true;
            }
        }

        // Updates the sorting configuration based on ComboBox and Ascending/Descending 
        private void BtnSort_Click(object sender, EventArgs e)
        {
            if (mergeSort.Ascending)
            {
                BtnSort.Text = "Descending";
                mergeSort.Ascending = false;
            } else
            {
                BtnSort.Text = "Ascending";
                mergeSort.Ascending = true;
            }
            if (selectedPlaylist != null)
                UpdatePlaylist();
        }

        private void UpdateSorter()
        {
            // update merge sort object
            if (CmbSorting.Text == "Title")
                mergeSort.Comparer = new SortByTitle();
            else if (CmbSorting.Text == "Duration")
                mergeSort.Comparer = new SortByDuration();
            else
                mergeSort.Comparer = new SortByArtist();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (wmPlayer.playState != WMPPlayState.wmppsPlaying)
            {   // the player isn't playing at the moment
                BtnPlay.Text = "Pause";
                wmPlayer.Ctlcontrols.play();
                // resume the player
                if (selectedPlaylist != null && wmPlayer.URL == "")
                {
                    // start the player from the stopped status
                    if (LstPlaylist.Items.Count > 0)
                    {
                        LstPlaylist.SelectedIndex = 0;
                        int mediaId = (int)LstPlaylist.SelectedValue;
                        Media m = GetMediaFromListBoxValue(mediaId);
                        PlayMedia(m);
                    }
                }
            } else
            {   // the player is currently playing
                wmPlayer.Ctlcontrols.pause();
                // pause the player
                BtnPlay.Text = "Play";
            }
        }

        // handle keyDown events here and detect 
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string search = TxtSearch.Text.Trim();
                TxtSearch.Clear();

                if (selectedPlaylist != null && LstPlaylist.Items.Count > 0)
                    BinarySearch(search);
            }
        }

        // BinarySearch method is called after pressing ENTER key on search textbox
        //  iterate through the current playlist and check searchTerm against Title
        private void BinarySearch(string search)
        {
            // sort the playlist by Title-ascending prior to performing binary search
            mergeSort.Ascending = true;
            CmbSorting.SelectedIndex = 0; // select sort by "Title"
            UpdatePlaylist();

            Media returnObj = null;
            // perform iterative binary search

            int low = 0, high = playlist.Count;
            while (low <= high)
            {
                int middle = (low + high) / 2;
                if (middle < playlist.Count)
                {
                    if (playlist.ElementAt(middle).Title.CompareTo(search) == 0)
                    {
                        // Found !
                        returnObj = playlist.ElementAt(middle);
                        // save the index of the found song to local variables
                        low = high = middle;
                        break;
                    } else if (playlist.ElementAt(middle).Title.CompareTo(search) > 0)
                    {
                        high = middle - 1;
                    } else
                    {
                        low = middle + 1;
                    }
                }
            }
            if (returnObj != null)
            {
                // found !
                LstPlaylist.SelectedIndex = low;
            }
        }

        // Will export the playlists' and media objects' fields to a CSV file
        private void BtnExport_Click(object sender, EventArgs e)
        {

        }


    }
}
