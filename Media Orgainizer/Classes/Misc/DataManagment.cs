using Media_Orgainizer.Classes.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Misc
{
    public static class DataManagment
    {
        private static bool isLoaded = false;

        /// <summary>
        /// Checks if data is filled
        /// </summary>
        public static bool Loaded
        {
            get
            {
                return isLoaded;
            }
        }

        /// <summary>
        /// Loads information
        /// </summary>
        public static void Load()
        {
            Load("items");
        }

        /// <summary>
        /// Loads information
        /// </summary>
        /// <param name="directory">Directory to load from.</param>
        public static void Load(string directory)
        {
            if (Directory.Exists(directory))
            {
                if (File.Exists(directory + Path.DirectorySeparatorChar + "media.txt"))
                {
                    string media = File.ReadAllText(directory + Path.DirectorySeparatorChar + "media.txt");
                    if (media != "")
                    {
                        string[] mediaItems = media.Split(',');
                        Media.AddMediaRange(mediaItems);
                    }
                }
                foreach (string s in Media.List)
                {
                    MediaItem mI = Media.ParseMedia(s);
                    if (File.Exists(directory + Path.DirectorySeparatorChar + s + ".txt"))
                    {
                        string media = File.ReadAllText(directory + Path.DirectorySeparatorChar + s + ".txt");
                        if (media != "")
                        {
                            string[] mediaItems = media.Split(',');
                            foreach (string mi in mediaItems)
                            {
                                string[] mic = mi.Split('|');
                                switch (mic[0])
                                {
                                    case "s":
                                        Media.AddContent(new Series()
                                        {
                                            Name = mic[1],
                                            Season = Convert.ToInt32(mic[2]),
                                            Episode = Convert.ToInt32(mic[3]),
                                            ItemId = Guid.NewGuid(),
                                            Media = mI
                                        });
                                        break;
                                    case "m":
                                        Media.AddContent(new Movie()
                                        {
                                            Name = mic[1],
                                            ItemId = Guid.NewGuid(),
                                            Media = mI
                                        });
                                        break;
                                    case "b":
                                        Media.AddContent(new Book()
                                        {
                                            Name = mic[1],
                                            Author = mic[2],
                                            ISBN = mic[3],
                                            ItemId = Guid.NewGuid(),
                                            Media = mI
                                        });
                                        break;
                                    case "a":
                                        Media.AddContent(new Anime()
                                        {
                                            Name = mic[1],
                                            Episode = Convert.ToInt32(mic[2]),
                                            ItemId = Guid.NewGuid(),
                                            Media = mI
                                        });
                                        break;
                                    case "ma":
                                        Media.AddContent(new Manga()
                                        {
                                            Name = mic[1],
                                            ISBN = mic[2],
                                            ItemId = Guid.NewGuid(),
                                            Media = mI
                                        });
                                        break;
                                    case "mu":
                                        Media.AddContent(new Music()
                                        {
                                            Name = mic[1],
                                            Album = mic[2],
                                            Artist = mic[3],
                                            ItemId = Guid.NewGuid(),
                                            Media = mI
                                        });
                                        break;
                                    case "": break;
                                    default:
                                        Media.AddContent(new Series()
                                        {
                                            Name = mic[0],
                                            Season = Convert.ToInt32(mic[1]),
                                            Episode = Convert.ToInt32(mic[2]),
                                            ItemId = Guid.NewGuid(),
                                            Media = mI
                                        });
                                        break;
                                }
                            }
                            isLoaded = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Saves the information
        /// </summary>
        public static void Save()
        {
            Save("items");
        }

        /// <summary>
        /// Saves the information
        /// </summary>
        /// <param name="directory">Directory to save information to</param>
        public static void Save(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(directory + Path.DirectorySeparatorChar + "media.txt"))
            {
                FileStream s = File.Create(directory + Path.DirectorySeparatorChar + "media.txt");
                s.Close();
            }

            foreach (string s in Directory.GetFiles(directory)) File.Delete(s);

            File.WriteAllText(directory + Path.DirectorySeparatorChar + "media.txt", Media.SaveList);
            Dictionary<string, string> mediaContent = Media.BuildContentForSaving();
            foreach (string s in mediaContent.Keys)
            {
                File.WriteAllText(directory + Path.DirectorySeparatorChar + s + ".txt", mediaContent[s]);
            }
        }
    }
}
