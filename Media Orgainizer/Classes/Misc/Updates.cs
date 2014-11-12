using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Misc
{
    public enum UpdateError { NoError, NoValidServer, NoUpdates }

    public static class Updates
    {
        private static string ServerPath;
        private static bool DownloadAll;
        private static List<string> ServerList;
        private static Dictionary<string, string> ProgramList;
        private static Dictionary<string, string> LocalList;
        private static Dictionary<string, bool> DownloadList;
        public static UpdateError Error { get; set; }
        public  delegate void MessageDelegate();
        public static event MessageDelegate LoadedServers;
        public static event MessageDelegate CheckedServers;
        public static event MessageDelegate UpdateListBuilt;
        public static event MessageDelegate UpdatesDownloaded;
        public static event MessageDelegate SavingUpdateList;
        public static event MessageDelegate UpdateAvailable;

        private static void LoadServers()
        {
            if (!File.Exists("Servers.txt")) 
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(Properties.Settings.Default.EmergencyServer, "Servers.txt");
            }
            ServerList.AddRange(File.ReadAllLines("Servers.txt"));
            if (LoadedServers != null) LoadedServers();
        }

        private static void SelectServer()
        {
            WebClient wc = new WebClient();
            string tempFile = Path.GetTempFileName();
            foreach (string s in ServerList)
            {
                wc.DownloadFile(s, tempFile);
                foreach (string sTemp in File.ReadAllLines(tempFile))
                {
                    string[] split = sTemp.Split('|');
                    ProgramList.Add(split[0], split[1]);
                }
                ServerPath = s.Remove(s.IndexOf("List.txt"));
                break;
            }
            if (ProgramList.Count == 0) Error = UpdateError.NoValidServer;
            File.Delete(tempFile);
            if (CheckedServers != null) CheckedServers();
        }

        private static void ReadLocalList()
        {
            if (File.Exists("List.txt"))
            {
                foreach (string sTemp in File.ReadAllLines("List.txt"))
                {
                    string[] split = sTemp.Split('|');
                    LocalList.Add(split[0], split[1]);
                }
            }
            else DownloadAll = true;
        }

        private static void Compare()
        {
            bool noUpdate = true;
            foreach (string s in ProgramList.Keys)
            {
                if (DownloadAll)
                {
                    DownloadList.Add(s, true);
                    noUpdate = false;
                }
                else
                {
                    if (LocalList.ContainsKey(s)) DownloadList.Add(s, ProgramList[s] != LocalList[s]);
                    else DownloadList.Add(s, true);
                    if (DownloadList[s] == true) noUpdate = false;
                }
            }
            if (noUpdate) Error = UpdateError.NoUpdates;
            if (UpdateListBuilt != null) UpdateListBuilt();
        }

        private static void Download()
        {
            WebClient wc = new WebClient();
            foreach (string s in DownloadList.Keys)
            {
                if (DownloadList[s])
                {
                    if (s == "Implementer.exe")
                    {
                        File.Delete(s);
                        wc.DownloadFile(ServerPath + s, s);
                    }
                    else wc.DownloadFile(ServerPath + s, s + "x");
                }
            }
            if (UpdatesDownloaded != null) UpdatesDownloaded();
        }

        private static void UpdateLocalList()
        {
            List<string> temp = new List<string>();
            foreach (string s in ProgramList.Keys)
            {
                temp.Add(s + "|" + ProgramList[s]);
            }
            File.WriteAllLines("List.txt", temp.ToArray());
            if (SavingUpdateList != null) SavingUpdateList();
        }

        public static void Update()
        {
            ServerList = new List<string>();
            ProgramList = new Dictionary<string, string>();
            LocalList = new Dictionary<string, string>();
            DownloadList = new Dictionary<string, bool>();
            Error = UpdateError.NoError;
            LoadServers();
            SelectServer();
            if (Error == UpdateError.NoError) ReadLocalList();
            if (Error == UpdateError.NoError) Compare();
            if (Error == UpdateError.NoError) Download();
            if (Error == UpdateError.NoError) UpdateLocalList();
            if (Error == UpdateError.NoError && UpdateAvailable != null) UpdateAvailable();
        }
    }
}
