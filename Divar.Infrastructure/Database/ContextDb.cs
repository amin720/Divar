using Divar.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Divar.Infrastructure.Database
{
	public class ContextDb : IdentityDbContext<UserIdentity>
	{
		public ContextDb()
			: base("name=Divar")
		{

		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
