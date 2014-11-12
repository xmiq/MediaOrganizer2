using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Data
{
    public abstract class DataItem : Item
    {
        public DataItem(string Type) :
            base(Type)
        {
        }

        public Guid ItemId { get; set; }

        public MediaItem Media { get; set; }

        public void LinkContent()
        {
            Media.LinkContent(ItemId);
        }

        public void UnlinkContent()
        {
            Media.UnlinkContent(ItemId);
        }
    }
}
