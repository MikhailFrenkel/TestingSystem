using System.Collections.Generic;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;
using System.Data.Entity;
using System.Linq;

namespace TestingSystem.DataProvider.Repositories
{
    public class ThemeRepository : IRepository<Theme>
    {
        private TestContext db;

        public ThemeRepository(TestContext context)
        {
            db = context;
        }

        public void Create(Theme item)
        {
            db.Themes.Add(item);
        }

        public void Delete(int id)
        {
            Theme item = db.Themes.Find(id);
            if (item != null)
            {
                foreach(var test in item.Tests)
                {
                    test.Theme = null;
                    test.ThemeId = null;
                }
                db.Themes.Remove(item);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Theme> GetAll()
        {
            return db.Themes.ToList();
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
