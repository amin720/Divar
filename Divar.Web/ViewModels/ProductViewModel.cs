using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Divar.Core.Entities;

namespace Divar.Web.ViewModels
{
	public class ProductViewModel
	{
		public string ProductName { get; set; }
		public string ImageUrl { get; set; }
		public decimal ProductPrice { get; set; }

		public string Brand { get; set; }
		public string Color { get; set; }
		public int? PriceMax { get; set; }
		public int? PriceMin { get; set; }
		public string Price { get; set; }
		public string TypeVehicle { get; set; }
		public int? PageNumber { get; set; }

		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Manufacturer> Manufacturers { get; set; }
		public IEnumerable<Color> Colors { get; set; }
		public IEnumerable<Advertisement> Advertisements { get; set; }

		
	}
}