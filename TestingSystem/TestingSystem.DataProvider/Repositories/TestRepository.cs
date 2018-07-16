using System.Collections.Generic;
using System.Data.Entity;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.DataProvider.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.Repositories
{
    class TestRepository : IRepository<Test>
    {
        private TestContext db;

        public TestRepository(TestContext context)
        {
            db = context;
        }

        public void Create(Test item)
        {
            db.Tests.Add(item);
        }

        public void Delete(int id)
        {
            Test item = db.Tests.Find(id);
            if (item != null)
                db.Tests.Remove(item);
        }

        public IEnumerable<Test> GetAll()
        {
            return db.Tests;
        }

        public Test GetById(int id)
        {
            return db.Tests.Find(id);
        }

        public void Update(Test item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
