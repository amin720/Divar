using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Divar.Core.Entities;
using Divar.Core.Interfaces;
using Divar.Infrastructure.Repository;
using Divar.Web.Areas.Admin.ViewModels;

namespace Divar.Web.Areas.Admin.Controllers
{
	[RouteArea("Admin")]
	[RoutePrefix("TroubleShooting")]
	[Authorize]
	public class TroubleShootingController : Controller
	{
		private readonly IAdvertismentRepository _repository;
		private readonly IUserRepository _userRepository;
		private readonly IProductsRepository _productsRepository;
		private readonly IImageRepository _imageRepository;
		public TroubleShootingController()
			: this(new AdvertismentRepository(), new UserRepository(), new ProductRepository(), new ImageRepository())
		{

		}

		public TroubleShootingController(IAdvertismentRepository advertismentRepository, IUserRepository userRepository,
			IProductsRepository productsRepository, IImageRepository imageRepository )
		{
			_repository = advertismentRepository;
			_userRepository = userRepository;
			_productsRepository = productsRepository;
			_imageRepository = imageRepository;
		}

		// GET: Admin/TroubleShooting
		public async Task<ActionResult> Index()
		{
			//var model = _repository.GetAll().Where(a => a.IsError == true).ToList();
			var users = await _userRepository.GetAllUsersAsync();
			var model = new List<TroubleShootingViewModel>();
			foreach (var item in _repository.GetAll())
			{
				model.Add(new TroubleShootingViewModel
				{
					Id = item.Id,
					Username = users.SingleOrDefault(x => x.Id == item.UserID).UserName,
					AdvName = _productsRepository.GetAll().SingleOrDefault(x => x.IdAdvertisement == item.Id).Name
				});
			}

			return View(model);
		}

		[Route("Delete/{advId}")]
		public ActionResult Delete(int advId)
		{
			var product = _productsRepository.GetAll().SingleOrDefault(x => x.IdAdvertisement == advId);
			var image = _imageRepository.GetAll().SingleOrDefault(x => x.IdAdvertising == advId);

			_productsRepository.Delete(product.Id);
			_imageRepository.Delete(image.Id);
			_repository.Delete(advId);

			var model = _repository.GetAll().Where(a => a.IsError == true).ToList();
			return RedirectToAction("Index", model);
		}

		[Route("Details/{advId}")]
		public async Task<ActionResult> Details(int advId)
		{
			var users = await _userRepository.GetAllUsersAsync();
			var adv = _repository.GetAll().SingleOrDefault(x => x.Id == advId);

			var model = new TroubleShootingViewModel
			{
				Id = advId,
				AdvName = _productsRepository.GetAll().SingleOrDefault(x => x.IdAdvertisement == advId).Name,
				Username = users.SingleOrDefault(x => x.Id == adv.UserID).UserName,
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