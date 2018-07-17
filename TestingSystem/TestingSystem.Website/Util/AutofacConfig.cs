using System;
using System.Collections.Generic;
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
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterType<AnswerRepository>().As<IRepository<Answer>>().WithParameter("context", new TestContext());
            builder.RegisterType<QuestionRepository>().As<IRepository<Question>>().WithParameter("context", new TestContext());
            builder.RegisterType<TestRepository>().As<IRepository<Test>>().WithParameter("context", new TestContext());
            builder.RegisterType<ThemeRepository>().As<IRepository<Theme>>().WithParameter("context", new TestContext());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}