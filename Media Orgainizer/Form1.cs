using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Media_Orgainizer.Classes.GUI;
using Media_Orgainizer.Classes.Data;
using Media_Orgainizer.Classes.Misc;
using System.Threading;

namespace Media_Orgainizer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            if (!DataManagment.Loaded) DataManagment.Load();
            InitializeComponent();
            
            //Data Item Selector Events
            data_Item_Selector1.SeriesClicked += data_Item_Selector1_SeriesClicked;
            data_Item_Selector1.MovieClicked += data_Item_Selector1_MovieClicked;
            data_Item_Selector1.BookClicked += data_Item_Selector1_BookClicked;
            data_Item_Selector1.AnimeClicked += data_Item_Selector1_AnimeClicked;
            data_Item_Selector1.MangaClicked += data_Item_Selector1_MangaClicked;
            data_Item_Selector1.MusicClicked += data_Item_Selector1_MusicClicked;
            data_Item_Selector1.ToggleVisible += data_Item_Selector1_ToggleVisible;
            data_Item_Selector1.ToggleInvisible += data_Item_Selector1_ToggleInvisible;

            //Media Categories Selector Properties and Events
            media_Categories1.ExpandedHeight = Height - 70;
            media_Categories1.SelectedItemChange += media_Categories1_SelectedItemChange;
            media_Categories1.ToggleVisible += media_Categories1_ToggleVisible;
            media_Categories1.ToggleInvisible += media_Categories1_ToggleInvisible;

            ////Other Settings Selector Events
            other_Settings_Selector1.ToggleVisible += other_Settings_Selector1_ToggleVisible;
            other_Settings_Selector1.ToggleInvisible += other_Settings_Selector1_ToggleInvisible;
            other_Settings_Selector1.UpdateClicked += other_Settings_Selector1_UpdateClicked;
            other_Settings_Selector1.SaveClicked += other_Settings_Selector1_SaveClicked;
            other_Settings_Selector1.ImportClicked += other_Settings_Selector1_ImportClicked;
            other_Settings_Selector1.ExportClicked += other_Settings_Selector1_ExportClicked;

            new Thread(UpdateProgram).Start();
        }

        void other_Settings_Selector1_ExportClicked()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataManagment.Save(fbd.SelectedPath);
                MessageBox.Show("Exported Successfully");
            }
        }

        void other_Settings_Selector1_ImportClicked()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataManagment.Load(fbd.SelectedPath);
                DataManagment.Save();
                MessageBox.Show("Imported Successfully");
            }
        }

        void other_Settings_Selector1_SaveClicked()
        {
            DataManagment.Save();
            tsslNotification.Text = "Saved Successfully";
            tsslNotification.Visible = true;
            new Thread(new ParameterizedThreadStart(HideToolStripTimeout)).Start(tsslNotification);
        }

        void other_Settings_Selector1_UpdateClicked()
        {
            new Thread(UpdateProgram).Start();
        }

        void other_Settings_Selector1_ToggleInvisible()
        {
            Controls.SetChildIndex(data_Item_Selector1, 6);
        }

        void other_Settings_Selector1_ToggleVisible()
        {
            other_Settings_Selector1.BringToFront();
            if (!data_Item_Selector1.Toggle) data_Item_Selector1.Toggle = false;
            if (!media_Categories1.Toggle) media_Categories1.Toggle = false;
        }

        void media_Categories1_ToggleInvisible()
        {
            Controls.SetChildIndex(data_Item_Selector1, 4);
        }

        void media_Categories1_ToggleVisible()
        {
            media_Categories1.BringToFront();
            if (!data_Item_Selector1.Toggle) data_Item_Selector1.Toggle = false;
            if (!other_Settings_Selector1.Toggle) other_Settings_Selector1.Toggle = false;
        }

        void media_Categories1_SelectedItemChange(MediaItem mi)
        {
            List<DataItem> List = new List<DataItem>();
            List<Control> ControlList = new List<Control>();
            foreach (Guid g in mi.List)
            {
                if (Media.Content.Find((itm) => itm.ItemId == g).Name == null)
                {
                    Media.RemoveContent(g);
                    media_Categories1_SelectedItemChange(mi);
                    spContent.Refresh();
                    return;
                }
                else List.Add(Media.Content.Find((itm) => itm.ItemId == g));
            }
            foreach (DataItem di in List.OrderBy((x) => x.Name))
            {
                switch (di.Type)
                {
                    case Series.SeasonType: ControlList.Add(NewSeries(di as Series));
                        break;
                    case Movie.MovieType: ControlList.Add(NewMovie(di as Movie));
                        break;
                    case Book.BookType: ControlList.Add(NewBook(di as Book));
                        break;
                    case Anime.AnimeType: ControlList.Add(NewAnime(di as Anime));
                        break;
                    case Manga.MangaType: ControlList.Add(NewManga(di as Manga));
                        break;
                    case Music.MusicType: ControlList.Add(NewMusic(di as Music));
                        break;
                }
            }
            spContent.Controls.Clear();
            spContent.Controls.AddRange(ControlList.ToArray());
            Text = "Media Organizer 2: " + mi.Name;
        }

        void data_Item_Selector1_ToggleInvisible()
        {
            Controls.SetChildIndex(data_Item_Selector1, 3);
        }

        void data_Item_Selector1_ToggleVisible()
        {
            data_Item_Selector1.BringToFront();
            if (!media_Categories1.Toggle) media_Categories1.Toggle = false;
            if (!other_Settings_Selector1.Toggle) other_Settings_Selector1.Toggle = false;
        }

        void data_Item_Selector1_MusicClicked()
        {
            spContent.Controls.Add(NewMusic());
        }

        void data_Item_Selector1_MangaClicked()
        {
            spContent.Controls.Add(NewManga());
        }

        void data_Item_Selector1_AnimeClicked()
        {
            spContent.Controls.Add(NewAnime());
        }

        void data_Item_Selector1_BookClicked()
        {
            spContent.Controls.Add(NewBook());
        }

        void data_Item_Selector1_MovieClicked()
        {
            spContent.Controls.Add(NewMovie());
        }

        void data_Item_Selector1_SeriesClicked()
        {
            spContent.Controls.Add(NewSeries());
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataManagment.Save();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            media_Categories1_SelectedItemChange(media_Categories1.SelectedItem);
        }

        private Series_Control NewSeries(Series s = null)
        {
            Series_Control sc = (s == null) ? new Series_Control(media_Categories1.SelectedItem) : new Series_Control(s);
            sc.Width = spContent.Width - 10;
            sc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            sc.SaveSucceded += sc_SaveSucceded;
            sc.Deleted += sc_Deleted;
            return sc;
        }

        private Movie_Control NewMovie(Movie m = null)
        {
            Movie_Control mc = (m == null) ? new Movie_Control(media_Categories1.SelectedItem) : new Movie_Control(m);
            mc.Width = spContent.Width - 10;
            mc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            mc.SaveSucceded += sc_SaveSucceded;
            mc.Deleted += sc_Deleted;
            return mc;
        }

        private Book_Control NewBook(Book b = null)
        {
            Book_Control bc = (b == null) ? new Book_Control(media_Categories1.SelectedItem) : new Book_Control(b);
            bc.Width = spContent.Width - 10;
            bc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            bc.SaveSucceded += sc_SaveSucceded;
            bc.Deleted += sc_Deleted;
            return bc;
        }

        private Anime_Control NewAnime(Anime a = null)
        {
            Anime_Control ac = (a == null) ? new Anime_Control(media_Categories1.SelectedItem) : new Anime_Control(a);
            ac.Width = spContent.Width - 10;
            ac.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            ac.SaveSucceded += sc_SaveSucceded;
            ac.Deleted += sc_Deleted;
            return ac;
        }
        
        private Manga_Control NewManga(Manga m = null)
        {
            Manga_Control mc = (m == null) ? new Manga_Control(media_Categories1.SelectedItem) : new Manga_Control(m);
            mc.Width = spContent.Width - 10;
            mc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            mc.SaveSucceded += sc_SaveSucceded;
            mc.Deleted += sc_Deleted;
            return mc;
        }

        private Music_Control NewMusic(Music m = null)
        {
            Music_Control mc = (m == null) ? new Music_Control(media_Categories1.SelectedItem) : new Music_Control(m);
            mc.Width = spContent.Width - 10;
            mc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            mc.SaveSucceded += sc_SaveSucceded;
            mc.Deleted += sc_Deleted;
            return mc;
        }

        void sc_Deleted()
        {
            media_Categories1_SelectedItemChange(media_Categories1.SelectedItem);
        }

        void sc_SaveSucceded()
        {
            tsslNotification.Text = "Saved Successfully";
            tsslNotification.Visible = true;
            sc_Deleted();
            new Thread(new ParameterizedThreadStart(HideToolStripTimeout)).Start(tsslNotification);
        }

        private void HideToolStripTimeout(Object o)
        {
            Thread.Sleep(1000);
            (o as ToolStripItem).Visible = false;
        }

        private void UpdateProgram()
        {
            while (!this.IsHandleCreated) System.Threading.Thread.Sleep(100);
            if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tsslNotification.Visible = true));
            if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tspbUpdate.Visible = true));
            if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tsslNotification.Text = "Loading Servers"));
            Updates.LoadedServers += Updates_LoadedServers;
            Updates.CheckedServers += Updates_CheckedServers;
            Updates.UpdateListBuilt += Updates_UpdateListBuilt;
            Updates.UpdatesDownloaded += Updates_UpdatesDownloaded;
            Updates.SavingUpdateList += Updates_SavingUpdateList;
            Updates.Update();
        }

        void Updates_LoadedServers()
        {
            if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tsslNotification.Text = "Checking Servers"));
        }

        void Updates_CheckedServers()
        {
            if (Updates.Error == UpdateError.NoValidServer)
            {
                if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tsslNotification.Text = "Server Error Contact Admin"));
                Thread.Sleep(4000);
                if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tsslNotification.Visible = false));
                if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tspbUpdate.Visible = false));
            }
            else if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tsslNotification.Text = "Building Update List"));
        }

        void Updates_UpdateListBuilt()
        {
            if (Updates.Error == UpdateError.NoUpdates)
            {
                if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tsslNotification.Text = "No Update Available"));
                Thread.Sleep(1000);
                if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tsslNotification.Visible = false));
                if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tspbUpdate.Visible = false));
            }
            else if (!IsDisposed)  statusStrip1.Invoke((MethodInvoker)(() => tsslNotification.Text = "Downloading Updates"));
        }

        void Updates_UpdatesDownloaded()
        {
            if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tsslNotification.Text = "Saving Update List"));
        }

        void Updates_SavingUpdateList()
        {
            if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tsslNotification.Text = "Update available, close progran to install"));
            if (!IsDisposed) statusStrip1.Invoke((MethodInvoker)(() => tspbUpdate.Visible = false));
            this.FormClosing += frmMain_FormClosing1;
        }

        private void frmMain_FormClosing1(object sender, FormClosingEventArgs e)
        {
            Process.Start("Implementer.exe");
        }
    }
}
