using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.DataProvider.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.Repositories
{
    class QuestionRepository : IRepository<Question>
    {
        private TestContext db;

        public QuestionRepository(TestContext context)
        {
            this.db = context;
        }

        public void Create(Question item)
        {
            db.Questions.Add(item);
        }

        public void Delete(int id)
        {
            Question item = db.Questions.Find(id);
            if (item != null)
                db.Questions.Remove(item);
        }

        public IEnumerable<Question> GetAll()
        {
            return db.Questions;
        }

        public Question GetById(int id)
        {
            return db.Questions.Find(id);
        }

        public void Update(Question item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
