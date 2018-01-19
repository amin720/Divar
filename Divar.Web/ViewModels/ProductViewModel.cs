using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Divar.Core.Entities;

namespace Divar.Web.ViewModels
{
	public class ProductViewModel
	{
		[Required(ErrorMessage = "لطفا یک عنوان مناسب انتخاب کنید")]
		public string ProductName { get; set; }
		[Required(ErrorMessage = "لطفا یک تصویر مناسب انتخاب کنید")]
		public string ImageUrl { get; set; }
		//[Required(ErrorMessage = "لطفا یک قیمت مناسب انتخاب کنید")]
		[DataType(DataType.Currency)]
		public decimal? ProductPrice { get; set; }
		[Required(ErrorMessage = "لطفا توضیحاتی در مورد کالا خود وارد کنید")]
		public string Description { get; set; }
		[Required(ErrorMessage = "لطفا یک شماره تلفن مناسب انتخاب کنید")]
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "لطفا شروع آگهی را مشخص کنید")]
		[DataType(DataType.DateTime)]
		public DateTime CreateDate { get; set; }
		[Required(ErrorMessage = "لطفا انقضا آگهی را مشخص کنید")]
		[DataType(DataType.DateTime)]
		public DateTime ExpiredDate { get; set; }
		[StringLength(4, ErrorMessage = "لطفا فقط سال را وارد کنید با 4 کاراکتر")]
		public string Year { get; set; }

		public int KiloMeters { get; set; }

		public string BrandSelect { get; set; }
		public string ColorSelect { get; set; }
		public string CitySelect { get; set; }
		public string Brand { get; set; }
		public string Color { get; set; }
		public decimal? PriceMax { get; set; }
		public decimal? PriceMin { get; set; }
		public string Price { get; set; }
		public string TypeVehicle { get; set; }
		public string TypeAdv { get; set; }
		public string TypeAdver { get; set; }
		public string City { get; set; }
		public int State { get; set; }
		public int? PageNumber { get; set; }
		public int Id { get; set; }

		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Manufacturer> Manufacturers { get; set; }
		public IEnumerable<Vehicle> Vehicles { get; set; }
		public IEnumerable<Assembler> Assemblers { get; set; }
		public IEnumerable<VehicleType> VehicleTypes { get; set; }
		public IEnumerable<City> Cities { get; set; }
		public IEnumerable<State> States { get; set; }
		public IEnumerable<Color> Colors { get; set; }
		public IEnumerable<Advertisement> Advertisements { get; set; }
		public IEnumerable<AdvertisementType> AdvertisementTypes { get; set; }
		public IEnumerable<AdvertiserType> AdvertiserTypes { get; set; }
		public IEnumerable<Image> Images { get; set; }
	}
}