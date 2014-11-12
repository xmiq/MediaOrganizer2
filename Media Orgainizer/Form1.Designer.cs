namespace Media_Orgainizer
{
    partial class frmMain
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
            this.grpContent = new System.Windows.Forms.GroupBox();
            this.spContent = new Media_Orgainizer.Classes.GUI.StackingPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslNotification = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbUpdate = new System.Windows.Forms.ToolStripProgressBar();
            this.other_Settings_Selector1 = new Media_Orgainizer.Classes.GUI.Other_Settings_Selector();
            this.media_Categories1 = new Media_Orgainizer.Classes.GUI.Media_Categories();
            this.data_Item_Selector1 = new Media_Orgainizer.Classes.GUI.Data_Item_Selector();
            this.grpContent.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpContent
            // 
            this.grpContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpContent.BackColor = System.Drawing.Color.Transparent;
            this.grpContent.Controls.Add(this.spContent);
            this.grpContent.Location = new System.Drawing.Point(42, 12);
            this.grpContent.Name = "grpContent";
            this.grpContent.Size = new System.Drawing.Size(610, 514);
            this.grpContent.TabIndex = 2;
            this.grpContent.TabStop = false;
            this.grpContent.Text = "Media";
            // 
            // spContent
            // 
            this.spContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spContent.AutoScroll = true;
            this.spContent.BackColor = System.Drawing.Color.White;
            this.spContent.Location = new System.Drawing.Point(6, 19);
            this.spContent.Name = "spContent";
            this.spContent.Size = new System.Drawing.Size(598, 489);
            this.spContent.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslNotification,
            this.tspbUpdate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(664, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "ssNotify";
            // 
            // tsslNotification
            // 
            this.tsslNotification.Name = "tsslNotification";
            this.tsslNotification.Size = new System.Drawing.Size(118, 17);
            this.tsslNotification.Text = "toolStripStatusLabel1";
            this.tsslNotification.Visible = false;
            // 
            // tspbUpdate
            // 
            this.tspbUpdate.Name = "tspbUpdate";
            this.tspbUpdate.Size = new System.Drawing.Size(25, 16);
            this.tspbUpdate.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tspbUpdate.Visible = false;
            // 
            // other_Settings_Selector1
            // 
            this.other_Settings_Selector1.Location = new System.Drawing.Point(6, 103);
            this.other_Settings_Selector1.Name = "other_Settings_Selector1";
            this.other_Settings_Selector1.Size = new System.Drawing.Size(30, 30);
            this.other_Settings_Selector1.TabIndex = 8;
            this.other_Settings_Selector1.Text = "other_Settings_Selector1";
            this.other_Settings_Selector1.Toggle = true;
            // 
            // media_Categories1
            // 
            this.media_Categories1.BackColor = System.Drawing.SystemColors.Control;
            this.media_Categories1.ExpandedHeight = 0;
            this.media_Categories1.Location = new System.Drawing.Point(6, 67);
            this.media_Categories1.Name = "media_Categories1";
            this.media_Categories1.Size = new System.Drawing.Size(30, 30);
            this.media_Categories1.TabIndex = 7;
            this.media_Categories1.Text = "media_Categories1";
            this.media_Categories1.Toggle = true;
            // 
            // data_Item_Selector1
            // 
            this.data_Item_Selector1.Location = new System.Drawing.Point(6, 31);
            this.data_Item_Selector1.Name = "data_Item_Selector1";
            this.data_Item_Selector1.Size = new System.Drawing.Size(30, 30);
            this.data_Item_Selector1.TabIndex = 6;
            this.data_Item_Selector1.Text = "data_Item_Selector1";
            this.data_Item_Selector1.Toggle = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 551);
            this.Controls.Add(this.other_Settings_Selector1);
            this.Controls.Add(this.media_Categories1);
            this.Controls.Add(this.data_Item_Selector1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpContent);
            this.MinimumSize = new System.Drawing.Size(680, 589);
            this.Name = "frmMain";
            this.Text = "Media Organizer 2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.grpContent.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpContent;
        private Classes.GUI.StackingPanel spContent;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslNotification;
        private System.Windows.Forms.ToolStripProgressBar tspbUpdate;
        private Classes.GUI.Data_Item_Selector data_Item_Selector1;
        private Classes.GUI.Media_Categories media_Categories1;
        private Classes.GUI.Other_Settings_Selector other_Settings_Selector1;
    }
}

