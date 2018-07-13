using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
