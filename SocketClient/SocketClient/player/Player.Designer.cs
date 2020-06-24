namespace SocketClient.player
{
    partial class Player
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));
            this.BtnAddMedia = new System.Windows.Forms.Button();
            this.LstLibrary = new System.Windows.Forms.ListBox();
            this.LstPlaylist = new System.Windows.Forms.ListBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BtnAddPlaylist = new System.Windows.Forms.Button();
            this.TxtListItem = new System.Windows.Forms.TextBox();
            this.BtnExit = new System.Windows.Forms.Button();
            this.wmPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LblPlaylist = new System.Windows.Forms.Label();
            this.LblMedia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LstQueue = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnPrevious = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnRepeat = new System.Windows.Forms.Button();
            this.BtnSort = new System.Windows.Forms.Button();
            this.CmbSorting = new System.Windows.Forms.ComboBox();
            this.BtnExport = new System.Windows.Forms.Button();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wmPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAddMedia
            // 
            this.BtnAddMedia.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnAddMedia.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.BtnAddMedia.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnAddMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddMedia.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddMedia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnAddMedia.Location = new System.Drawing.Point(192, 58);
            this.BtnAddMedia.Name = "BtnAddMedia";
            this.BtnAddMedia.Size = new System.Drawing.Size(85, 29);
            this.BtnAddMedia.TabIndex = 1;
            this.BtnAddMedia.Text = "Add Media";
            this.BtnAddMedia.UseVisualStyleBackColor = false;
            this.BtnAddMedia.Click += new System.EventHandler(this.BtnAddMedia_Click);
            // 
            // LstLibrary
            // 
            this.LstLibrary.BackColor = System.Drawing.SystemColors.WindowText;
            this.LstLibrary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstLibrary.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstLibrary.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LstLibrary.FormattingEnabled = true;
            this.LstLibrary.ItemHeight = 19;
            this.LstLibrary.Location = new System.Drawing.Point(0, 50);
            this.LstLibrary.Name = "LstLibrary";
            this.LstLibrary.Size = new System.Drawing.Size(186, 437);
            this.LstLibrary.TabIndex = 2;
            this.LstLibrary.SelectedIndexChanged += new System.EventHandler(this.LstLibrary_SelectedIndexChanged);
            this.LstLibrary.DoubleClick += new System.EventHandler(this.LstLibrary_DoubleClick);
            // 
            // LstPlaylist
            // 
            this.LstPlaylist.BackColor = System.Drawing.Color.SlateGray;
            this.LstPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstPlaylist.ContextMenuStrip = this.contextMenu;
            this.LstPlaylist.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LstPlaylist.FormattingEnabled = true;
            this.LstPlaylist.ItemHeight = 19;
            this.LstPlaylist.Location = new System.Drawing.Point(186, 107);
            this.LstPlaylist.Name = "LstPlaylist";
            this.LstPlaylist.Size = new System.Drawing.Size(305, 399);
            this.LstPlaylist.TabIndex = 3;
            this.LstPlaylist.DoubleClick += new System.EventHandler(this.LstPlaylist_DoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            this.contextMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenu_Closing);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // BtnAddPlaylist
            // 
            this.BtnAddPlaylist.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnAddPlaylist.FlatAppearance.BorderSize = 0;
            this.BtnAddPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddPlaylist.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddPlaylist.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnAddPlaylist.Location = new System.Drawing.Point(0, 487);
            this.BtnAddPlaylist.Name = "BtnAddPlaylist";
            this.BtnAddPlaylist.Size = new System.Drawing.Size(186, 64);
            this.BtnAddPlaylist.TabIndex = 4;
            this.BtnAddPlaylist.Text = "+ Add Playlist";
            this.BtnAddPlaylist.UseVisualStyleBackColor = false;
            this.BtnAddPlaylist.Click += new System.EventHandler(this.BtnAddPlaylist_Click);
            // 
            // TxtListItem
            // 
            this.TxtListItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtListItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtListItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtListItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtListItem.Location = new System.Drawing.Point(71, 137);
            this.TxtListItem.Multiline = true;
            this.TxtListItem.Name = "TxtListItem";
            this.TxtListItem.Size = new System.Drawing.Size(100, 20);
            this.TxtListItem.TabIndex = 5;
            this.TxtListItem.Visible = false;
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExit.FlatAppearance.BorderSize = 0;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnExit.Location = new System.Drawing.Point(767, 0);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(42, 42);
            this.BtnExit.TabIndex = 7;
            this.BtnExit.Text = "X";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // wmPlayer
            // 
            this.wmPlayer.Enabled = true;
            this.wmPlayer.Location = new System.Drawing.Point(491, 236);
            this.wmPlayer.Name = "wmPlayer";
            this.wmPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmPlayer.OcxState")));
            this.wmPlayer.Size = new System.Drawing.Size(318, 315);
            this.wmPlayer.TabIndex = 0;
            this.wmPlayer.StatusChange += new System.EventHandler(this.wmPlayer_StatusChange);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Media files|*.mp3; *.mp4; *.wav; *.m4a";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Select Media files";
            // 
            // LblPlaylist
            // 
            this.LblPlaylist.AutoSize = true;
            this.LblPlaylist.BackColor = System.Drawing.Color.SteelBlue;
            this.LblPlaylist.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LblPlaylist.Location = new System.Drawing.Point(12, 9);
            this.LblPlaylist.Name = "LblPlaylist";
            this.LblPlaylist.Size = new System.Drawing.Size(86, 16);
            this.LblPlaylist.TabIndex = 8;
            this.LblPlaylist.Text = "My Library";
            // 
            // LblMedia
            // 
            this.LblMedia.AutoSize = true;
            this.LblMedia.BackColor = System.Drawing.Color.SteelBlue;
            this.LblMedia.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMedia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LblMedia.Location = new System.Drawing.Point(200, 9);
            this.LblMedia.Name = "LblMedia";
            this.LblMedia.Size = new System.Drawing.Size(0, 16);
            this.LblMedia.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.Location = new System.Drawing.Point(186, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 45);
            this.label2.TabIndex = 11;
            // 
            // LstQueue
            // 
            this.LstQueue.BackColor = System.Drawing.SystemColors.WindowText;
            this.LstQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstQueue.ContextMenuStrip = this.contextMenu;
            this.LstQueue.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstQueue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LstQueue.FormattingEnabled = true;
            this.LstQueue.ItemHeight = 19;
            this.LstQueue.Location = new System.Drawing.Point(491, 107);
            this.LstQueue.Name = "LstQueue";
            this.LstQueue.Size = new System.Drawing.Size(318, 133);
            this.LstQueue.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(772, 42);
            this.label1.TabIndex = 13;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // BtnNext
            // 
            this.BtnNext.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnNext.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.BtnNext.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNext.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnNext.Location = new System.Drawing.Point(438, 506);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(47, 36);
            this.BtnNext.TabIndex = 14;
            this.BtnNext.Text = ">>";
            this.BtnNext.UseVisualStyleBackColor = false;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnPrevious.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.BtnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrevious.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnPrevious.Location = new System.Drawing.Point(308, 506);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(47, 36);
            this.BtnPrevious.TabIndex = 15;
            this.BtnPrevious.Text = "<<";
            this.BtnPrevious.UseVisualStyleBackColor = false;
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(-3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 45);
            this.label3.TabIndex = 16;
            // 
            // BtnRepeat
            // 
            this.BtnRepeat.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnRepeat.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.BtnRepeat.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRepeat.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRepeat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnRepeat.Location = new System.Drawing.Point(192, 506);
            this.BtnRepeat.Name = "BtnRepeat";
            this.BtnRepeat.Size = new System.Drawing.Size(96, 36);
            this.BtnRepeat.TabIndex = 17;
            this.BtnRepeat.Text = "Repeating";
            this.BtnRepeat.UseVisualStyleBackColor = false;
            this.BtnRepeat.Click += new System.EventHandler(this.BtnRepeat_Click);
            // 
            // BtnSort
            // 
            this.BtnSort.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSort.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.BtnSort.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSort.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnSort.Location = new System.Drawing.Point(283, 58);
            this.BtnSort.Name = "BtnSort";
            this.BtnSort.Size = new System.Drawing.Size(89, 29);
            this.BtnSort.TabIndex = 18;
            this.BtnSort.Text = "Descending";
            this.BtnSort.UseVisualStyleBackColor = false;
            this.BtnSort.Click += new System.EventHandler(this.BtnSort_Click);
            // 
            // CmbSorting
            // 
            this.CmbSorting.AllowDrop = true;
            this.CmbSorting.BackColor = System.Drawing.Color.SteelBlue;
            this.CmbSorting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSorting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbSorting.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSorting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CmbSorting.FormattingEnabled = true;
            this.CmbSorting.Items.AddRange(new object[] {
            "Title",
            "Duration",
            "Artist"});
            this.CmbSorting.Location = new System.Drawing.Point(378, 59);
            this.CmbSorting.Name = "CmbSorting";
            this.CmbSorting.Size = new System.Drawing.Size(121, 27);
            this.CmbSorting.TabIndex = 19;
            // 
            // BtnExport
            // 
            this.BtnExport.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnExport.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.BtnExport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnExport.Location = new System.Drawing.Point(708, 58);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(89, 29);
            this.BtnExport.TabIndex = 20;
            this.BtnExport.Text = "Export CSV";
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnPlay
            // 
            this.BtnPlay.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnPlay.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.BtnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlay.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnPlay.Location = new System.Drawing.Point(361, 506);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(71, 36);
            this.BtnPlay.TabIndex = 21;
            this.BtnPlay.Text = "Play";
            this.BtnPlay.UseVisualStyleBackColor = false;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.Color.CornflowerBlue;
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtSearch.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtSearch.Location = new System.Drawing.Point(515, 69);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(177, 19);
            this.TxtSearch.TabIndex = 22;
            this.TxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(512, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Search:";
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(809, 551);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.BtnPlay);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.CmbSorting);
            this.Controls.Add(this.BtnSort);
            this.Controls.Add(this.BtnRepeat);
            this.Controls.Add(this.BtnPrevious);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.LstPlaylist);
            this.Controls.Add(this.BtnAddPlaylist);
            this.Controls.Add(this.wmPlayer);
            this.Controls.Add(this.LstQueue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblMedia);
            this.Controls.Add(this.LblPlaylist);
            this.Controls.Add(this.TxtListItem);
            this.Controls.Add(this.LstLibrary);
            this.Controls.Add(this.BtnAddMedia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Player";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Player_FormClosing);
            this.Load += new System.EventHandler(this.Player_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Player_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.wmPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer wmPlayer;
        private System.Windows.Forms.Button BtnAddMedia;
        private System.Windows.Forms.ListBox LstLibrary;
        private System.Windows.Forms.ListBox LstPlaylist;
        private System.Windows.Forms.Button BtnAddPlaylist;
        private System.Windows.Forms.TextBox TxtListItem;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label LblPlaylist;
        private System.Windows.Forms.Label LblMedia;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LstQueue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnPrevious;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnRepeat;
        private System.Windows.Forms.Button BtnSort;
        private System.Windows.Forms.ComboBox CmbSorting;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Label label4;
    }
}