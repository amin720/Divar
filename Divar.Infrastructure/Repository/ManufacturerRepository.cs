using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        public Manufacturer Get(string Name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            throw new NotImplementedException();
        }
        public void Create(Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }

        public void Update(Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }
        public void Delete(string Name)
        {
            throw new NotImplementedException();
        }

    }
}
