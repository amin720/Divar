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
        public Manufacturer Get(string Name)
        {
            using (var db = new DivarEntities())
            {
                return db.Manufacturers.Single( m => m.Name == Name);
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
            throw new NotImplementedException();
        }
        public void Delete(string Name)
        {
            throw new NotImplementedException();
        }

    }
}
