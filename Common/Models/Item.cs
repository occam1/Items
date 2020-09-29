using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Item
    {
        public int Id{ get; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public float ItemCost { get; set; }
        public float ItemPrice { get; set; }
        public string? ItemPictureLocation { get; set; }
        public DateTime? ItemSoldDate { get; set; }
    }
}
