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
        Vehicle Get(long vehicleTypeId, long ManufacturerID, string Name);
        IEnumerable<Vehicle> GetAll();
        void Create(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(Int64 vehicleTypeId, Int64 ManufacturerID, String Name);
    }
}
