using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Orgainizer.Classes.Data
{
    public class MediaItem : Item
    {
        public MediaItem()
            : base(MediaItem.ItemType)
        {
        }

        public void LinkContent(Guid id)
        {
            _Content.Add(id);
        }

        public void UnlinkContent(Guid id)
        {
            _Content.Remove(id);
        }

        private List<Guid> _Content = new List<Guid>();

        public List<Guid> List
        {
            get
            {
                return _Content;
            }
        }

        public const string ItemType = "Media";
    }
}
