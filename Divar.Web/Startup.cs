using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Divar.Web.Startup))]

namespace Divar.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseCookieAuthentication(new CookieAuthenticationOptions()
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/admin/login"),
			});

			app.UseCookieAuthentication(new CookieAuthenticationOptions()
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/account/")
			});
			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
		}
	}
}
