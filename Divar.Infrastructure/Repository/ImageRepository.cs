using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divar.Core.Entities;
using Divar.Core.Interfaces;

namespace Divar.Infrastructure.Repository
{
	public class ImageRepository : IImageRepository
	{
		public Image Get(int id)
		{
			using (var db = new DivarEntities())
			{
				return db.Images.Single(c => c.Id == id);
			}
		}

		public IEnumerable<Image> GetAll()
		{
			using (var db = new DivarEntities())
			{
				return db.Images.ToList();
			}
		}

		public void Create(Image image)
		{
			using (var db = new DivarEntities())
			{
				if ((db.Images.Single(c => c.Id == image.Id)) != null)
				{

				}
				db.Images.Add(image);
				db.SaveChanges();
			}
		}
		public void Update(Image image)
		{						  
			using (var db = new DivarEntities())
			{
				var model = db.Images.Single(c => c.Id == image.Id);
				if (model == null) return;

				model.Url = image.Url;
				db.SaveChanges();
			}
		}
		public void Delete(int id)
		{
			using (var db = new DivarEntities())
			{
				var model = db.Images.Single(c => c.Id == id);
				if (model == null) return;

				db.Images.Remove(model);
				db.SaveChanges();
			}
		}
	}
}
