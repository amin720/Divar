using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
    public interface IAssemblerRepository
    {
        Assembler Get(String Name);
        IEnumerable<Assembler> GetAll();
        void Create(Assembler assembler);
        void Update(Assembler assembler);
        void Delete(String Name);
    }
}
