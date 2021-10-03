using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
	public class Furniture
    {
		public int id { get; }   
		public int personId { get; set; }
		public string description { get; set; }
		public int furnitureType { get; set; }
		public short positionFromLeft { get; set; }
		public short positionFromFront { get; set; }
		public short positionFromBottom { get; set; }
		public decimal width { get; set; }
		public decimal depth { get; set; }
		public decimal height { get; set; }
	}
}
