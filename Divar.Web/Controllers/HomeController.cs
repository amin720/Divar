using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Divar.Web.Controllers
{
	[RoutePrefix("")]
    public class HomeController : Controller
    {
        // GET: Home
		[Route("")]
		[HttpGet]
		[AllowAnonymous]
		public ActionResult Index()
        {
            return View();
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