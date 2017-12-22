using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
    public interface IVehicleRepository
    {
        Vehicle Get();
        IEnumerable<Vehicle> GetAll();
        void Create(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete();
    }
}
