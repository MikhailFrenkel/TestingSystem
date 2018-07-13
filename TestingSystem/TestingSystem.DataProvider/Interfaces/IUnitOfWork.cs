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
        IRepository<Theme> Themes { get; set; }
        IRepository<Test> Tests { get; set; }
        IRepository<Question> Questions { get; set; }
        void Save();
    }
}
