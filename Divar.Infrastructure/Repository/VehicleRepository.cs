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
            using (var db = new DivarEntities())
            {
                if ((db.Vehicles.Single(v => v.Name == vehicle.Name && v.VehicleTypeID == vehicle.VehicleTypeID && v.ManufacturerID == vehicle.ManufacturerID) != null))
                {

                }
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
            }
        }
        public void Update(Vehicle vehicle)
        {
            using (var db = new DivarEntities())
            {
                var model = db.Vehicles.Single( v => v.Name == vehicle.Name && v.VehicleTypeID == vehicle.VehicleTypeID && v.ManufacturerID == vehicle.ManufacturerID );
                if (model == null) return;

                model.Name = vehicle.Name;
                model.Year = vehicle.Year;
                model.ColorID = vehicle.ColorID;
                model.VehicleTypeID = vehicle.VehicleTypeID;
                model.ManufacturerID = vehicle.ManufacturerID;
                model.AssemblerID = vehicle.AssemblerID;
                model.Series = vehicle.Series;

                db.SaveChanges();                
                
            }
        }

        public void Delete(long vehicleTypeId, long ManufacturerID, string Name)
        {
            using (var db = new DivarEntities())
            {
                var model = db.Vehicles.Single();
            }
        }


    }
}
