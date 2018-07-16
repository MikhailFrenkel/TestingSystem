using System;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Theme> Themes { get; }
        IRepository<Test> Tests { get; }
        IRepository<Question> Questions { get; }
        void Save();
    }
}
