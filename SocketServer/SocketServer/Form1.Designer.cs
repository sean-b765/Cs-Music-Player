namespace SocketServer
{
    partial class Form1
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
            this.BtnStart = new System.Windows.Forms.Button();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.LstLog = new System.Windows.Forms.ListBox();
            this.Clients = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(12, 12);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(93, 14);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(73, 20);
            this.TxtPort.TabIndex = 1;
            this.TxtPort.Text = "1234";
            // 
            // LstLog
            // 
            this.LstLog.FormattingEnabled = true;
            this.LstLog.Location = new System.Drawing.Point(12, 82);
            this.LstLog.Name = "LstLog";
            this.LstLog.Size = new System.Drawing.Size(196, 277);
            this.LstLog.TabIndex = 2;
            // 
            // Clients
            // 
            this.Clients.FormattingEnabled = true;
            this.Clients.Location = new System.Drawing.Point(509, 82);
            this.Clients.Name = "Clients";
            this.Clients.Size = new System.Drawing.Size(196, 277);
            this.Clients.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(509, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Connected Clients";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Clients);
            this.Controls.Add(this.LstLog);
            this.Controls.Add(this.TxtPort);
            this.Controls.Add(this.BtnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.ListBox LstLog;
        private System.Windows.Forms.ListBox Clients;
        private System.Windows.Forms.Label label1;
    }
}

