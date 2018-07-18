using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.Repositories
{
    public class TestRepository : IRepository<Test>
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

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Test> GetAll()
        {
            return db.Tests.ToList();
        }

        public Test GetById(int id)
        {
            return db.Tests.Find(id);
        }

        public void Update(Test item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /*private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }*/
    }
}
