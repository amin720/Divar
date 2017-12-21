using Divar.Core.Entities;
using System.Collections.Generic;

namespace Divar.Core.Interfaces
{
	public interface IStateRepository
	{
		State Get(string name);
		IEnumerable<State> GetAll();
		void Create(State state);
		void Update(State state);
		void Delete(string name);
		IEnumerable<State> GetAllCityStates();
	}
}
