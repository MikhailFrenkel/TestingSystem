using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Model;

namespace TestingSystem.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Theme> Themes { get; }
        IRepository<Test> Tests { get; }
        IRepository<Question> Questions { get; }
        IRepository<Answer> Answers { get; }
        void Save();
    }
}
