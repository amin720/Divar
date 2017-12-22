using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
    public interface IServiceRepository
    {
        Service Get();
        IEnumerable<Service> GetAll();
        void Create(Service service);
        void Update(Service service);
        void Delete();
    }
}
