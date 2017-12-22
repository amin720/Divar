using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
    public interface IEmploymentRepository
    {
        Employment Get(String Name);
        IEnumerable<Employment> GetAll();
        void Create(Employment employment);
        void Update(Employment employment);
        void Delete(String Name);

    }
}
