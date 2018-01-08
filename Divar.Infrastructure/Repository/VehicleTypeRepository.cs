using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        public VehicleType Get(string Name)
        {
            using (var db = new DivarEntities())
            {
                return db.VehicleTypes.SingleOrDefault( v => v.Name == Name );
            }
        }

        public IEnumerable<VehicleType> GetAll()
        {
            using (var db = new DivarEntities())
            {
                return db.VehicleTypes.ToList();
            }
        }
        public void Create(VehicleType vehicType)
        {
            using (var db = new DivarEntities())
            {
                if ((db.VehicleTypes.SingleOrDefault(d => d.Name == vehicType.Name)) != null )
                {

                }
                db.VehicleTypes.Add(vehicType);
                db.SaveChanges();
            }
        }

        public void Update(VehicleType vehicType)
        {
            using (var db = new DivarEntities())
            {
                var model = db.VehicleTypes.SingleOrDefault( v => v.Name == vehicType.Name);
                if (model == null) return;

                model.Name = vehicType.Name;
                model.Description = vehicType.Description;

                db.SaveChanges();

            }
        }
        public void Delete(string Name)
        {
            using (var db = new DivarEntities())
            {
                var model = db.VehicleTypes.SingleOrDefault( v => v.Name == Name );
                if (model == null) return;

                db.VehicleTypes.Remove(model);
                db.SaveChanges();
            }
        }

    }
}
