using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
    public interface IAdvertisementTypeRepository
    {
        AdvertisementType Get(String Name);
        IEnumerable<AdvertisementType> GetAll();
        void Create(AdvertisementType advType);
        void Update(AdvertisementType advType);
        void Delete(String Name);
    }
}
