using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Common.Interfaces;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.Model;
using TestingSystem.Model.ViewModel;

namespace TestingSystem.DataProvider.Repositories
{
    public class ResultRepository : IRepository<Result>
    {
        private ApplicationDbContext db;

        public ResultRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Result> GetAll()
        {
            return db.Results.ToList();
        }

        public Result GetById(int id)
        {
            return db.Results.Find(id);
        }

        public void Create(Result item)
        {
            db.Results.Add(item);
        }

        public void Update(Result item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Result item = db.Results.Find(id);
            if (item != null)
                db.Results.Remove(item);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
