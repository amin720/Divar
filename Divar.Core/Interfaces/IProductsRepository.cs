using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;

namespace Divar.Core.Interfaces
{
    public interface IProductsRepository
    {
        Product Get(String Name);
        IEnumerable<Product> GetAll();
        void Create(Product product);
        void Update(Product product);
        void Delete(String Name);
    }
}
