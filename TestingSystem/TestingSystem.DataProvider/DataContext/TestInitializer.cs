using System.Collections.Generic;
using System.Data.Entity;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.DataContext
{
    public class TestInitializer : DropCreateDatabaseIfModelChanges<TestContext>
    {
        protected override void Seed(TestContext db)
        {
            /*List<Answer> answers = new List<Answer>()
            {
                new Answer() { Text = "a1", isCorrect = false },
                new Answer() { Text = "a2", isCorrect = true },
                new Answer() { Text = "a3", isCorrect = false },
                new Answer() { Text = "a4", isCorrect = false }
            };

            List<Question> q1 = new List<Question>()
            {
                new Question()
                {
                    Text = "Выберите a2",
                    Answers = answers
                }
            };

            List<Test> t1 = new List<Test>()
            {
                new Test()
                {
                    Name = "Базовые понятия C#",
                    Description = "что-то здесь будет",
                    Duration = 15,
                    Questions = q1
                }
            };

            List<Theme> themes = new List<Theme>()
            {
                new Theme
                {
                    Title = "Программирование",
                    Tests = t1
                }
            };*/

            List<Theme> themes = new List<Theme>()
            {
                new Theme
                {
                    Title = "Программирование",
                    Tests = new List<Test>()
                    {
                        new Test()
                        {
                            Name = "Базовые понятия C#",
                            Description = "что-то здесь будет",
                            Duration = 15,
                            Questions = new List<Question>()
                            {
                                new Question()
                                {
                                    Text = "Выберите a2",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer() { Text = "a1", isCorrect = false },
                                        new Answer() { Text = "a2", isCorrect = true },
                                        new Answer() { Text = "a3", isCorrect = false },
                                        new Answer() { Text = "a4", isCorrect = false }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            /*db.Answers.AddRange(answers);
            db.Questions.AddRange(q1);
            db.Tests.AddRange(t1);*/
            db.Themes.AddRange(themes);
            db.SaveChanges();
            base.Seed(db);
        }
    }
}
