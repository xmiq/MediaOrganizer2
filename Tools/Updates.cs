using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public enum UpdateError { NoError, NoValidServer, NoUpdates }

    public class Updates
    {
        public Updates()
        {
            ServerList = new List<string>();
            ProgramList = new Dictionary<string, string>();
            LocalList = new Dictionary<string, string>();
            DownloadList = new Dictionary<string, bool>();
            Error = UpdateError.NoError;
        }

        private string ServerPath;
        private List<string> ServerList;
        private Dictionary<string, string> ProgramList;
        private Dictionary<string, string> LocalList;
        private Dictionary<string, bool> DownloadList;
        public UpdateError Error { get; set; }

        private void LoadServers()
        {
            ServerList.AddRange(File.ReadAllLines("Servers.txt"));
        }

        private void SelectServer()
        {
            WebClient wc = new WebClient();
            string tempFile = Path.GetTempFileName();
            foreach (string s in ServerList)
            {
                wc.DownloadFile(s, tempFile);
                List<string> temp = new List<string>();
                temp.AddRange(File.ReadAllLines(tempFile));
                foreach (string sTemp in temp)
                {
                    string[] split = sTemp.Split('|');
                    ProgramList.Add(split[0], split[1]);
                }
                ServerPath = s.Remove(s.IndexOf("List.txt"));
                break;
            }
            if (ProgramList.Count == 0) Error = UpdateError.NoValidServer;
            File.Delete(tempFile);
        }

        private void ReadLocalList()
        {
            List<string> temp = new List<string>();
            temp.AddRange(File.ReadAllLines("List.txt"));
            foreach (string sTemp in temp)
            {
                string[] split = sTemp.Split('|');
                LocalList.Add(split[0], split[1]);
            }
        }

        private void Compare()
        {
            bool noUpdate = true;
            foreach (string s in ProgramList.Keys)
            {
                if (LocalList.ContainsKey(s)) DownloadList.Add(s, ProgramList[s] != LocalList[s]);
                else DownloadList.Add(s, true);
                if (DownloadList[s] == true) noUpdate = false;
            }
            if (noUpdate) Error = UpdateError.NoUpdates;
        }

        private void Download()
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
        }

        private void UpdateLocalList()
        {
            List<string> temp = new List<string>();
            foreach (string s in ProgramList.Keys)
            {
                temp.Add(s + "|" + ProgramList[s]);
            }
            File.WriteAllLines("List.txt", temp.ToArray());
        }

        public void Update()
        {
            LoadServers();
            SelectServer();
            if (Error == UpdateError.NoError) ReadLocalList();
            if (Error == UpdateError.NoError) Compare();
            if (Error == UpdateError.NoError) Download();
            if (Error == UpdateError.NoError) UpdateLocalList();
        }
    }
}
