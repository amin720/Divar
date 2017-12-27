using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    class VehicleTypeRepository : IVehicleTypeRepository
    {
        public VehicleType Get(string Name)
        {
            using (var db = new DivarEntities())
            {
                return db.VehicleTypes.Single( v => v.Name == Name );
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
                if ((db.VehicleTypes.Single(d => d.Name == vehicType.Name)) != null )
                {

                }
            }
        }

        public void Update(VehicleType vehicType)
        {
            throw new NotImplementedException();
        }
        public void Delete(string Name)
        {
            throw new NotImplementedException();
        }

    }
}
