using Divar.Core.Entities;
using Divar.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Divar.Infrastructure.Repository
{
	public class StateRepository : IStateRepository
	{
		public State Get(string name)
		{
			using (var db = new DivarEntities())
			{
				return db.States.SingleOrDefault(c => c.Name == name);
			}
		}
		public IEnumerable<State> GetAll()
		{
			using (var db = new DivarEntities())
			{
				return db.States.OrderBy(c => c.Name).ToList();
			}
		}
		public void Create(State state)
		{
			using (var db = new DivarEntities())
			{
				var model = db.States.SingleOrDefault(c => c.Name == state.Name);
				if (model != null)
				{
					throw new KeyNotFoundException("this model with name: " + state.Name + "is exist");
				}
				db.States.Add(state);
				db.SaveChanges();
			}
		}
		public void Update(State state)
		{
			using (var db = new DivarEntities())
			{
				var model = db.States.SingleOrDefault(c => c.Name == state.Name);
				if (model == null)
				{
					throw new KeyNotFoundException("this model with name: " + state.Name + "is not exist");
				}
				model.Name = state.Name;
				db.SaveChanges();
			}
		}
		public void Delete(string name)
		{
			using (var db = new DivarEntities())
			{
				var model = db.States.SingleOrDefault(c => c.Name == name);
				if (model == null)
				{
					throw new KeyNotFoundException("this model with name: " + name + "is not exist");
				}
				db.States.Remove(model);
				db.SaveChanges();
			}
		}

		public IEnumerable<State> GetAllCityStates()
		{
			using (var db = new DivarEntities())
			{
				return db.States.Include("City").OrderBy(c => c.Name).ToList();
			}
		}
	}
}
