using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Item
    {
        public long id{ get; }
        public long dealerId { get; set; }
        public string name { get; set; }
        public string keywords { get; set; }
        public string description { get; set; }
        public string manufacturer { get; set; }
        public string manufacturingLine { get; set; }
        public decimal cost { get; set; }
        public decimal currentPrice { get; set; }
        public decimal minimumPrice { get; set; }
        public int pricingPlanId { get; set; }
        public bool isAvailable { get; set; }
        public DateTime? soldDate { get; set; }
        public decimal soldPrice { get; set; }
        public bool isShippable { get; set; }
        public long locationId { get;  set; }
        public int quantity { get; set; }

    }
}
