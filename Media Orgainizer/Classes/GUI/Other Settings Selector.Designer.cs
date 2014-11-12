namespace Media_Orgainizer.Classes.GUI
{
    partial class Other_Settings_Selector
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
            this.pbUpdate = new System.Windows.Forms.PictureBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.pbImport = new System.Windows.Forms.PictureBox();
            this.pbExport = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowToggle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExport)).BeginInit();
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
            this.ttp.SetToolTip(this.pbShowToggle, "Other Settings");
            this.pbShowToggle.Click += new System.EventHandler(this.pbShowToggle_Click);
            // 
            // pbUpdate
            // 
            this.pbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUpdate.Image = global::Media_Orgainizer.Properties.Resources.system_software_update;
            this.pbUpdate.Location = new System.Drawing.Point(0, 0);
            this.pbUpdate.Name = "pbUpdate";
            this.pbUpdate.Size = new System.Drawing.Size(50, 50);
            this.pbUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUpdate.TabIndex = 0;
            this.pbUpdate.TabStop = false;
            this.ttp.SetToolTip(this.pbUpdate, "Update");
            this.pbUpdate.Click += new System.EventHandler(this.pbUpdate_Click);
            // 
            // pbSave
            // 
            this.pbSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSave.Image = global::Media_Orgainizer.Properties.Resources.Crystal_Project_Save_all;
            this.pbSave.Location = new System.Drawing.Point(0, 0);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(50, 50);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 0;
            this.pbSave.TabStop = false;
            this.ttp.SetToolTip(this.pbSave, "Save");
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbImport
            // 
            this.pbImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImport.Image = global::Media_Orgainizer.Properties.Resources.import_icon;
            this.pbImport.Location = new System.Drawing.Point(0, 0);
            this.pbImport.Name = "pbImport";
            this.pbImport.Size = new System.Drawing.Size(50, 50);
            this.pbImport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImport.TabIndex = 0;
            this.pbImport.TabStop = false;
            this.ttp.SetToolTip(this.pbImport, "Import");
            this.pbImport.Click += new System.EventHandler(this.pbImport_Click);
            // 
            // pbExport
            // 
            this.pbExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbExport.Image = global::Media_Orgainizer.Properties.Resources.Export_icon;
            this.pbExport.Location = new System.Drawing.Point(0, 0);
            this.pbExport.Name = "pbExport";
            this.pbExport.Size = new System.Drawing.Size(50, 50);
            this.pbExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbExport.TabIndex = 0;
            this.pbExport.TabStop = false;
            this.ttp.SetToolTip(this.pbExport, "Export");
            this.pbExport.Click += new System.EventHandler(this.pbExport_Click);
            // 
            // Other_Settings_Selector
            // 
            this.Size = new System.Drawing.Size(30, 30);
            ((System.ComponentModel.ISupportInitialize)(this.pbShowToggle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip ttp;
        private System.Windows.Forms.PictureBox pbShowToggle;
        private System.Windows.Forms.PictureBox pbUpdate;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.PictureBox pbImport;
        private System.Windows.Forms.PictureBox pbExport;
    }
}
