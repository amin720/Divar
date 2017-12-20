using Divar.Core.Entities;
using Divar.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Divar.Infrastructure.Repository
{
	public class StateRepository : IStateRepository
	{
		public TBL_State Get(string name)
		{
			using (var db = new DivarEntities())
			{
				return db.TBL_State.SingleOrDefault(c => string.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase));
			}
		}
		public IEnumerable<TBL_State> GetAll()
		{
			using (var db = new DivarEntities())
			{
				return db.TBL_State.OrderBy(c => c.Name).ToList();
			}
		}
		public void Create(TBL_State state)
		{
			using (var db = new DivarEntities())
			{
				var model = db.TBL_State.SingleOrDefault(c =>
					string.Equals(c.Name, state.Name, StringComparison.CurrentCultureIgnoreCase));
				if (model != null)
				{
					throw new KeyNotFoundException("this model with name: " + state.Name + "is exist");
				}
				db.TBL_State.Add(state);
				db.SaveChanges();
			}
		}
		public void Update(TBL_State state)
		{
			using (var db = new DivarEntities())
			{
				var model = db.TBL_State.SingleOrDefault(c =>
					string.Equals(c.Name, state.Name, StringComparison.CurrentCultureIgnoreCase));
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
				var model = db.TBL_State.SingleOrDefault(c =>
					string.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase));
				if (model == null)
				{
					throw new KeyNotFoundException("this model with name: " + name + "is not exist");
				}
				db.TBL_State.Remove(model);
				db.SaveChanges();
			}
		}

		public IEnumerable<TBL_State> GetAllCityStates()
		{
			using (var db = new DivarEntities())
			{
				return db.TBL_State.Include("TBL_City").OrderBy(c => c.Name).ToList();
			}
		}
	}
}
