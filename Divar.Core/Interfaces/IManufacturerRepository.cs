using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
    public interface IManufacturerRepository
    {
        Manufacturer Get(String Name);
        IEnumerable<Manufacturer> GetAll();
        void Create(Manufacturer manufacturer);
        void Update(Manufacturer manufacturer);
        void Delete(String Name);
    }
}
