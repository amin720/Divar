using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
    public interface IAdvertismentRepository
    {
        Advertisement Get(Int64 vehicleId );
        IEnumerable<Advertisement> GetAll();
        void Create(Advertisement advertisement);
        void Update(Advertisement advertisement);
        void Delete(Int64 vehicleId);
    }
}
