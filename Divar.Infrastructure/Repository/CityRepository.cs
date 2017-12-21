using Divar.Core.Entities;
using Divar.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Divar.Infrastructure.Repository
{
	public class CityRepository : ICityRepository
	{
		public City Get(string name)
		{
			using (var db = new DivarEntities())
			{
				return db.Cities.SingleOrDefault(c => c.Name == name);
			}
		}
		public IEnumerable<City> GetAll()
		{
			using (var db = new DivarEntities())
			{
				return db.Cities.OrderBy(c => c.Name).ToList();
			}
		}
		public void Create(City city)
		{
			using (var db = new DivarEntities())
			{
				var model = db.Cities.SingleOrDefault(c => c.Name == city.Name);

				if (model != null)
				{
					throw new KeyNotFoundException("this model with name: " + city.Name + "is exist");
				}
				db.Cities.Add(city);
				db.SaveChanges();
			}
		}
		public void Update(City city)
		{
			using (var db = new DivarEntities())
			{
				var model = db.Cities.SingleOrDefault(c => c.Name == city.Name);
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
				var model = db.Cities.SingleOrDefault(c => c.Name == name);
				if (model == null)
				{
					throw new KeyNotFoundException("this model with name: " + name + "is not exist");
				}
				db.Cities.Remove(model);
				db.SaveChanges();
			}
		}

	}
}
