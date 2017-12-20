using Divar.Core.Entities;
using Divar.Infrastructure.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Divar.Infrastructure.Repository
{
	public class CmsUserStore : UserStore<UserIdentity>
	{
		public CmsUserStore()
			: this(new ContextDb())
		{ }
		public CmsUserStore(ContextDb context)
			: base(context)
		{ }

	}

	public class CmsUserManager : UserManager<UserIdentity>
	{
		public CmsUserManager()
			: this(new CmsUserStore())
		{ }

		public CmsUserManager(UserStore<UserIdentity> userStore)
			: base(userStore)
		{ }
	}
}
