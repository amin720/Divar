using Divar.Core.Entities;
using Divar.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Divar.Infrastructure.Repository
{
	public class CityRepository : ICityRepository
	{
		public TBL_City Get(string name)
		{
			using (var db = new DivarEntities())
			{
				return db.TBL_City.SingleOrDefault(c => c.Name == name);
			}
		}
		public IEnumerable<TBL_City> GetAll()
		{
			using (var db = new DivarEntities())
			{
				return db.TBL_City.OrderBy(c => c.Name).ToList();
			}
		}
		public void Create(TBL_City city)
		{
			using (var db = new DivarEntities())
			{
				var model = db.TBL_City.SingleOrDefault(c => c.Name == city.Name);

				if (model != null)
				{
					throw new KeyNotFoundException("this model with name: " + city.Name + "is exist");
				}
				db.TBL_City.Add(city);
				db.SaveChanges();
			}
		}
		public void Update(TBL_City city)
		{
			using (var db = new DivarEntities())
			{
				var model = db.TBL_City.SingleOrDefault(c => c.Name == city.Name);
				if (model == null)
				{
					throw new KeyNotFoundException("this model with name: " + city.Name + "is not exist");
				}
				model.Name = city.Name;
				db.SaveChanges();
			}
		}
		public void Delete(string name)
		{
			using (var db = new DivarEntities())
			{
				var model = db.TBL_City.SingleOrDefault(c => c.Name == name);
				if (model == null)
				{
					throw new KeyNotFoundException("this model with name: " + name + "is not exist");
				}
				db.TBL_City.Remove(model);
				db.SaveChanges();
			}
		}

	}
}
