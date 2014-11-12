using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Data
{
    public class Manga : DataItem
    {
        public Manga()
            : base(Manga.MangaType)
        {
        }

        public string ISBN { get; set; }

        public override string ToString()
        {
            return this.Name + "|" + ISBN;
        }

        public const string MangaType = "Manga";
    }
}
