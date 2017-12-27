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
        public Color Get(string Name)
        {
            using (var db = new DivarEntities())
            {
                return db.Colors.Single( c => c.Name == Name);
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
            throw new NotImplementedException();
        }
        public void Update(Color color)
        {
            throw new NotImplementedException();
        }
        public void Delete(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
