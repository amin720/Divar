using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Divar.Core.Entities;
using Divar.Web.ViewModels;

namespace Divar.Web.Service
{
	public class ProductBusinessLogic
	{
		public ProductViewModel GetProducts(ProductViewModel searchModel)
		{
			using (var db = new DivarEntities())
			{
				var result = new ProductViewModel();

				if (searchModel != null)
				{
					if (!string.IsNullOrEmpty(searchModel.Brand))
						result.Advertisements = db.Advertisements.Where(x => x.Vehicle.Manufacturer.Name.Contains(searchModel.Brand));
						//result = result.Where(x => x.Advertisement.Vehicle.Manufacturer.Name.Contains(searchModel.Brand));
					if (!string.IsNullOrEmpty(searchModel.Color))
						result.Advertisements = db.Advertisements.Where(x => x.Vehicle.Color.Name.Contains(searchModel.Color));
					//result = result.Where(x => x.Advertisement.Vehicle.Color.Name.Contains(searchModel.Color));
					if (searchModel.PriceMin.HasValue)
						result.Products = db.Products.Where(x => x.Price >= searchModel.PriceMin);
					//result = result.Where(x => x.Price >= searchModel.PriceMin);
					if (searchModel.PriceMax.HasValue)
						result.Products = db.Products.Where(x => x.Price <= searchModel.PriceMax);
					//result = result.Where(x => x.Price <= searchModel.PriceMax);
				}
				return result;
			}
		}
	}
}