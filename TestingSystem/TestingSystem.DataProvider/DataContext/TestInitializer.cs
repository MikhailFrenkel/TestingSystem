using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.DataContext
{
    public class TestInitializer : DropCreateDatabaseIfModelChanges<TestContext>
    {
        protected override void Seed(TestContext db)
        {
            List<Answer> _answers = new List<Answer>()
            {
                new Answer() { Id = 1, Text = "a1", },
                new Answer() { Id = 2, Text = "a2", },
                new Answer() { Id = 3, Text = "a3", },
                new Answer() { Id = 4, Text = "a4", }
            };

            List<Question> q1 = new List<Question>()
            {
                new Question() {
                    Id = 1,
                    Text = "Выберите a2",
                    CorrectAnswers = _answers.GetRange(1, 1),
                    Answers = _answers
                }
            };

            List<Test> t1 = new List<Test>()
            {
                new Test() {
                    Id = 1,
                    Name = "Базовые понятия C#",
                    Description = "что-то здесь будет",
                    Duration = 15,
                    Questions = q1
                }
            };

            List<Theme> _themes = new List<Theme>()
            {
                new Theme
                {
                    Id = 1,
                    Title = "Программирование",
                    Tests = t1
                }
            };

            db.Answers.AddRange(_answers);
            db.Questions.AddRange(q1);
            db.Tests.AddRange(t1);
            db.Themes.AddRange(_themes);
            db.SaveChanges();
            base.Seed(db);
        }
    }
}
