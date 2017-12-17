using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Divar.Core.Entities
{
	public class UserIdentity : IdentityUser
	{
		[StringLength(100)]
		public string DisplayName { get; set; }
	}
}
