using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Data
{
    public class Book : DataItem
    {
        public Book()
            : base(Book.BookType)
        {
        }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public override string ToString()
        {
            return this.Name + "|" + Author + "|" + ISBN;
        }

        public const string BookType = "Book";
    }
}
