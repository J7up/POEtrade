using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace POEtrade
{
    [Table(Name = "Item")]
    public class Item
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_item { get; set; }
        [Column]
        public string name { get; set; }
        [Column]
        public int category { get; set; }
        [Column]
        public int rarity { get; set; }
        [Column]
        public int socket { get; set; }
        [Column]
        public int color { get; set; }
        [Column]
        public int link { get; set; }
        [Column]
        public int quantity { get; set; }
        [Column]
        public int price { get; set; }
    }
}
