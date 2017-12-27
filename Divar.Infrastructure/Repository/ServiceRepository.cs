using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        public Service Get(string Name)
        {
            using (var db = new DivarEntities())
            {
                return db.Services.Single( s => s.Name == Name );
            }
            
        }

        public IEnumerable<Service> GetAll()
        {
            using (var db = new DivarEntities())
            {
                return db.Services.ToList();

            }
        }

        public void Create(Service service)
        {
            using (var db = new DivarEntities())
            {
                if ((db.Services.Single(s => s.Name == service.Name)) != null)
                {

                }
                db.Services.Add(service);
                db.SaveChanges();
            }
        }

        public void Update(Service service)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Name)
        {
            throw new NotImplementedException();
        }

    }
}
