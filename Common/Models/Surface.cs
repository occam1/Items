using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
	public class Surface
    {
		public long id  {get;}
		public long personId {get; set;}
		public long furnitureId  {get; set;}
		public string description  {get; set;}
		public decimal width {get; set;} 
		public decimal depth {get; set;} 
		public short positionFromBottom   {get; set;}
    }
}
