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
    public partial class StackingPanel : Panel
    {
        public StackingPanel()
        {
            InitializeComponent();
        }

        int totalControlHeight = 0;

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void StackingPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Width = Width;
            e.Control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            e.Control.Top = totalControlHeight;
            totalControlHeight += e.Control.Height + 10;
        }

        private void StackingPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            totalControlHeight = 0;
            foreach (Control c in Controls)
            {
                c.Top = totalControlHeight;
                totalControlHeight += c.Height + 10;
            }
        }

        private void StackingPanel_SizeChanged(object sender, EventArgs e)
        {
            if (VerticalScroll.Visible)
            {
                if (Controls.Count > 0)
                if (Controls[0].Width == Width)
                foreach (Control c in Controls)
                {
                    c.Width = Width - 20;
                }
            }
            else
            {
                if (Controls.Count > 0)
                if (Controls[0].Width == Width - 20)
                foreach (Control c in Controls)
                {
                    c.Width = Width;
                }
            }
        }
    }
}
