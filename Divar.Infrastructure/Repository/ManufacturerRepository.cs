using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        public Manufacturer Get(int id)
        {
            using (var db = new DivarEntities())
            {
                return db.Manufacturers.Single( m => m.Id == id);
            }
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            using (var db = new DivarEntities())
            {
                return db.Manufacturers.ToList();
            }
        }
        public void Create(Manufacturer manufacturer)
        {
            using (var db = new DivarEntities())
            {
                if ((db.Manufacturers.Single(m => m.Name == manufacturer.Name)) != null)
                {

                }
                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();
            }
        }

        public void Update(Manufacturer manufacturer)
        {
            using (var db = new DivarEntities())
            {
                var model = db.Manufacturers.Single(m => m.Name == manufacturer.Name);
                if ( model == null) return;

                model.Name = manufacturer.Name;
                model.Description = manufacturer.Description;

                db.SaveChanges();
            };
        }
        public void Delete(string Name)
        {
            using (var db = new DivarEntities())
            {
                var model = db.Manufacturers.Single( m => m.Name == Name );
                if (model == null) return;

                db.Manufacturers.Remove(model);
                db.SaveChanges();
            }
        }

    }
}
