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
	[RoutePrefix("Address")]
	[Authorize(Roles = "admin")]
	public class AddressController : Controller
	{
		private readonly ICityRepository _cityRepository;
		private readonly IStateRepository _stateRepository;

		public AddressController()
			: this(new CityRepository(), new StateRepository())
		{

		}

		public AddressController(ICityRepository cityRepository, IStateRepository stateRepository)
		{
			_cityRepository = cityRepository;
			_stateRepository = stateRepository;
		}

		// GET: Admin/Address
		[HttpGet]
		public ActionResult Index()
		{
			if (User.IsInRole("author"))
			{
				return new HttpUnauthorizedResult();
			}

			return View();
		}

		// GET: Admin/Address/City
		[HttpGet]
		public ActionResult City()
		{
			var cities = _cityRepository.GetAll();

			if (Request.AcceptTypes.Contains("application/json"))
			{
				return Json(cities, JsonRequestBehavior.AllowGet);
			}
			return View(model: cities);
		}

		// GET: Admin/Address/CityCreate
		[HttpGet]
		public ActionResult CityCreate(City city)
		{
			if (!ModelState.IsValid)
			{
				return HttpNotFound();
			}
			try
			{
				_cityRepository.Create(city);

				return RedirectToAction("City");
			}
			catch (Exception e)
			{
				ModelState.AddModelError(String.Empty, e.Message);
				return View(model: _cityRepository.GetAll(), viewName: "City");
			}
		}

		// Get: Admin/Category/Edit/category
		[HttpGet]
		[Route("edit/{cityName}")]
		public ActionResult EditCity(string cityName)
		{
			try
			{
				var category = _cityRepository.Get(cityName);

				var model = new CategoryViewModel<City>
				{
					Id = category.Id,
					Name = category.Name,
					Categories = _cityRepository.GetAll()
				};

				return View(model: model, viewName: "EditCity");

			}
			catch (KeyNotFoundException e)
			{
				return HttpNotFound();
			}
		}


		// product: Admin/Category/Edit/tag
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("edit/{cityName}")]
		[Authorize(Roles = "admin, editor")]
		public ActionResult EditCity(string cityName, CategoryViewModel<City> newCat)
		{
			try
			{
				newCat.Name = cityName;
				newCat.Categories = _cityRepository.GetAll();

				if (string.IsNullOrWhiteSpace(newCat.Name))
				{
					ModelState.AddModelError("key", "New category value cannot be empty.");

					return View(model: newCat);
				}

				var model = new City()
				{
					Id = newCat.Id,
					Name = newCat.Name,
				};

				_cityRepository.Update(model);

				return RedirectToAction("City");

			}
			catch (AccessViolationException e)
			{
				ModelState.AddModelError(string.Empty, e.Message);
				return View(newCat);
			}

		}
		// Get: Admin/Category/Delete
		[HttpGet]
		//        [ValidateAntiForgeryToken]
		[Route("delete/{cityName}")]
		
		public ActionResult DeleteCity(string cityName)
		{
			var model = _cityRepository.Get(cityName);
			return View(model: model);
		}

		// product: Admin/Category/Delete
		[HttpPost]
		//        [ValidateAntiForgeryToken]
		[Route("delete/{cityName}")]
		[Authorize(Roles = "admin, editor")]
		public ActionResult DeleteCity(string cityName, City city)
		{
			try
			{
				city.Name = cityName;

				_cityRepository.Delete(city.Name);

				return RedirectToAction("City");
			}
			catch (KeyNotFoundException e)
			{
				return HttpNotFound();
			}
		}

		////////////////////////////////////

		// GET: Admin/Address/State
		[HttpGet]
		public ActionResult State()
		{
			var states = _stateRepository.GetAll();

			if (Request.AcceptTypes.Contains("application/json"))
			{
				return Json(states, JsonRequestBehavior.AllowGet);
			}
			return View(model: states,viewName:"State");
		}

		// GET: Admin/Address/CityCreate
		[HttpGet]
		public ActionResult StateCreate(State state)
		{
			if (!ModelState.IsValid)
			{
				return HttpNotFound();
			}
			try
			{
				_stateRepository.Create(state);

				return RedirectToAction("State");
			}
			catch (Exception e)
			{
				ModelState.AddModelError(String.Empty, e.Message);
				return View(model: _stateRepository.GetAll(), viewName: "State");
			}
		}

		// Get: Admin/Category/Edit/category
		[HttpGet]
		[Route("edit/{stateName}")]
		public ActionResult EditState(string stateName)
		{
			try
			{
				var category = _stateRepository.Get(stateName);

				var model = new CategoryViewModel<State>
				{
					Id = category.Id,
					Name = category.Name,
					Categories = _stateRepository.GetAll()
				};

				return View(model: model, viewName: "EditState");

			}
			catch (KeyNotFoundException e)
			{
				return HttpNotFound();
			}
		}


		// product: Admin/Category/Edit/tag
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("edit/{cityName}")]
		[Authorize(Roles = "admin, editor")]
		public ActionResult EditState(string stateName, CategoryViewModel<State> newCat)
		{
			try
			{
				newCat.Name = stateName;
				newCat.Categories = _stateRepository.GetAll();

				if (string.IsNullOrWhiteSpace(newCat.Name))
				{
					ModelState.AddModelError("key", "New category value cannot be empty.");

					return View(model: newCat);
				}

				var model = new City()
				{
					Id = newCat.Id,
					Name = newCat.Name,
				};

				_cityRepository.Update(model);

				return RedirectToAction("State");

			}
			catch (AccessViolationException e)
			{
				ModelState.AddModelError(string.Empty, e.Message);
				return View(newCat);
			}

		}
		// Get: Admin/Category/Delete
		[HttpGet]
		//        [ValidateAntiForgeryToken]
		[Route("delete/{stateName}")]

		public ActionResult DeleteState(string stateName)
		{
			var model = _stateRepository.Get(stateName);
			return View(model: model);
		}

		// product: Admin/Category/Delete
		[HttpPost]
		//        [ValidateAntiForgeryToken]
		[Route("delete/{stateName}")]
		[Authorize(Roles = "admin, editor")]
		public ActionResult DeleteState(string stateName, State state)
		{
			try
			{
				state.Name = stateName;

				_cityRepository.Delete(state.Name);

				return RedirectToAction("State");
			}
			catch (KeyNotFoundException e)
			{
				return HttpNotFound();
			}
		}
	}
}