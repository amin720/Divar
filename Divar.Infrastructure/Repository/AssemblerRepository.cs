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
            throw new NotImplementedException();
        }

        public IEnumerable<Assembler> GetAll()
        {
            throw new NotImplementedException();
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
