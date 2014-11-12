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
    public partial class Movie_Control : Control
    {
        public Movie_Control(MediaItem mediaItem)
        {
            InitializeComponent();
            InitilazeChildren();
            ControlMovie = new Movie()
                {
                    Media = mediaItem,
                    ItemId = Guid.NewGuid()
                };
            Media.AddContent(ControlMovie);
        }

        private Movie ControlMovie;

        public Movie_Control(Movie m)
        {
            InitializeComponent();
            InitilazeChildren();
            ControlMovie = m;
            MovieName = m.Name;
        }

        public void InitilazeChildren()
        {
            int leftPos = 0;

            //Control: Name Label
            Controls.Add(lblName);
            lblName.Top = 2;
            leftPos += lblName.Width + 10; //Left Position of Next Control

            ////Control: Name Textbox
            Controls.Add(txtName);
            txtName.Left = leftPos;
            int widthOfControlWithoutName = 495 - 386;
            if (Width > 495) txtName.Width = Width - widthOfControlWithoutName;
            leftPos += txtName.Width + 10;

            ////Control: OK PictureBox
            Controls.Add(pbOK);
            pbOK.Left = leftPos;
            leftPos += pbOK.Width + 10;

            ////Control: Cancel PictureBox
            Controls.Add(pbCancel);
            pbCancel.Left = leftPos;
        }

        public string MovieName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
                ControlMovie.Name = value;
            }
        }

        void pb_Click(object sender, EventArgs e)
        {
            ControlMovie.Name = txtName.Text;
            DataManagment.Save();
            if (SaveSucceded != null) SaveSucceded();
        }

        public delegate void SaveDelegate();

        public event SaveDelegate SaveSucceded;

        void pb2_Click(object sender, EventArgs e)
        {
            Media.RemoveContent(ControlMovie.ItemId);
            DataManagment.Save();
            if (Deleted != null) Deleted();
        }

        public delegate void DeleteDelegate();

        public event DeleteDelegate Deleted;
    }
}
