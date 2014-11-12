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
    public partial class Media_Categories : Control
    {
        public Media_Categories()
        {
            InitializeComponent();
            if (!DataManagment.Loaded) DataManagment.Load();
            if (Media.isEmpty) Media.AddMedia("Default");
            Controls.Add(pbShowToggle);
            Controls.Add(stackingPanel1);
            Controls.Add(pbAdd);
            PopulatePanel();

            stackingPanel1.Left = 0 - stackingPanel1.Width;
            pbAdd.Left = 0 - stackingPanel1.Width;
            pbAdd.Top = Height - 25;
            if (SelectedMedia != null) SelectedMedia.SelectControl();
        }

        private bool toogle = true;
        private int position = 0;
        private Media_Control SelectedMedia = null;

        public int ExpandedHeight { get; set; }

        void mc_Click(object sender, EventArgs e)
        {
            SelectedMedia.DeselectControl();
            SelectedMedia = sender as Media_Control;
            SelectedMedia.SelectControl();
            if (SelectedItemChange != null) SelectedItemChange(SelectedMedia.Media);
            pbShowToggle_Click(null, null);
        }

        void mc_MediaUpdated()
        {
            MediaItem mi = SelectedMedia.Media;
            stackingPanel1.Controls.Clear();
            PopulatePanel(mi);
            SelectedMedia.SelectControl();
            if (stackingPanel1.Width != Width - 30) Width = stackingPanel1.Width + 30;
        }

        void PopulatePanel()
        {
            PopulatePanel(null);
        }

        void PopulatePanel(MediaItem Selected)
        {
            foreach (MediaItem mi in Media.MediaList)
            {
                Media_Control mc = new Media_Control(mi);
                if (Selected == null || Selected == mi) SelectedMedia = mc;
                if (SelectedMedia != null) Selected = SelectedMedia.Media;
                mc.Click += mc_Click;
                mc.MediaUpdated += mc_MediaUpdated;
                stackingPanel1.Controls.Add(mc);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void pbShowToggle_Click(object sender, EventArgs e)
        {
            if (position == 0) position = Top;
            if (toogle)
            {
                pbShowToggle.Image = Properties.Resources.ArrowL;
                Height = ExpandedHeight;
                pbShowToggle.Top = position;
                Top = 10;
                for (int i = 1; i < stackingPanel1.Width; i++)
                {
                    Width += 1;
                    Refresh();
                }
                toogle = false;
                if (ToggleVisible != null) ToggleVisible();
            }
            else
            {
                pbShowToggle.Image = Properties.Resources.ArrowR;
                for (int i = 1; i < stackingPanel1.Width; i++)
                {
                    Width -= 1;
                    Refresh();
                }
                Height = 30;
                pbShowToggle.Top = 0;
                Top = position;
                toogle = true;
                if (ToggleInvisible != null) ToggleInvisible();
            }
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            Media_Control mc = new Media_Control();
            mc.Click += mc_Click;
            mc.MediaUpdated += mc_MediaUpdated;
            stackingPanel1.Controls.Add(mc);
        }

        public MediaItem SelectedItem
        {
            get
            {
                return SelectedMedia.Media;
            }
        }

        public delegate void ToggleDelegate();

        public event ToggleDelegate ToggleVisible;

        public event ToggleDelegate ToggleInvisible;

        public delegate void SelectChangeDelegate(MediaItem mi);

        public event SelectChangeDelegate SelectedItemChange;

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
    }
}
