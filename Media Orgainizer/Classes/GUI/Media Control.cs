using Media_Orgainizer.Classes.Data;
using Media_Orgainizer.Classes.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Orgainizer.Classes.GUI
{
    public partial class Media_Control : Control
    {
        public Media_Control()
        {
            InitializeComponent();
            ControlMediaItem = new MediaItem();
            Populate();
            pbEdit_Click(null, null);
            newM = true; 
        }

        public Media_Control(MediaItem mi)
        {
            InitializeComponent();

            ControlMediaItem = mi;
            Populate();
        }

        private MediaItem ControlMediaItem;
        private bool newM = false;

        private void Populate()
        {
            //Control: Media Label
            Controls.Add(lblMedia);
            lblMedia.Text = ControlMediaItem.Name;
            lblMedia.Top = 2;
            lblMedia.Left = 50;
            lblMedia.Click += lblMedia_Click;

            //Control: Edit PictureBox
            Controls.Add(pbEdit);
            pbEdit.Click += pbEdit_Click;

            //Control: Media TextBox
            Controls.Add(txtMedia);
            txtMedia.Text = ControlMediaItem.Name;
            txtMedia.Left = 50;
            txtMedia.KeyUp += txtMedia_KeyUp;
            if (lblMedia.Width > 0) txtMedia.Width = lblMedia.Width;
            else txtMedia.Width = 50;

            //Control: Delete PictureBox
            Controls.Add(pbDelete);
            pbDelete.Left = 25;
            pbDelete.Click += pbDelete_Click;

            this.Width = 50 + lblMedia.Width;
        }

        public void SelectControl()
        {
            lblMedia.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline);
        }

        public void DeselectControl()
        {
            lblMedia.Font = new Font("Microsoft Sans Serif", 8.25f);
        }

        void lblMedia_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        void pbEdit_Click(object sender, EventArgs e)
        {
            if (lblMedia.Visible)
            {
                lblMedia.Visible = false;
                txtMedia.Visible = true;
            }
            else
            {
                lblMedia.Visible = true;
                txtMedia.Visible = false;
                txtMedia.Text = ControlMediaItem.Name;
            }
        }

        void pbDelete_Click(object sender, EventArgs e)
        {
            Media_Orgainizer.Classes.Data.Media.RemoveMedia(ControlMediaItem);
            DataManagment.Save();
            if (MediaUpdated != null) MediaUpdated();
        }

        void txtMedia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblMedia.Visible = true;
                txtMedia.Visible = false;
                if (txtMedia.Text != "")
                {
                    if (newM) Classes.Data.Media.AddMedia(txtMedia.Text);
                    else ControlMediaItem.Name = txtMedia.Text;
                    DataManagment.Save();
                    this.Width = 50 + lblMedia.Width;
                    txtMedia.Width = lblMedia.Width;
                    if (MediaUpdated != null) MediaUpdated();
                }
                else txtMedia.Text = lblMedia.Text;
            }
        }

        public MediaItem Media
        {
            get
            {
                return ControlMediaItem;
            }
        }

        public delegate void UpdateDelegate();

        public event UpdateDelegate MediaUpdated;
    }
}
