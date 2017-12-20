using System.Collections.Generic;

namespace Divar.Web.Areas.Admin.ViewModels
{
	public class CategoryViewModel
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public int ParentId { get; set; }
		//public IEnumerable<Category> Categories { get; set; }
	}
}