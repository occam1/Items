using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
	public class ContainerPlace
	{
		public long id { get; }
		public long dealerId { get; set; }
		public long containerId { get; set; }
		public long furnitureId { get; set; }
		public long surfaceId { get; set; }
		public long surfaceAreaId { get; set; }

	}
}