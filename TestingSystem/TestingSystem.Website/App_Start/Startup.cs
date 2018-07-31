using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using TestingSystem.DataProvider.DataContext;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using TestingSystem.DataProvider.Manager;

[assembly: OwinStartup(typeof(TestingSystem.Website.Startup))]
namespace TestingSystem.Website
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}