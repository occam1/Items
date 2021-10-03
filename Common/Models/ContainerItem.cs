using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
   public class ContainerItem
	{
		public long id { get; }
		public long dealerId { get; set; }
		public long containerId { get; set; }
		public long itemId { get; set; }
	}
}
