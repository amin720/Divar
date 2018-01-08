using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Divar.Web.Models
{
	public class ItemVehicle
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public string UserId { get; set; }
	}
}