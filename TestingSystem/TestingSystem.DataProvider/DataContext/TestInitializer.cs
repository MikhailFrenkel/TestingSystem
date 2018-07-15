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
            Answer a1 = new Answer
            {
                Id = 1,
                Text = "a1"
            };

            Answer a2 = new Answer
            {
                Id = 2,
                Text = "a2"
            };

            Answer a3 = new Answer
            {
                Id = 1,
                Text = "a3"
            };

            Answer a4 = new Answer
            {
                Id = 2,
                Text = "a4"
            };

            Question q1 = new Question
            {
                Id = 1,
                Text = "Выберите a2",
                CorrectAnswers = new List<Answer>() { a2 },
                Answers = new List<Answer>() { a1, a2, a3, a4 },
                TestId = 1
            };

            Test t1 = new Test {
                Id = 1,
                Name = "Базовые понятия C#",
                Description = "что-то здесь будет",
                ThemeId = 1,
                Questions = new List<Question>() { q1 }
            };


            db.Answers.Add(a1);
            db.Answers.Add(a2);
            db.Answers.Add(a3);
            db.Answers.Add(a4);
            db.Questions.Add(q1);
            db.Tests.Add(t1);
            db.Themes.Add(new Theme { Id = 1, Title = "Программирование", Tests  = new List<Test>() { t1 } });
            db.SaveChanges();
            base.Seed(db);
        }
    }
}
