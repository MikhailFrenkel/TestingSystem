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
        private ApplicationDbContext db;

        public TestRepository(ApplicationDbContext context)
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
            {
                foreach (var question in item.Questions)
                {
                    question.Test = null;
                    question.TestId = null;
                }
                db.Tests.Remove(item);
            }
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
    }
}
