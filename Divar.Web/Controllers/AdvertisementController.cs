using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Divar.Core.Interfaces;
using Divar.Infrastructure.Repository;

namespace Divar.Web.Controllers
{
	[RoutePrefix("Advertisement")]
	public class AdvertisementController : Controller
	{
		private readonly IAdvertismentRepository _advertismentRepository;
		private readonly IProductsRepository _productsRepository;
		private readonly IServiceRepository _serviceRepository;
		private readonly IEmploymentRepository _employmentRepository;

		public AdvertisementController()
			: this(new AdvertismentRepository(), new ProductRepository(),new ServiceRepository(), new EmploymentRepository())
		{
			
		}

		public AdvertisementController(IAdvertismentRepository advertismentRepository, IProductsRepository productsRepository,
			IServiceRepository serviceRepository, IEmploymentRepository employmentRepository)
		{
			_advertismentRepository = advertismentRepository;
			_productsRepository = productsRepository;
			_serviceRepository = serviceRepository;
			_employmentRepository = employmentRepository;
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
		public ActionResult Product()
		{
			return View();
		}
	}
}