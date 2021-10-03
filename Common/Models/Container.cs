using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
	public class Container
	{
		public long id   { get; } 
		public long dealerId  { get; set; } 
		public string name   { get; set; }
		public string description  { get; set; }
		public int containerType   { get; set; }
    }
}
