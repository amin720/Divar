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
                return db.Products.SingleOrDefault( p => p.Name == Name && p.CreateDate == createDate);
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
                if ((db.Products.SingleOrDefault(p => p.Name == product.Name && p.CreateDate == product.CreateDate)) != null)
                {
	                throw new KeyNotFoundException("همچین ساختاری وجود دارد " + product.Name);
				}
                db.Products.Add(product);
                db.SaveChanges();
            }
            
        }
        public void Update(Product product)
        {
            using (var db = new DivarEntities())
            {
                var model = db.Products.SingleOrDefault();
                if (model == null) return;

                model.Name = product.Name;
                model.Price = product.Price;
                db.SaveChanges();
            }
        }

        public void Delete(string Name, DateTime createDate)
        {
            using (var db = new DivarEntities())
            {
                var model = db.Products.SingleOrDefault( p => p.Name == Name && p.CreateDate == createDate );
                if (model == null) return;

                db.Products.Remove(model);
                db.SaveChanges();

            }
        }

    }
}
