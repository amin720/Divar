using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Interfaces;
using Divar.Core.Entities;

namespace Divar.Infrastructure.Repository
{
    class AdvertismentRepository : IAdvertismentRepository
    {
        public Advertisement Get(long vehicleId , Int64 cityId)
        {
            using (var db = new DivarEntities())
            {
                return db.Advertisements.Single(d => d.VehicleID == vehicleId && d.CityID == cityId);
            }
        }

        public IEnumerable<Advertisement> GetAll()
        {
            using (var db = new DivarEntities())
            {
                return db.Advertisements.ToList();
            }
        }
        public void Create(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }
        public void Update(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }
        public void Delete(long vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
