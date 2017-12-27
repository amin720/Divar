using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
    public class AssemblerRepository : IAssemblerRepository
    {
        public Assembler Get(string Name)
        {
            using (var db = new DivarEntities())
            {
                return db.Assemblers.Single( a => a.Name== Name);
            }
        }

        public IEnumerable<Assembler> GetAll()
        {
            using (var db = new DivarEntities())
            {
                return db.Assemblers.ToList();
            }
        }
        public void Create(Assembler assembler)
        {
            throw new NotImplementedException();
        }

        public void Update(Assembler assembler)
        {
            throw new NotImplementedException();
        }
        public void Delete(string Name)
        {
            throw new NotImplementedException();
        }

    }
}
