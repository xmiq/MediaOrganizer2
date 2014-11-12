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
    public partial class Other_Settings_Selector : Control
    {
        public Other_Settings_Selector()
        {
            InitializeComponent();
            Controls.Add(pbShowToggle);
            Controls.Add(pbUpdate);
            Controls.Add(pbSave);
            Controls.Add(pbImport);
            Controls.Add(pbExport);

            //Locations
            int Left = -60;
            pbUpdate.Left = Left;
            Left -= 60;
            pbExport.Left = Left;
            Left -= 60;
            pbImport.Left = Left;
            Left -= 60;
            pbSave.Left = Left;
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
                pbShowToggle.Image = Properties.Resources.ArrowL;
                Height += 25;
                for (int i = 1; i < 80; i++)
                {
                    Width += 3;
                    Refresh();
                }
                if (ToggleVisible != null) ToggleVisible();
            }
            else
            {
                pbShowToggle.Image = Properties.Resources.ArrowR;
                for (int i = 1; i < 80; i++)
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

        public delegate void UpdateDelegate();

        public event UpdateDelegate UpdateClicked;

        public delegate void SaveDelegate();

        public event SaveDelegate SaveClicked;

        public delegate void ImportDelegate();

        public event ImportDelegate ImportClicked;

        public delegate void ExportDelegate();

        public event ExportDelegate ExportClicked;

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

        private void pbUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateClicked != null) UpdateClicked();
            pbShowToggle_Click(null, null);
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            if (SaveClicked != null) SaveClicked();
            pbShowToggle_Click(null, null);
        }

        private void pbImport_Click(object sender, EventArgs e)
        {
            if (ImportClicked != null) ImportClicked();
            pbShowToggle_Click(null, null);
        }

        private void pbExport_Click(object sender, EventArgs e)
        {
            if (ExportClicked != null) ExportClicked();
            pbShowToggle_Click(null, null);
        }
    }
}
