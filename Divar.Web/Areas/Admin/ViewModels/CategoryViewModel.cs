using System.Collections.Generic;
using Divar.Core.Entities;

namespace Divar.Web.Areas.Admin.ViewModels
{
	public class CategoryViewModel<T> 
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public int ParentId { get; set; }
		public IEnumerable<T> Categories { get; set; }
	}
}