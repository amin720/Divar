using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Divar.Web.Areas.Admin.ViewModels
{
	public class TroubleShootingViewModel
	{
		public int Id { get; set; }
		[Display(Name = "نام آگهی")]
		public string AdvName { get; set; }
		[Display(Name = "نام کاربر")]
		public string Username { get; set; }

		public string Description { get; set; }
		public string UrlImage { get; set; }
		public string Brand { get; set; }
		public string Color { get; set; }
		public string Adver { get; set; }
		public string AdveType { get; set; }
	}
}