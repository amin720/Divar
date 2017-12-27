using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
	public interface IImageRepository
	{
		Image Get(int id);
		IEnumerable<Image> GetAll();
		void Create(Image image);
		void Update(Image image);
		void Delete(int id);
	}
}
