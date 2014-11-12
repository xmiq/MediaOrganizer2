using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Data
{
    public class Series : DataItem
    {
        public Series()
            : base(Series.SeasonType)
        {
        }

        private int _Season;

        public int Season
        {
            get { return _Season; }
            set { _Season = value; }
        }
        private int _Episode;

        public int Episode
        {
            get { return _Episode; }
            set { _Episode = value; }
        }

        public override string ToString()
        {
            return this.Name + "|" + this.Season + "|" + this.Episode;
        }

        public const string SeasonType = "Series";
    }
}
