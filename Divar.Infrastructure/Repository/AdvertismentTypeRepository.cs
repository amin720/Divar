using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    public class AdvertismentTypeRepository : IAdvertisementTypeRepository
    {

        public AdvertisementType Get(string Name)
        {
            using (var db = new DivarEntities())
            {
                return db.AdvertisementTypes.Single( d => d.Name == Name);
            }
        }

        public IEnumerable<AdvertisementType> GetAll()
        {
            using (var db = new DivarEntities())
            {
                return db.AdvertisementTypes.ToList();
            }
        }
        public void Create(AdvertisementType advType)
        {
            using (var db = new DivarEntities())
            {
                if ((db.AdvertisementTypes.Single(d => d.Name == advType.Name)) != null)
                {

                }
                db.AdvertisementTypes.Add(advType);
                db.SaveChanges();
            }
        }
        public void Update(AdvertisementType advType)
        {
            using (var db = new DivarEntities())
            {
                var model = db.AdvertisementTypes.Single( d => d.Name == advType.Name);
                if (model == null) return;

                model.Name = advType.Name;
                db.SaveChanges();
            }
        }
        public void Delete(string Name)
        {
            using (var db = new DivarEntities())
            {
                var model = db.AdvertisementTypes.Single( d => d.Name == Name);
                if (model == null) return;

                db.AdvertisementTypes.Remove(model);
                db.SaveChanges();

            }
        }

    }
}
