namespace SocketClient.player
{
    partial class DialogForm
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
            this.BtnOpenM = new System.Windows.Forms.Button();
            this.BtnOpenP = new System.Windows.Forms.Button();
            this.LblMessage = new System.Windows.Forms.Label();
            this.TxtArea = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // BtnOpenM
            // 
            this.BtnOpenM.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpenM.Location = new System.Drawing.Point(228, 156);
            this.BtnOpenM.Name = "BtnOpenM";
            this.BtnOpenM.Size = new System.Drawing.Size(89, 44);
            this.BtnOpenM.TabIndex = 0;
            this.BtnOpenM.Text = "Media spreadsheet";
            this.BtnOpenM.UseVisualStyleBackColor = true;
            this.BtnOpenM.Click += new System.EventHandler(this.BtnOpenM_Click);
            // 
            // BtnOpenP
            // 
            this.BtnOpenP.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpenP.Location = new System.Drawing.Point(54, 156);
            this.BtnOpenP.Name = "BtnOpenP";
            this.BtnOpenP.Size = new System.Drawing.Size(89, 44);
            this.BtnOpenP.TabIndex = 1;
            this.BtnOpenP.Text = "Playlist spreadsheet";
            this.BtnOpenP.UseVisualStyleBackColor = true;
            this.BtnOpenP.Click += new System.EventHandler(this.BtnOpenP_Click);
            // 
            // LblMessage
            // 
            this.LblMessage.AutoSize = true;
            this.LblMessage.Location = new System.Drawing.Point(12, 9);
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(35, 13);
            this.LblMessage.TabIndex = 2;
            this.LblMessage.Text = "label1";
            // 
            // TxtArea
            // 
            this.TxtArea.Location = new System.Drawing.Point(12, 25);
            this.TxtArea.Name = "TxtArea";
            this.TxtArea.Size = new System.Drawing.Size(349, 125);
            this.TxtArea.TabIndex = 3;
            this.TxtArea.Text = "";
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 221);
            this.Controls.Add(this.TxtArea);
            this.Controls.Add(this.LblMessage);
            this.Controls.Add(this.BtnOpenP);
            this.Controls.Add(this.BtnOpenM);
            this.Name = "DialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DialogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOpenM;
        private System.Windows.Forms.Button BtnOpenP;
        private System.Windows.Forms.Label LblMessage;
        private System.Windows.Forms.RichTextBox TxtArea;
    }
}