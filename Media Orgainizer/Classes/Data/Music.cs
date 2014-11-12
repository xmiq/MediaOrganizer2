using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Data
{
    public class Music : DataItem
    {
        public Music()
            : base(Music.MusicType)
        {
        }

        public string Album { get; set; }

        public string Artist { get; set; }

        public override string ToString()
        {
            return this.Name + "|" + Album + "|" + Artist;
        }

        public const string MusicType = "Music";
    }
}
