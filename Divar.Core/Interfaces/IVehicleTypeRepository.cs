using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
    public interface IVehicleTypeRepository
    {
        VehicleType Get();
        IEnumerable<VehicleType> GetAll();
        void Create(VehicleType vehicType);
        void Update(VehicleType vehicType);
        void Delete();
    }
}
