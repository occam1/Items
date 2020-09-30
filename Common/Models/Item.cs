using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Item
    {
        public long Id{ get; }
        public long DealerId { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturingLine { get; set; }
        public float Cost { get; set; }
        public float CurrentPrice { get; set; }
        public float MinimumPrice { get; set; }
        public int PricingPlanId { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? SoldDate { get; set; }
        public float SoldPrice { get; set; }
        public bool Shippable { get; set; }
        public long LocationId { get; set; }
        public int Quantity { get; set; }



    }
}
