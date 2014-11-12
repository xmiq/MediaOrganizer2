namespace Media_Orgainizer.Classes.GUI
{
    partial class Anime_Control
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEpisode = new System.Windows.Forms.Label();
            this.numEpisode = new System.Windows.Forms.NumericUpDown();
            this.pbOK = new System.Windows.Forms.PictureBox();
            this.pbCancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numEpisode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(0, 0);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(278, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblEpisode
            // 
            this.lblEpisode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEpisode.AutoSize = true;
            this.lblEpisode.Location = new System.Drawing.Point(0, 0);
            this.lblEpisode.Name = "lblEpisode";
            this.lblEpisode.Size = new System.Drawing.Size(100, 23);
            this.lblEpisode.TabIndex = 4;
            this.lblEpisode.Text = "Episode:";
            // 
            // numEpisode
            // 
            this.numEpisode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numEpisode.AutoSize = true;
            this.numEpisode.Location = new System.Drawing.Point(0, 0);
            this.numEpisode.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEpisode.Name = "numEpisode";
            this.numEpisode.Size = new System.Drawing.Size(30, 20);
            this.numEpisode.TabIndex = 5;
            this.numEpisode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pbOK
            // 
            this.pbOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbOK.Image = global::Media_Orgainizer.Properties.Resources.ok;
            this.pbOK.Location = new System.Drawing.Point(0, 0);
            this.pbOK.Name = "pbOK";
            this.pbOK.Size = new System.Drawing.Size(20, 20);
            this.pbOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOK.TabIndex = 0;
            this.pbOK.TabStop = false;
            this.pbOK.Click += new System.EventHandler(this.pb_Click);
            // 
            // pbCancel
            // 
            this.pbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCancel.Image = global::Media_Orgainizer.Properties.Resources.delete;
            this.pbCancel.Location = new System.Drawing.Point(0, 0);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(20, 20);
            this.pbCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCancel.TabIndex = 0;
            this.pbCancel.TabStop = false;
            this.pbCancel.Click += new System.EventHandler(this.pb2_Click);
            // 
            // Anime_Control
            // 
            this.Size = new System.Drawing.Size(495, 23);
            ((System.ComponentModel.ISupportInitialize)(this.numEpisode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEpisode;
        private System.Windows.Forms.NumericUpDown numEpisode;
        private System.Windows.Forms.PictureBox pbOK;
        private System.Windows.Forms.PictureBox pbCancel;
    }
}
