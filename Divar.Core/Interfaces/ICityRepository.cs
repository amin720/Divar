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
		TBL_City Get(string name);
		IEnumerable<TBL_City> GetAll();
		void Create(TBL_City city);
		void Update(TBL_City city);
		void Delete(string name);
	}
}
