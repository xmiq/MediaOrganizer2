namespace Media_Orgainizer.Classes.GUI
{
    partial class Media_Control
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
            this.lblMedia = new System.Windows.Forms.Label();
            this.pbEdit = new System.Windows.Forms.PictureBox();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMedia
            // 
            this.lblMedia.AutoSize = true;
            this.lblMedia.Location = new System.Drawing.Point(0, 0);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(100, 23);
            this.lblMedia.TabIndex = 0;
            this.lblMedia.Text = "Default";
            // 
            // pbEdit
            // 
            this.pbEdit.Image = global::Media_Orgainizer.Properties.Resources._5cce6edb6c48;
            this.pbEdit.Location = new System.Drawing.Point(0, 0);
            this.pbEdit.Name = "pbEdit";
            this.pbEdit.Size = new System.Drawing.Size(20, 20);
            this.pbEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEdit.TabIndex = 0;
            this.pbEdit.TabStop = false;
            // 
            // txtMedia
            // 
            this.txtMedia.Location = new System.Drawing.Point(0, 0);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(100, 20);
            this.txtMedia.TabIndex = 0;
            this.txtMedia.Visible = false;
            // 
            // pbDelete
            // 
            this.pbDelete.Image = global::Media_Orgainizer.Properties.Resources.delete;
            this.pbDelete.Location = new System.Drawing.Point(0, 0);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(20, 20);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDelete.TabIndex = 0;
            this.pbDelete.TabStop = false;
            // 
            // Media_Control
            // 
            this.Size = new System.Drawing.Size(100, 23);
            ((System.ComponentModel.ISupportInitialize)(this.pbEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMedia;
        private System.Windows.Forms.PictureBox pbEdit;
        private System.Windows.Forms.TextBox txtMedia;
        private System.Windows.Forms.PictureBox pbDelete;
    }
}
