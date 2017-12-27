using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    public class ColorRepository : IColorRepository
    {
        public Color Get(string name)
        {
            using (var db = new DivarEntities())
            {
                return db.Colors.Single( c => c.Name == name);
            }
        }

        public IEnumerable<Color> GetAll()
        {
            using (var db = new DivarEntities())
            {
                return db.Colors.ToList();
            }
        }

        public void Create(Color color)
        {
            using (var db = new DivarEntities())
            {
                if ((db.Colors.Single(c => c.Name == color.Name)) != null)
                {

                }
                db.Colors.Add(color);
                db.SaveChanges();
            }
        }
        public void Update(Color color)
        {
            using (var db = new DivarEntities())
            {
                var model = db.Colors.Single( c => c.Name == color.Name );
                if (model == null) return;

                model.Code = color.Code;
                model.Name = color.Name;
                db.SaveChanges();
            }
        }
        public void Delete(string name)
        {
            using (var db = new DivarEntities())
            {
                var model = db.Colors.Single( c => c.Name == name);
                if (model == null) return;

                db.Colors.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
