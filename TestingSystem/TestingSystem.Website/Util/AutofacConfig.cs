using System.Net;
using System.Web;
using Autofac;
using TestingSystem.DataProvider.Repositories;
using TestingSystem.Common.Interfaces;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.DataProvider.Manager;
using TestingSystem.Model;
using TestingSystem.Model.Identity;
using TestingSystem.Website.Controllers;

namespace TestingSystem.Website.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(HomeController).Assembly).InstancePerRequest();

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(x => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();

            builder.RegisterType<ResultRepository>().As<IRepository<Result>>().InstancePerRequest();
            builder.RegisterType<AnswerRepository>().As<IRepository<Answer>>().InstancePerRequest();
            builder.RegisterType<QuestionRepository>().As<IRepository<Question>>().InstancePerRequest();
            builder.RegisterType<TestRepository>().As<IRepository<Test>>().InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}