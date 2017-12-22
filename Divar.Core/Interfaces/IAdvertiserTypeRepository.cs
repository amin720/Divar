using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
    public interface IAdvertiserTypeRepository
    {
        AdvertiserType Get(String Name);
        IEnumerable<AdvertiserType> GetAll();
        void Create(AdvertiserType advType);
        void Update(AdvertiserType advType);
        void Delete(String Name);

    }
}
