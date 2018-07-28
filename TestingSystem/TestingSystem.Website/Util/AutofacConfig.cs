using Autofac;
using TestingSystem.DataProvider.Repositories;
using TestingSystem.Common.Interfaces;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.Model;
using TestingSystem.Website.Controllers;

namespace TestingSystem.Website.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(HomeController).Assembly).InstancePerRequest();
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();
            builder.RegisterType<AnswerRepository>().As<IRepository<Answer>>().InstancePerRequest();
            builder.RegisterType<QuestionRepository>().As<IRepository<Question>>().InstancePerRequest();
            builder.RegisterType<TestRepository>().As<IRepository<Test>>().InstancePerRequest();
            builder.RegisterType<ThemeRepository>().As<IRepository<Theme>>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}