using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Data
{
    public abstract class Item
    {
        public Item(string Type)
        {
            _Type = Type;
        }

        public string Name { get; set; }

        private string _Type;

        public string Type
        {
            get { return _Type; }
        }
    }
}
