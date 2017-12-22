using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    public class EmploymentRepository : IEmploymentRepository
    {
        public Employment Get(string Name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employment> GetAll()
        {
            throw new NotImplementedException();
        }
        public void Create(Employment employment)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Name)
        {
            throw new NotImplementedException();
        }

        public void Update(Employment employment)
        {
            throw new NotImplementedException();
        }
    }
}
