using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Divar.Core.Interfaces;
using Divar.Infrastructure.Repository;
using Divar.Web.Service;
using Divar.Web.ViewModels;

namespace Divar.Web.Controllers
{
	[RoutePrefix("")]
    public class HomeController : Controller
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


		public HomeController()
			: this(new AdvertismentRepository(), new ProductRepository(), new ServiceRepository(), new EmploymentRepository(),
				  new VehicleRepository(), new ManufacturerRepository(), new AssemblerRepository(), new ColorRepository(),
				  new CityRepository(), new StateRepository(), new ImageRepository(), new VehicleTypeRepository(), new AdvertismentTypeRepository(),
				  new UserRepository(), new AdvertiserTypeRepository())
		{

		}

		public HomeController(IAdvertismentRepository advertismentRepository, IProductsRepository productsRepository,
			IServiceRepository serviceRepository, IEmploymentRepository employmentRepository, IVehicleRepository vehicleRepository,
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

		// GET: Home
		[Route("")]
		[HttpGet]
		[AllowAnonymous]
		public ActionResult Index()

		{
			var model = new ProductViewModel
			{
				Advertisements = _advertismentRepository.GetAll(),
				Images = _imageRepositorysitory.GetAll(),
				Products = _productsRepository.GetAll(),
				Manufacturers = _manufacturerRepository.GetAll(),
				Colors = _colorRepository.GetAll(),
				PriceMin = _productsRepository.GetAll().Min(p => p.Price),
				PriceMax = _productsRepository.GetAll().Max(p => p.Price),
			};
			
            return View(model);
        }

	    // POST: Home
	    [Route("")]
	    [HttpPost]
	    [AllowAnonymous]
	    public ActionResult Index(ProductViewModel searchModel)
	    {
			//var business = new ProductBusinessLogic();
			//var search = business.GetProducts(searchModel);

			//search.Manufacturers = _manufacturerRepository.GetAll();
			//search.Colors = _colorRepository.GetAll();
			//search.PriceMin = _productsRepository.GetAll().Min(p => p.Price);
			//search.PriceMax = _productsRepository.GetAll().Max(p => p.Price);

			var model = new ProductViewModel
			{
				Advertisements = _advertismentRepository.GetAll(),
				Images = _imageRepositorysitory.GetAll(),
				Products = _productsRepository.GetAll(),
				Manufacturers = _manufacturerRepository.GetAll(),
				Colors = _colorRepository.GetAll(),
				PriceMin = _productsRepository.GetAll().Min(p => p.Price),
				PriceMax = _productsRepository.GetAll().Max(p => p.Price),
			};

		    

			if (!string.IsNullOrEmpty(searchModel.Brand))
				model.Advertisements = model.Advertisements.Where(x =>
					x.VehicleID == _vehicleRepository.GetAll().SingleOrDefault(y =>
						y.ManufacturerID == _manufacturerRepository.GetAll().SingleOrDefault(z => z.Name.Contains(searchModel.Brand)).Id).Id);

			if (!string.IsNullOrEmpty(searchModel.Color))
				model.Advertisements = model.Advertisements.Where(x =>
					x.VehicleID == _vehicleRepository.GetAll().SingleOrDefault(y =>
						y.ManufacturerID == _colorRepository.GetAll().SingleOrDefault(z => z.Name.Contains(searchModel.Brand)).Id).Id);
			
		    if (searchModel.PriceMin.HasValue)
			model.Products = _productsRepository.GetAll().Where(x => x.Price >= searchModel.PriceMin);
		    if (searchModel.PriceMax.HasValue)
			    model.Products = _productsRepository.GetAll().Where(x => x.Price <= searchModel.PriceMax);

			return View(model);
	    }

		// GET: FQ
		[Route("F&Q")]
	    [HttpGet]
	    [AllowAnonymous]
	    public ActionResult FQ()
	    {
		    return View();
	    }

		// GET: Contact
		[Route("Contact")]
	    [HttpGet]
	    [AllowAnonymous]
	    public ActionResult Contact()
	    {
		    return View();
	    }
	}
}