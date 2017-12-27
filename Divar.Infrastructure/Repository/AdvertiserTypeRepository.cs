using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    class AdvertiserTypeRepository : IAdvertiserTypeRepository
    {
        public AdvertiserType Get(string Name)
        {
            using (var db = new DivarEntities())
            {
                return db.AdvertiserTypes.Single(d => d.Name == Name);
            }
        }

        public IEnumerable<AdvertiserType> GetAll()
        {
            using (var db = new DivarEntities())
            {
                return db.AdvertiserTypes.ToList();
            }
        }

        public void Create(AdvertiserType advType)
        {
            using (var db = new DivarEntities())
            {
                if ((db.AdvertiserTypes.Single(d => d.Name == advType.Name)) != null)
                {

                }
                db.AdvertiserTypes.Add(advType);
                db.SaveChanges();
            }
        }
        public void Update(AdvertiserType advType)
        {
            using (var db = new DivarEntities())
            {
                var model = db.AdvertiserTypes.Single( d => d.Name == advType.Name);
                if (model == null) return;

                model.Name = advType.Name;
                db.SaveChanges();
            }
        }
        public void Delete(string Name)
        {
            throw new NotImplementedException();
        }

    }
}
