using System;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.DataProvider.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private TestContext db;
        private ThemeRepository _themeRepository;
        private TestRepository _testRepository;
        private QuestionRepository _questionRepository;

        public UnitOfWork()
        {
            db = new TestContext();
        }

        public IRepository<Theme> Themes
        {
            get
            {
                if (_themeRepository == null)
                    _themeRepository = new ThemeRepository(db);
                return _themeRepository;
            }
        }

        public IRepository<Test> Tests
        {
            get
            {
                if (_testRepository == null)
                    _testRepository = new TestRepository(db);
                return _testRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (_questionRepository == null)
                    _questionRepository = new QuestionRepository(db);
                return _questionRepository;
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
