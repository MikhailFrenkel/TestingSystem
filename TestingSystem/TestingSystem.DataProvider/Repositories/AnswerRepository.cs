using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.Repositories
{
    public class AnswerRepository : IRepository<Answer>
    {
        private TestContext db;

        public AnswerRepository(TestContext context)
        {
            db = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return db.Answers.ToList();
        }

        public Answer GetById(int id)
        {
            return db.Answers.Find(id);
        }

        public void Create(Answer item)
        {
            db.Answers.Add(item);
        }

        public void Update(Answer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Answer item = db.Answers.Find(id);
            if (item != null)
                db.Answers.Remove(item);
        }

        public void Save()
        {
            db.SaveChanges();
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
