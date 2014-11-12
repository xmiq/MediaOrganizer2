namespace Media_Orgainizer.Classes.GUI
{
    partial class Media_Categories
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
            this.components = new System.ComponentModel.Container();
            this.ttp = new System.Windows.Forms.ToolTip(this.components);
            this.pbShowToggle = new System.Windows.Forms.PictureBox();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            this.stackingPanel1 = new Media_Orgainizer.Classes.GUI.StackingPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowToggle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // pbShowToggle
            // 
            this.pbShowToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbShowToggle.Image = global::Media_Orgainizer.Properties.Resources.ArrowR;
            this.pbShowToggle.Location = new System.Drawing.Point(0, 0);
            this.pbShowToggle.Name = "pbShowToggle";
            this.pbShowToggle.Size = new System.Drawing.Size(25, 25);
            this.pbShowToggle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShowToggle.TabIndex = 0;
            this.pbShowToggle.TabStop = false;
            this.ttp.SetToolTip(this.pbShowToggle, "Media Managment");
            this.pbShowToggle.Click += new System.EventHandler(this.pbShowToggle_Click);
            // 
            // pbAdd
            // 
            this.pbAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAdd.Image = global::Media_Orgainizer.Properties.Resources._3884;
            this.pbAdd.Location = new System.Drawing.Point(0, 0);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(20, 20);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAdd.TabIndex = 0;
            this.pbAdd.TabStop = false;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // stackingPanel1
            // 
            this.stackingPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stackingPanel1.AutoScroll = true;
            this.stackingPanel1.AutoSize = true;
            this.stackingPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stackingPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.stackingPanel1.Location = new System.Drawing.Point(0, 0);
            this.stackingPanel1.Name = "stackingPanel1";
            this.stackingPanel1.Size = new System.Drawing.Size(200, 100);
            this.stackingPanel1.TabIndex = 0;
            // 
            // Media_Categories
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Size = new System.Drawing.Size(30, 30);
            ((System.ComponentModel.ISupportInitialize)(this.pbShowToggle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbShowToggle;
        private StackingPanel stackingPanel1;
        private System.Windows.Forms.ToolTip ttp;
        private System.Windows.Forms.PictureBox pbAdd;
    }
}
