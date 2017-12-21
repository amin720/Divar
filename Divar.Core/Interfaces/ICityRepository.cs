using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
	public interface ICityRepository
	{
		City Get(string name);
		IEnumerable<City> GetAll();
		void Create(City city);
		void Update(City city);
		void Delete(string name);
	}
}
