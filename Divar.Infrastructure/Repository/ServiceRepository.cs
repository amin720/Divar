using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        public Service Get(string Name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(Service service)
        {
            throw new NotImplementedException();
        }

        public void Update(Service service)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Name)
        {
            throw new NotImplementedException();
        }

    }
}
