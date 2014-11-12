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
    public partial class Series_Control : Control
    {
        public Series_Control(MediaItem media)
        {
            InitializeComponent();
            InitilazeChildren();
            ControlSeries = new Series()
                {
                    Media = media,
                    ItemId = Guid.NewGuid()
                };
            Media.AddContent(ControlSeries);
        }

        private Series ControlSeries;

        public Series_Control(Series s)
        {
            InitializeComponent();
            InitilazeChildren();
            ControlSeries = s;
            SeriesName = s.Name;
            Season = s.Season;
            Episode = s.Episode;
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

            //Control: Season Label
            Controls.Add(lblSeason);
            lblSeason.Top = 2;
            lblSeason.Left = leftPos;
            leftPos += lblSeason.Width + 10;

            //Control: Season Number
            Controls.Add(numSeason);
            numSeason.Left = leftPos;
            leftPos += numSeason.Width + 10;

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

        public string SeriesName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
                ControlSeries.Name = value;
            }
        }

        public int Season
        {
            get
            {
                return Convert.ToInt32(numSeason.Value);
            }
            set
            {
                numSeason.Value = value;
                ControlSeries.Season = value;
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
                ControlSeries.Episode = value;
            }
        }

        void pb_Click(object sender, EventArgs e)
        {
            ControlSeries.Name = txtName.Text;
            ControlSeries.Season = Convert.ToInt32(numSeason.Value);
            ControlSeries.Episode = Convert.ToInt32(numEpisode.Value);
            DataManagment.Save();
            if (SaveSucceded != null) SaveSucceded();
        }

        public delegate void SaveDelegate();

        public event SaveDelegate SaveSucceded;

        void pb2_Click(object sender, EventArgs e)
        {
            Media.RemoveContent(ControlSeries.ItemId);
            DataManagment.Save();
            if(Deleted != null) Deleted();
        }

        public delegate void DeleteDelegate();

        public event DeleteDelegate Deleted;

        private void numSeason_ValueChanged(object sender, EventArgs e)
        {
            numEpisode.Value = 1;
        }
    }
}
