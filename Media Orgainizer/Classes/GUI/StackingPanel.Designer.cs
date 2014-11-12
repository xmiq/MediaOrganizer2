namespace Media_Orgainizer.Classes.GUI
{
    partial class StackingPanel
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
            this.SuspendLayout();
            // 
            // StackingPanel
            // 
            this.AutoScroll = true;
            this.SizeChanged += new System.EventHandler(this.StackingPanel_SizeChanged);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.StackingPanel_ControlAdded);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.StackingPanel_ControlRemoved);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
