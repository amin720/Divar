using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Divar.Core.Entities;
using Divar.Core.Interfaces;
using Divar.Infrastructure.Repository;
using Divar.Web.ViewModels;

namespace Divar.Web.Controllers
{
	[RoutePrefix("Advertisement")]
	[Authorize]
	public class AdvertisementController : Controller
	{
		private readonly IAdvertismentRepository _advertismentRepository;
		private readonly IProductsRepository _productsRepository;
		private readonly IServiceRepository _serviceRepository;
		private readonly IEmploymentRepository _employmentRepository;
		private readonly IVehicleRepository _vehicleRepository;
		private readonly IManufacturerRepository _manufacturerRepository;
		private readonly IAssemblerRepository _assemblerRepository;
		private readonly IColorRepository _colorRepository;
		private readonly ICityRepository _cityRepository;
		private readonly IStateRepository _stateRepository;
		private readonly IImageRepository _imageRepositorysitory;
		private readonly IVehicleTypeRepository _vehicleTypeRepository;
		private readonly IAdvertisementTypeRepository _advertisementTypeRepository;
		private readonly IUserRepository _userRepository;
		private readonly IAdvertiserTypeRepository _advertiserTypeRepository;


		public AdvertisementController()
			: this(new AdvertismentRepository(), new ProductRepository(),new ServiceRepository(), new EmploymentRepository(),
				  new VehicleRepository(),new ManufacturerRepository(),new AssemblerRepository(), new ColorRepository(),
				  new CityRepository(), new StateRepository(),new ImageRepository(), new VehicleTypeRepository(),new AdvertismentTypeRepository(),
				  new UserRepository(), new AdvertiserTypeRepository())
		{
			
		}

		public AdvertisementController(IAdvertismentRepository advertismentRepository, IProductsRepository productsRepository,
			IServiceRepository serviceRepository, IEmploymentRepository employmentRepository,IVehicleRepository vehicleRepository,
			IManufacturerRepository manufacturerRepository, IAssemblerRepository assemblerRepository, IColorRepository colorRepository,
			ICityRepository cityRepository, IStateRepository stateRepository, IImageRepository imageRepository, IVehicleTypeRepository vehicleTypeRepository,
			IAdvertisementTypeRepository advertisementTypeRepository, IUserRepository userRepository, IAdvertiserTypeRepository advertiserTypeRepository)
		{
			_advertismentRepository = advertismentRepository;
			_productsRepository = productsRepository;
			_serviceRepository = serviceRepository;
			_employmentRepository = employmentRepository;
			_vehicleRepository = vehicleRepository;
			_manufacturerRepository = manufacturerRepository;
			_assemblerRepository = assemblerRepository;
			_colorRepository = colorRepository;
			_cityRepository = cityRepository;
			_stateRepository = stateRepository;
			_imageRepositorysitory = imageRepository;
			_vehicleTypeRepository = vehicleTypeRepository;
			_advertisementTypeRepository = advertisementTypeRepository;
			_userRepository = userRepository;
			_advertiserTypeRepository = advertiserTypeRepository;
		}

		// GET: Advertisement
		[Route("")]
		[HttpGet]
		public ActionResult Index()
        {
            return View();
        }

