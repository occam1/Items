using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
	public class ItemPicture
    {
		public long id { get; }
		public long dealerId { get; set; }
		public long itemId { get; set; }
		public string altText { get; set; }
		public string caption1 { get; set; }
		public string caption2 { get; set; }
		public string path { get; set; }
	}
}
