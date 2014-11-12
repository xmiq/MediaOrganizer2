using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Orgainizer.Classes.GUI
{
    public partial class Data_Item_Selector : Control
    {
        public Data_Item_Selector()
        {
            InitializeComponent();
            Controls.Add(pbShowToggle);
            Controls.Add(pbSeries);
            Controls.Add(pbMovie);
            Controls.Add(pbBook);
            Controls.Add(pbAnime);
            Controls.Add(pbManga);
            Controls.Add(pbMusic);

            //Locations
            int Left = -60;
            pbMusic.Left = Left;
            Left -= 60;
            pbManga.Left = Left;
            Left -= 60;
            pbAnime.Left = Left;
            Left -= 60;
            pbBook.Left = Left;
            Left -= 60;
            pbMovie.Left = Left;
            Left -= 60;
            pbSeries.Left = Left;
        }

        private bool toogle = true;

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void pbShowToggle_Click(object sender, EventArgs e)
        {
            if (toogle)
            {
                BringToFront();
                pbShowToggle.Image = Properties.Resources.ArrowL;
                Height += 25;
                for (int i = 1; i < 125; i++)
                {
                    Width += 3;
                    Refresh();
                }
                if (ToggleVisible != null) ToggleVisible();
            }
            else
            {
                pbShowToggle.Image = Properties.Resources.ArrowR;
                for (int i = 1; i < 125; i++)
                {
                    Width -= 3;
                    Refresh();
                }
                Height -= 25;
                if (ToggleInvisible != null) ToggleInvisible();
            }
            toogle = !toogle;
        }

        public delegate void ToggleDelegate();

        public event ToggleDelegate ToggleVisible;

        public event ToggleDelegate ToggleInvisible;

        public delegate void SeriesDelegate();

        public event SeriesDelegate SeriesClicked;

        public delegate void MovieDelegete();

        public event MovieDelegete MovieClicked;

        public delegate void BookDelegete();

        public event BookDelegete BookClicked;

        public delegate void AnimeDelegete();

        public event AnimeDelegete AnimeClicked;

        public delegate void MangaDelegete();

        public event MangaDelegete MangaClicked;

        public delegate void MusicDelegete();

        public event MusicDelegete MusicClicked;

        public bool Toggle
        {
            get
            {
                return toogle;
            }
            
            set
            {
                if (!value) pbShowToggle_Click(null, null);
            }
        }

        private void pbSeries_Click(object sender, EventArgs e)
        {
            if (SeriesClicked != null) SeriesClicked();
            pbShowToggle_Click(null, null);
        }

        private void pbMovie_Click(object sender, EventArgs e)
        {
            if (MovieClicked != null) MovieClicked();
            pbShowToggle_Click(null, null);
        }

        private void pbBook_Click(object sender, EventArgs e)
        {
            if (BookClicked != null) BookClicked();
            pbShowToggle_Click(null, null);
        }

        private void pbAnime_Click(object sender, EventArgs e)
        {
            if (AnimeClicked != null) AnimeClicked();
            pbShowToggle_Click(null, null);
        }

        private void pbManga_Click(object sender, EventArgs e)
        {
            if (MangaClicked != null) MangaClicked();
            pbShowToggle_Click(null, null);
        }

        private void pbMusic_Click(object sender, EventArgs e)
        {
            if (MusicClicked != null) MusicClicked();
            pbShowToggle_Click(null, null);
        }
    }
}
