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
    public partial class Music_Control : Control
    {
        public Music_Control(MediaItem mediaItem)
        {
            InitializeComponent();
            InitilazeChildren();
            ControlMusic = new Music()
            {
                Media = mediaItem,
                ItemId = Guid.NewGuid()
            };
            Media.AddContent(ControlMusic);
        }

        private Music ControlMusic;

        public Music_Control(Music b)
        {
            InitializeComponent();
            InitilazeChildren();
            ControlMusic = b;
            MusicName = b.Name;
        }

        public void InitilazeChildren()
        {
            int leftPos = 0;

            //Control: Name Label
            Controls.Add(lblName);
            lblName.Top = 2;
            leftPos += lblName.Width + 10; //Left Position of Next Control

            //Control: Name Textbox
            Controls.Add(txtName);
            txtName.Left = leftPos;
            int widthOfControlWithoutName = 495 - 100;
            if (Width > 495) txtName.Width = Width - widthOfControlWithoutName;
            leftPos += txtName.Width + 10;

            //Control: Album Label
            Controls.Add(lblAlbum);
            lblAlbum.Top = 2;
            lblAlbum.Left = leftPos;
            leftPos += lblAlbum.Width + 10;

            //Control: Album Textbox
            Controls.Add(txtAlbum);
            txtAlbum.Left = leftPos;
            if (Width > 495) txtAlbum.Width = Width - widthOfControlWithoutName;
            leftPos += txtAlbum.Width + 10;

            //Control: Singer Label
            Controls.Add(lblSinger);
            lblSinger.Top = 2;
            lblSinger.Left = leftPos;
            leftPos += lblSinger.Width + 10;

            //Control: ISBN Textbox
            Controls.Add(txtSinger);
            txtSinger.Left = leftPos;
            if (Width > 495) txtSinger.Width = Width - widthOfControlWithoutName;
            leftPos += txtSinger.Width + 10;

            ////Control: OK PictureBox
            Controls.Add(pbOK);
            pbOK.Left = leftPos;
            leftPos += pbOK.Width + 10;

            ////Control: Cancel PictureBox
            Controls.Add(pbCancel);
            pbCancel.Left = leftPos;
        }

        public string MusicName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
                ControlMusic.Name = value;
            }
        }

        void pb_Click(object sender, EventArgs e)
        {
            ControlMusic.Name = txtName.Text;
            ControlMusic.Album = txtAlbum.Text;
            ControlMusic.Artist = txtSinger.Text;
            DataManagment.Save();
            if (SaveSucceded != null) SaveSucceded();
        }

        public new int Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
                int totalTxtWidth = 495 - 268;
                int newTotalTxtWidth = Width - totalTxtWidth;
                int remainder = newTotalTxtWidth % 3;
                if (Width > 495) txtName.Width = (newTotalTxtWidth / 3);
                if (Width > 495) txtAlbum.Width = newTotalTxtWidth / 3;
                if (Width > 495) txtSinger.Width = newTotalTxtWidth / 3;
                
                int leftPos = 0;
                leftPos += lblName.Width + 10;
                txtName.Left = leftPos;
                leftPos += txtName.Width + 10;
                lblAlbum.Left = leftPos;
                leftPos += lblAlbum.Width + 10;
                txtAlbum.Left = leftPos;
                leftPos += txtAlbum.Width + 10;
                lblSinger.Left = leftPos;
                leftPos += lblSinger.Width + 10;
                txtSinger.Left = leftPos;
                leftPos += txtSinger.Width + 10;
                pbOK.Left = leftPos;
                leftPos += pbOK.Width + 10;
                pbCancel.Left = leftPos;
            }
        }

        public delegate void SaveDelegate();

        public event SaveDelegate SaveSucceded;

        void pb2_Click(object sender, EventArgs e)
        {
            Media.RemoveContent(ControlMusic.ItemId);
            DataManagment.Save();
            if (Deleted != null) Deleted();
        }

        public delegate void DeleteDelegate();

        public event DeleteDelegate Deleted;
    }
}
