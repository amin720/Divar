﻿using Divar.Core.Entities;
using Divar.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Divar.Infrastructure.Repository
{
	public class AdvertismentTypeRepository : IAdvertisementTypeRepository
    {

        public AdvertisementType Get(string Name)
        {
            using (var db = new DivarEntities())
            {
                return db.AdvertisementTypes.SingleOrDefault( d => d.Name == Name);
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
                if ((db.AdvertisementTypes.SingleOrDefault(d => d.Name == advType.Name)) != null)
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
                var model = db.AdvertisementTypes.SingleOrDefault( d => d.Name == advType.Name);
                if (model == null) return;

                model.Name = advType.Name;
                db.SaveChanges();
            }
        }
        public void Delete(string Name)
        {
            using (var db = new DivarEntities())
            {
                var model = db.AdvertisementTypes.SingleOrDefault( d => d.Name == Name);
                if (model == null) return;

                db.AdvertisementTypes.Remove(model);
                db.SaveChanges();

            }
        }

    }
}
