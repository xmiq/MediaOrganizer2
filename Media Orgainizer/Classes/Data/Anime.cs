using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Data
{
    public class Anime : DataItem
    {
        public Anime()
            : base(Anime.AnimeType)
        {
        }

        private int _Episode;

        public int Episode
        {
            get { return _Episode; }
            set { _Episode = value; }
        }

        public override string ToString()
        {
            return this.Name + "|" + this.Episode;
        }

        public const string AnimeType = "Anime";
    }
}
