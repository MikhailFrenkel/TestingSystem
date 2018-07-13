using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.DataContext
{
    public class TestInitializer : DropCreateDatabaseAlways<TestContext>
    {
        protected override void Seed(TestContext db)
        {
            db.Themes.Add(new Theme { Id = 1, Title = "Программирование" });
            db.Tests.Add(new Test
            {
                Id = 1,
                Name = "Базовые понятия C#",
                Description = "что-то здесь будет",
                ThemeId = 1
            });
            db.Tests.Add(new Test
            {
                Id = 2,
                Name = "ООП",
                Description = "что-то здесь будет",
                ThemeId = 1
            });

            base.Seed(db);
        }
    }
}
