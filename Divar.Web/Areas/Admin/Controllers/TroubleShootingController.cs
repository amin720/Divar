using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Divar.Core.Entities;
using Divar.Core.Interfaces;
using Divar.Infrastructure.Repository;

namespace Divar.Web.Areas.Admin.Controllers
{
	[RouteArea("Admin")]
	[RoutePrefix("TroubleShooting")]
	[Authorize]
	public class TroubleShootingController : Controller
	{
		private readonly IAdvertismentRepository _repository;
		private readonly IUserRepository _userRepository;
		public TroubleShootingController()
			: this(new AdvertismentRepository(),new UserRepository())
	    {
		    
	    }

	    public TroubleShootingController(IAdvertismentRepository advertismentRepository,IUserRepository userRepository)
	    {
		    _repository = advertismentRepository;
		    _userRepository = userRepository;
	    }

        // GET: Admin/TroubleShooting
        public ActionResult Index()
        {
	        var model = _repository.GetAll().Where(a => a.IsError == true).ToList();
			
            return View(model);
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