using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
    public interface IColorRepository
    {
        Color Get();
        IEnumerable<Color> GetAll();
        void Create(Color color);
        void Update(Color color);
        void Delete();
    }
}
