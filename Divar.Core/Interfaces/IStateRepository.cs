using Divar.Core.Entities;
using System.Collections.Generic;

namespace Divar.Core.Interfaces
{
	public interface IStateRepository
	{
		TBL_State Get(string name);
		IEnumerable<TBL_State> GetAll();
		void Create(TBL_State state);
		void Update(TBL_State state);
		void Delete(string name);
		IEnumerable<TBL_State> GetAllCityStates();
	}
}