		// GET: Advertisement/Product
		[Route("Product")]
		[HttpGet]
		public async Task<ActionResult> Product()
		{
			var user = await GetloggedInUser();

			var model = new ProductViewModel
			{
				Manufacturers = _manufacturerRepository.GetAll(),
				Assemblers =  _assemblerRepository.GetAll(),
				Colors = _colorRepository.GetAll(),
				Cities = _cityRepository.GetAll(),
				States = _stateRepository.GetAllCityStates(),
				VehicleTypes =  _vehicleTypeRepository.GetAll(),
				AdvertisementTypes = _advertisementTypeRepository.GetAll(),
				PhoneNumber = user.PhoneNumber,
				AdvertiserTypes = _advertiserTypeRepository.GetAll(),

			};
			return View(model);
		}
		// POST: Advertisement/Product
		[Route("Product")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Product(ProductViewModel model, HttpPostedFileBase fileUpload)
		{
			try
			{

			
			var advertisement = new Advertisement();
			var product = new Product();
			var vehicle = new Vehicle();
			var color = new Color();
			var manufacturer = new Manufacturer();
			var image = new Image();
			var user = await GetloggedInUser();

			if (string.IsNullOrEmpty(model.BrandSelect))
			{
				model.BrandSelect = model.Brand;
			}
			else if (string.IsNullOrEmpty(model.Brand))
			{
				model.Brand = _manufacturerRepository.GetAll().SingleOrDefault(m => m.Id == Convert.ToInt32(model.BrandSelect)).Name;
			}

			if (string.IsNullOrEmpty(model.ColorSelect))
			{
				model.ColorSelect = model.Color;
			}
			else if (string.IsNullOrEmpty(model.Color))
			{
				model.Color = _colorRepository.GetAll().SingleOrDefault(m => m.Id == Convert.ToInt32(model.ColorSelect)).Name;
			}

			if (string.IsNullOrEmpty(model.CitySelect))
			{
				model.CitySelect = model.City;
			}
			else if (string.IsNullOrEmpty(model.City))
			{
				model.City = _cityRepository.GetAll().SingleOrDefault(m => m.Id == Convert.ToInt32(model.CitySelect)).Name;
			}

			var modelManufacturer = _manufacturerRepository.GetAll().SingleOrDefault(m => m.Name == model.BrandSelect);
			if (modelManufacturer == null)
			{
				manufacturer.Name = model.Brand;
				_manufacturerRepository.Create(manufacturer);
			}

			var modelColor = _colorRepository.GetAll().SingleOrDefault(c => c.Name == model.ColorSelect);
			if (modelColor == null)
			{
				color.Name = model.Color;
				_colorRepository.Create(color);
			}

			var modelAssembler = _assemblerRepository.GetAll().SingleOrDefault(m => m.Name == model.BrandSelect);
			if (modelAssembler == null)
			{
				var assembler = new Assembler()
				{
					Name = model.Brand
				};
				_assemblerRepository.Create(assembler);
			}

			var modelCity = _cityRepository.GetAll().SingleOrDefault(m => m.Name == model.City);
			if (modelCity == null)
			{
				var city = new City()
				{
					Name = model.City
				};
				_cityRepository.Create(city);
			}

			vehicle.Name = model.ProductName;
			vehicle.Year = model.Year;
			vehicle.ColorID = _colorRepository.GetAll().SingleOrDefault(c => c.Name == model.Color).Id;
			vehicle.ManufacturerID = _manufacturerRepository.GetAll().SingleOrDefault(m => m.Name == model.Brand).Id;
			vehicle.AssemblerID = _assemblerRepository.GetAll().SingleOrDefault(m => m.Name == model.Brand).Id;
			vehicle.VehicleTypeID = _vehicleTypeRepository.GetAll().SingleOrDefault(v => v.Id == Convert.ToInt32(model.TypeVehicle)).Id;

			_vehicleRepository.Create(vehicle);



			advertisement.Description = model.Description;
			advertisement.VehicleID = _vehicleRepository.Get(vehicle.VehicleTypeID, vehicle.ManufacturerID, vehicle.Name).Id;
			advertisement.CityID = _cityRepository.Get(model.City).Id;
			advertisement.UserID = user.Id;
			_advertismentRepository.Create(advertisement);

			product.Name = model.ProductName;
			product.Price = model.ProductPrice;
			product.CreateDate = model.CreateDate;
			product.ExpiredDate = model.ExpiredDate;
			product.KiloMeters = model.KiloMeters;
			product.IdAdvertisement =
				_advertismentRepository.Get(_vehicleRepository.Get(vehicle.VehicleTypeID, vehicle.ManufacturerID, vehicle.Name).Id,
					_cityRepository.Get(model.City).Id).Id;
			product.AdvertisementTypeID = _advertisementTypeRepository.GetAll().SingleOrDefault(adv => adv.Id == Convert.ToInt32(model.TypeAdv)).Id;
			product.AdvertiserTypeID = _advertiserTypeRepository.GetAll().SingleOrDefault(adv => adv.Id == Convert.ToInt32(model.TypeAdver)).Id;
			_productsRepository.Create(product);




			var allowedExtensions = new[] {
				".Jpg", ".png", ".jpg", "jpeg"
			};

			var fileName = Path.GetFileName(fileUpload.FileName);
			var ext = Path.GetExtension(fileUpload.FileName); //getting the extension(ex-.jpg)
			if (allowedExtensions.Contains(ext)) //check what type of extension
			{
				string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extensi
				string myfile = name + "_" + product.Name + ext; //appending the name with id
				// store the file inside ~/project folder(Img)E:\Project-Work\Zahra.Project\Restaurant\Restaurant.Web\assets\images\products\1.png
				var path = Path.Combine(Server.MapPath("~/images/products"), myfile);
				image.Url = "~/images/products/" + myfile;
				image.IdAdvertising = _advertismentRepository.Get(_vehicleRepository.Get(vehicle.VehicleTypeID, vehicle.ManufacturerID, vehicle.Name).Id,
					_cityRepository.Get(model.City).Id).Id;
				_imageRepositorysitory.Create(image);
				fileUpload.SaveAs(path);
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Please choose only Image file");
			}

				return RedirectToAction("Index", "Home");
			}
			catch (Exception e)
			{
				ModelState.AddModelError(String.Empty, e.Message);
				return View();
			}
		}

		[HttpGet]
		[Route("Advertisement/{advId}")]
		public async Task<ActionResult> Adv(int advId)
		{
			var adv = _advertismentRepository.GetAll().SingleOrDefault(a => a.Id == advId);
			var product = _productsRepository.GetAll().SingleOrDefault(p => p.IdAdvertisement == adv.Id);
			var users = await _userRepository.GetAllUsersAsync();
			var vehicle = _vehicleRepository.GetAll().SingleOrDefault(v => v.Id == adv.VehicleID);

			var model = new ProductViewModel
			{
				ProductName = product.Name,
				ProductPrice = product.Price,
				KiloMeters = product.KiloMeters,
				TypeAdv = _advertisementTypeRepository.GetAll().SingleOrDefault(a => a.Id == product.AdvertisementTypeID).Name,
				TypeAdver = _advertiserTypeRepository.GetAll().SingleOrDefault(a => a.Id == product.AdvertisementTypeID).Name,
				ImageUrl = _imageRepositorysitory.GetAll().SingleOrDefault(i => i.IdAdvertising == adv.Id).Url,
				City = _cityRepository.GetAll().SingleOrDefault(c => c.Id == adv.CityID).Name,
				PhoneNumber = users.SingleOrDefault(u => u.Id == adv.UserID).PhoneNumber,
				Color = _colorRepository.GetAll().SingleOrDefault(c => c.Id == vehicle.ColorID).Name,
				Brand = _manufacturerRepository.GetAll().SingleOrDefault(m => m.Id == vehicle.ManufacturerID).Name,
			};

			return View();
		}































		#region Method

		private bool _isDisposed;
		protected override void Dispose(bool disposing)
		{
			if (!_isDisposed)
			{
				_userRepository.Dispose();
			}

			_isDisposed = true;
			base.Dispose(disposing);
		}

		private async Task<UserIdentity> GetloggedInUser()
		{
			return await _userRepository.GetUserByNameAsync(User.Identity.Name);
		}

		#endregion
	}
}