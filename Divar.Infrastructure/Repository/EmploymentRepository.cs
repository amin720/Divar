using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    public class EmploymentRepository : IEmploymentRepository
    {
        public Employment Get(string Name)
        {
            using (var db = new DivarEntities())
            {
                return db.Employments.Single( e => e.Name == Name );
            }
        }

        public IEnumerable<Employment> GetAll()
        {
            using (var db = new DivarEntities())
            {
                return db.Employments.ToList();
            }
        }
        public void Create(Employment employment)
        {
            using (var db = new DivarEntities())
            {
                if ((db.Employments.Single( e => e.Name == employment.Name )) != null)
                {

                }
                db.Employments.Add(employment);
                db.SaveChanges();
            }
        }

        public void Update(Employment employment)
        {

            using (var db = new DivarEntities())
            {
                var model = db.Employments.Single(e => e.Name == employment.Name);
                if (model == null) return;

                model.Name = employment.Name;
                model.Link = employment.Link;
                model.IdAdvertisement = employment.IdAdvertisement;

                db.SaveChanges();
            }
            
        }
        public void Delete(string Name)
        {
            throw new NotImplementedException();
        }

    }
}
