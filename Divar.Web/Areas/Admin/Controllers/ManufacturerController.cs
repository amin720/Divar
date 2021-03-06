﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Divar.Core;
using Divar.Core.Entities;
using Divar.Core.Interfaces;
using Divar.Infrastructure;
using Divar.Infrastructure.Repository;

namespace Divar.Web.Areas.Admin.Controllers
{
	[RouteArea("Admin")]
	[RoutePrefix("Address")]
	[Authorize(Roles = "admin")]
	public class ManufacturerController : Controller
	{
		private readonly IDataServiceRepository<Manufacturer> _repository;
		private readonly IManufacturerRepository _manufacturerRepository;

		public ManufacturerController()
			: this(new DataService<Manufacturer>(), new ManufacturerRepository())
		{

		}

		public ManufacturerController(IDataServiceRepository<Manufacturer> repository, IManufacturerRepository manufacturerRepository)
		{
			_repository = repository;
			_manufacturerRepository = manufacturerRepository;
		}

		// GET: Admin/Manufacturer
		[HttpGet]
		public ActionResult Index()
		{
			var model = _repository.GetAllObj();

			return View(model);
		}

		// GET: Admin/Manufacturer/Create
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/Manufacturer/Create
		[HttpPost]
		public ActionResult Create(FormCollection obj)
		{
			var man = new Manufacturer();
			this.UpdateModel(man, obj);


			if (!ModelState.IsValid)
			{
				return HttpNotFound();
			}

			var model = _repository.GetAllObj();
			var manufacturer = model.SingleOrDefault(m => m.Name == man.Name);
			if (manufacturer != null)
			{
				ModelState.AddModelError(string.Empty, "این نام وجود دارد" + man.Name);
				return View();
			}

			_repository.Insert(obj);

			return RedirectToAction("Index");
		}

		// GET: Admin/Manufacturer/Edit
		[HttpGet]
		[Route("edit/{id}")]
		public ActionResult Edit(int id)
		{
			var model = _repository.GetObj(manufacturer => manufacturer.Id == id);
			//var model = _manufacturerRepository.Get(id);
			return View(model);
		}

		// POST: Admin/Manufacturer/Edit
		[HttpPost]
		public ActionResult Edit(Manufacturer obj)
		{
			
			if (!ModelState.IsValid)
			{
				return HttpNotFound();
			}

			var model = _repository.GetAllObj();
			var manufacturer = model.SingleOrDefault(m => m.Name == obj.Name);
			if (manufacturer == null)
			{
				ModelState.AddModelError(string.Empty, "این نام وجود ندارد" + obj.Name);
				return View();
			}

			//_repository.Update(manufacturer);
			_manufacturerRepository.Update(obj);

			return RedirectToAction("Index");
		}

		// GET: Admin/Manufacturer/Delete
		[HttpGet]
		[Route("delete/{id}")]
		public ActionResult Delete(int id)
		{
			var model = _repository.GetObj(manufacturer => manufacturer.Id == id);
			return View(model);
		}

		// POST: Admin/Manufacturer/Delete
		[HttpPost]
		//public ActionResult Delete(FormCollection obj)
		public ActionResult Delete(FormCollection obj)
		{
			var man = new Manufacturer();
			this.UpdateModel(man, obj);

			if (!ModelState.IsValid)
			{
				return HttpNotFound();
			}

			var model = _repository.GetAllObj();
			var manufacturer = model.SingleOrDefault(m => m.Id == man.Id);
			if (manufacturer == null)
			{
				ModelState.AddModelError(string.Empty, "این نام وجود ندارد" + man.Id);
				return View();
			}

			_repository.Delete(manufacturer);

			return RedirectToAction("Index");
		}
	}
}