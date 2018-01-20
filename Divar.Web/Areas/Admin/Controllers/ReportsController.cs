using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Divar.Core.Interfaces;
using Divar.Infrastructure.Repository;
using Divar.Web.Areas.Admin.Models;
using Newtonsoft.Json;

namespace Divar.Web.Areas.Admin.Controllers
{
	public class ReportsController : Controller
	{
		private readonly IAdvertismentRepository _advertismentRepository;

		public ReportsController()
			: this(new AdvertismentRepository())
		{

		}
		public ReportsController(IAdvertismentRepository advertismentRepository)
		{
			_advertismentRepository = advertismentRepository;
		}

		// GET: Admin/Reports
		public ActionResult City()
		{
			var cityNames = _advertismentRepository.GetAllByCity();
			var model = new List<DataPoint>();

			foreach (var item in cityNames)
			{
				model.Add(new DataPoint
				(
					label: item.Key,
					y: item.Count()
				));
			}

			ViewBag.DataPoints = JsonConvert.SerializeObject(model, _jsonSetting);

			return View(model);
		}

		public ActionResult Brand()
		{
			var brandNames = _advertismentRepository.GetAllByBrand();
			var model = new List<DataPoint>();

			foreach (var item in brandNames)
			{
				model.Add(new DataPoint
				(
					label: item.Key,
					y: item.Count()
				));
			}

			ViewBag.DataPoints = JsonConvert.SerializeObject(model, _jsonSetting);

			return View(model);
		}


		JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
	}
}