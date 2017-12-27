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
            using (var db = new DivarEntities())
            {
                if ((db.Advertisements.Single(d => d.VehicleID == advertisement.VehicleID && d.CityID == advertisement.CityID)) != null)
                {

                }
                db.Advertisements.Add(advertisement);
                db.SaveChanges();
            }
        }
        public void Update(Advertisement advertisement)
        {
            using (var db = new DivarEntities())
            {
                var model = db.Advertisements.Single(d => d. );
                if (model == null) return;

                model.VehicleID = advertisement.VehicleID;
                model.CityID = advertisement.CityID;
                model.UserID = advertisement.UserID;
                model.Description = advertisement.Description;
                db.SaveChanges();
            }
        }
        public void Delete(long vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
