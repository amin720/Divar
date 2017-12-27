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
            using (var db = new DivarEntities())
            {
                return db.Products.Single( p => p.Name == Name && p.CreateDate == createDate);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (var db = new DivarEntities())
            {
                return db.Products.ToList();
            }
        }
        public void Create(Product product)
        {
            using (var db = new DivarEntities())
            {
                if ((db.Products.Single(p => p.Name == product.Name && p.CreateDate == product.CreateDate)) != null)
                {

                }
                db.Products.Add(product);
                db.SaveChanges();
            }
            
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
