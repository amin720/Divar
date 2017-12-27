using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Interfaces;
using Divar.Core.Entities;

namespace Divar.Infrastructure.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        public Vehicle Get(long vehicleTypeId, long manufacturerID, string Name)
        {
            using (var db = new DivarEntities())
            {
                return db.Vehicles.Single(v => v.Name == Name && v.VehicleTypeID == vehicleTypeId && v.ManufacturerID == manufacturerID );
            }
        }

        public IEnumerable<Vehicle> GetAll()
        {
            using (var db = new DivarEntities())
            {
                return db.Vehicles.ToList();
            }
        }
        public void Create(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void Delete(long vehicleTypeId, long ManufacturerID, string Name)
        {
            throw new NotImplementedException();
        }


    }
}
