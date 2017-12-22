using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;


namespace Divar.Infrastructure.Repository
{
    public class ProductRepository : IProductsRepository
    {
        public Product Get(string Name, DateTime createDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }
        public void Create(Product product)
        {
            throw new NotImplementedException();
        }
        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Name, DateTime createDate)
        {
            throw new NotImplementedException();
        }

    }
}
