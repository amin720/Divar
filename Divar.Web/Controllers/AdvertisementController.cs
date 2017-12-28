using System;
using System.Collections.Generic;
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


		public AdvertisementController()
			: this(new AdvertismentRepository(), new ProductRepository(),new ServiceRepository(), new EmploymentRepository(),
				  new VehicleRepository(),new ManufacturerRepository(),new AssemblerRepository(), new ColorRepository(),
				  new CityRepository(), new StateRepository(),new ImageRepository(), new VehicleTypeRepository(),new AdvertismentTypeRepository(),
				  new UserRepository())
		{
			
		}

		public AdvertisementController(IAdvertismentRepository advertismentRepository, IProductsRepository productsRepository,
			IServiceRepository serviceRepository, IEmploymentRepository employmentRepository,IVehicleRepository vehicleRepository,
			IManufacturerRepository manufacturerRepository, IAssemblerRepository assemblerRepository, IColorRepository colorRepository,
			ICityRepository cityRepository, IStateRepository stateRepository, IImageRepository imageRepository, IVehicleTypeRepository vehicleTypeRepository,
			IAdvertisementTypeRepository advertisementTypeRepository, IUserRepository userRepository)
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
			};
			return View(model);
		}
		// POST: Advertisement/Product
		[Route("Product")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Product(ProductViewModel product, HttpPostedFileBase fileUpload)
		{
			
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