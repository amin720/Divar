﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Interfaces;
using Divar.Core.Entities;

namespace Divar.Infrastructure.Repository
{
    public class AdvertismentRepository : IAdvertismentRepository
    {
        public Advertisement Get(Int64 vehicleId , Int64 cityId)
        {
            using (var db = new DivarEntities())
            {
                return db.Advertisements.SingleOrDefault(d => d.VehicleID == vehicleId && d.CityID == cityId);
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
                if ((db.Advertisements.SingleOrDefault(d => d.VehicleID == advertisement.VehicleID && d.CityID == advertisement.CityID)) != null)
                {
	                throw new KeyNotFoundException("همچین ساختاری وجود دارد " + advertisement.Id);
				}
                db.Advertisements.Add(advertisement);
                db.SaveChanges();
            }
        }
        public void Update(Advertisement advertisement)
        {
            using (var db = new DivarEntities())
            {
                var model = db.Advertisements.SingleOrDefault(d => d.Id == advertisement.Id );
                if (model == null) return;

                model.VehicleID = advertisement.VehicleID;
                model.CityID = advertisement.CityID;
                model.UserID = advertisement.UserID;
                model.Description = advertisement.Description;
	            model.IsError = advertisement.IsError;

                db.SaveChanges();
            }
        }
        public void Delete(Int64 vehicleId , Int64 cityId)
        {
            using (var db = new DivarEntities())
            {
                var model = db.Advertisements.SingleOrDefault( d => d.CityID == cityId && d.VehicleID == vehicleId);
                if (model == null) return;

                db.Advertisements.Remove(model);
                db.SaveChanges();
            }
        }
	    public void Delete(Int64 advId)
	    {
		    using (var db = new DivarEntities())
		    {
			    var model = db.Advertisements.SingleOrDefault(d => d.Id == advId);
			    if (model == null) return;

			    db.Advertisements.Remove(model);
			    db.SaveChanges();
		    }
	    }
	    public List<IGrouping<string, Advertisement>> GetAllByCity()
	    {
		    using (var db = new DivarEntities())
		    {
			    return db.Advertisements.GroupBy(x => x.City.Name).ToList();
		    }
	    }
	    public List<IGrouping<string, Advertisement>> GetAllByBrand()
	    {
		    using (var db = new DivarEntities())
		    {
			    return db.Advertisements.GroupBy(x => x.Vehicle.Manufacturer.Name).ToList();
		    }
	    }
	}
}
