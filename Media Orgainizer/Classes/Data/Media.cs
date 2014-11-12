using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Data
{
    public static class Media
    {
        private static List<MediaItem> _Media = new List<MediaItem>();
        private static List<DataItem> _Content = new List<DataItem>();

        public static void AddMedia(string name)
        {
            if (!SaveList.Contains(name))
            _Media.Add(new MediaItem()
            {
                Name = name
            });
        }

        public static void AddMediaRange(string[] name)
        {
            Array.ForEach(name, ((s) => AddMedia(s)));
        }

        public static void AddContent(DataItem di)
        {
            _Content.Add(di);
            di.LinkContent();
        }

        public static MediaItem ParseMedia(string media)
        {
            foreach (MediaItem mi in _Media) if (mi.Name == media) return mi;
            return null;
        }

        public static void RemoveMedia(string name)
        {
            RemoveMedia(ParseMedia(name));
        }

        public static void RemoveMedia(MediaItem mi)
        {
            foreach (Guid g in mi.List) _Content.RemoveAll((itm) => itm.ItemId == g);
            _Media.Remove(mi);
        }

        public static void RemoveContent(Guid g)
        {
            _Content.Find((itm) => itm.ItemId == g).UnlinkContent();
            _Content.RemoveAll((itm) => itm.ItemId == g);
        }

        public static List<string> List
        {
            get
            {
                List<string> toReturn = new List<string>();
                _Media.ForEach((mi) => toReturn.Add(mi.Name));
                return toReturn;
            }
        }

        public static string SaveList
        {
            get
            {
                string toReturn = "";
                foreach (MediaItem mi in _Media) toReturn += mi.Name + ",";
                toReturn = toReturn.TrimEnd(',');
                return toReturn;
            }
        }

        public static Dictionary<string, string> BuildContentForSaving()
        {
            Dictionary<string, string> toReturn = new Dictionary<string, string>();
            foreach (MediaItem mi in _Media)
            {
                toReturn.Add(mi.Name, "");
                foreach (Guid g in mi.List)
                {
                    DataItem di = _Content.Find((itm) => itm.ItemId == g);
                    if (string.IsNullOrEmpty(di.Name)) { }
                    else
                    {
                        switch (di.Type)
                        {
                            case Series.SeasonType: Series s = di as Series;
                                toReturn[mi.Name] += "s|" + s.ToString() + ",";
                                break;
                            case Movie.MovieType: Movie m = di as Movie;
                                toReturn[mi.Name] += "m|" + m.ToString() + ",";
                                break;
                            case Book.BookType: Book b = di as Book;
                                toReturn[mi.Name] += "b|" + b.ToString() + ",";
                                break;
                            case Anime.AnimeType: Anime a = di as Anime;
                                toReturn[mi.Name] += "a|" + a.ToString() + ",";
                                break;
                            case Manga.MangaType: Manga ma = di as Manga;
                                toReturn[mi.Name] += "ma|" + ma.ToString() + ",";
                                break;
                            case Music.MusicType: Music mu = di as Music;
                                toReturn[mi.Name] += "mu|" + mu.ToString() + ",";
                                break;
                        }
                    }
                }
                toReturn[mi.Name] = toReturn[mi.Name].TrimEnd(',');
            }
            return toReturn;
        }

        public static List<DataItem> Content
        {
            get
            {
                return _Content;
            }
        }

        public static List<MediaItem> MediaList
        {
            get
            {
                return _Media;
            }
        }

        public static bool isEmpty
        {
            get
            {
                return _Media.Count == 0;
            }
        }
    }
}
