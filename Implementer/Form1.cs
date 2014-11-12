using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Implementer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            string[] files = Directory.GetFiles(path);
            progressBar1.Maximum = files.Count() + 1;
            bool closed = false;
            while (!closed)
            {
                bool breaked = false;
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.Contains("Media Organizer 2.exe"))
                    {
                        clsProcess.Close();
                        breaked = true;
                        break;
                    }
                }
                if (breaked)
                {
                    Thread.Sleep(10);
                    break;
                }
                closed = true;
            }
            progressBar1.Value += 1;
            
            foreach (string s in files)
            {
                if (s.EndsWith("x"))
                {
                    string oldPath = s.Substring(0, s.Length - 1);
                    File.Delete(oldPath);
                    File.Move(s, oldPath);
                }
                progressBar1.Value += 1;
            }
            Process.Start("Media Organizer 2.exe");
            Close();
        }
    }
}
