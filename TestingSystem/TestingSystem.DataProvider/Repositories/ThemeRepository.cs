using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.DataProvider.Interfaces;
using TestingSystem.Model;
using System.Data.Entity;

namespace TestingSystem.DataProvider.Repositories
{
    class ThemeRepository : IRepository<Theme>
    {
        private TestContext db;

        public ThemeRepository(TestContext context)
        {
            this.db = context;
        }

        public void Create(Theme item)
        {
            db.Themes.Add(item);
        }

        public void Delete(int id)
        {
            Theme item = db.Themes.Find(id);
            if (item != null)
                db.Themes.Remove(item);
        }

        public IEnumerable<Theme> GetAll()
        {
            return db.Themes;
        }

        public Theme GetById(int id)
        {
            return db.Themes.Find(id);
        }

        public void Update(Theme item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
