using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Interfaces;
using Divar.Core.Entities;

namespace Divar.Infrastructure.Repository
{
    class AdvertismentRepository : IAdvertismentRepository
    {
        public Advertisement Get(long vehicleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Advertisement> GetAll()
        {
            throw new NotImplementedException();
        }
        public void Create(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }
        public void Update(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }
        public void Delete(long vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
