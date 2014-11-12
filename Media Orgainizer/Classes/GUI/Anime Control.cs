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
    public partial class Anime_Control : Control
    {
        public Anime_Control(MediaItem media)
        {
            InitializeComponent();
            InitilazeChildren();
            ControlAnime = new Anime()
                {
                    Media = media,
                    ItemId = Guid.NewGuid()
                };
            Media.AddContent(ControlAnime);
        }

        private Anime ControlAnime;

        public Anime_Control(Anime a)
        {
            InitializeComponent();
            InitilazeChildren();
            ControlAnime = a;
            AnimeName = a.Name;
            Episode = a.Episode;
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
            int widthOfControlWithoutName = 495 - 170;
            if (Width > 495) txtName.Width = Width - widthOfControlWithoutName;
            leftPos += txtName.Width + 10;

            //Control: Episode Label
            Controls.Add(lblEpisode);
            lblEpisode.Top = 2;
            lblEpisode.Left = leftPos;
            leftPos += lblEpisode.Width + 10;

            //Control: Episode Number
            Controls.Add(numEpisode);
            numEpisode.Left = leftPos;
            leftPos += numEpisode.Width + 10;

            //Control: OK PictureBox
            Controls.Add(pbOK);
            pbOK.Left = leftPos;
            leftPos += pbOK.Width + 10;

            //Control: Cancel PictureBox
            Controls.Add(pbCancel);
            pbCancel.Left = leftPos;
        }

        public string AnimeName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
                ControlAnime.Name = value;
            }
        }

        public int Episode
        {
            get
            {
                return Convert.ToInt32(numEpisode.Value);
            }
            set
            {
                numEpisode.Value = value;
                ControlAnime.Episode = value;
            }
        }

        void pb_Click(object sender, EventArgs e)
        {
            ControlAnime.Name = txtName.Text;
            ControlAnime.Episode = Convert.ToInt32(numEpisode.Value);
            DataManagment.Save();
            if (SaveSucceded != null) SaveSucceded();
        }

        public delegate void SaveDelegate();

        public event SaveDelegate SaveSucceded;

        void pb2_Click(object sender, EventArgs e)
        {
            Media.RemoveContent(ControlAnime.ItemId);
            DataManagment.Save();
            if(Deleted != null) Deleted();
        }

        public delegate void DeleteDelegate();

        public event DeleteDelegate Deleted;
    }
}
