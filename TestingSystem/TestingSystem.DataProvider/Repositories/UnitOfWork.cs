using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.DataProvider.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private TestContext db;
        private ThemeRepository themeRepository;
        private TestRepository testRepository;
        private QuestionRepository questionRepository;

        public UnitOfWork()
        {
            db = new TestContext();
        }

        public IRepository<Theme> Themes
        {
            get
            {
                if (themeRepository == null)
                    themeRepository = new ThemeRepository(db);
                return themeRepository;
            }
        }

        public IRepository<Test> Tests
        {
            get
            {
                if (testRepository == null)
                    testRepository = new TestRepository(db);
                return testRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionRepository(db);
                return questionRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
