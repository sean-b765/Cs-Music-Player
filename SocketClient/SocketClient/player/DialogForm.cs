using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * DialogForm.cs - custom message box
 * Author: Sean Boaden | 30010353
 */

namespace SocketClient.player
{
    public partial class DialogForm : Form
    {
        public DialogForm()
        {
            InitializeComponent();
        }

        public DialogForm(string message, string title)
        {
            InitializeComponent();
            LblMessage.Text = "Successfully saved!";
            TxtArea.Text = message;
            this.Text = title;
        }

        private void BtnOpenP_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @Path.GetDirectoryName("playlists.csv\\.."));
            this.Close();
        }

        private void BtnOpenM_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @Path.GetDirectoryName("media.csv\\.."));
            this.Close();
        }
    }
}
