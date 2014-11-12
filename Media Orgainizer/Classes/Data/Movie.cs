using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Data
{
    public class Movie : DataItem
    {
        public Movie()
            : base(Movie.MovieType)
        {
        }

        public override string ToString()
        {
            return this.Name;
        }

        public const string MovieType = "Movie";
    }
}
