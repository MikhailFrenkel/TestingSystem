using System.Collections.Generic;
using System.Data.Entity;
using TestingSystem.Model;

namespace TestingSystem.DataProvider.DataContext
{
    public class TestInitializer : DropCreateDatabaseIfModelChanges<TestContext>
    {
        protected override void Seed(TestContext db)
        {

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
                        },

                        new Test()
                        {
                            Name = "ООП",
                            Description = "Базовые понятия по ООП",
                            Duration = 10,
                            Questions = new List<Question>()
                            {
                                new Question()
                                {
                                    Text = "Как называется способность объекта скрывать свои данные и реализацию от других объектов системы?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer() { Text = "инкапсуляция", isCorrect = true },
                                        new Answer() { Text = "полиморфизм", isCorrect = false },
                                        new Answer() { Text = "наследование", isCorrect = false },
                                        new Answer() { Text = "агрегация", isCorrect = false }
                                    }
                                },
                                new Question()
                                {
                                    Text = "В чем отличие абстрактного класса от интерфейса?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer() { Text = "класс содержит поля и методы, интерфейс – только методы", isCorrect = false },
                                        new Answer() { Text = "класс содержит конструкторы и методы, интерфейс – только методы", isCorrect = false },
                                        new Answer() { Text = "класс определяет сущность, интерфейс определяет поведение", isCorrect = true },
                                        new Answer() { Text = "объект абстрактного класса можно создать, объект интерфейса - нет", isCorrect = false }
                                    }
                                },
                                new Question()
                                {
                                    Text = "Свойство класса это?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer() { Text = "метод, возвращающий количество полей класса", isCorrect = false },
                                        new Answer() { Text = "метод, устанавливающий или возвращающий значение поля", isCorrect = true },
                                        new Answer() { Text = "метод, позволяющий устанавливать значение поля", isCorrect = false },
                                        new Answer() { Text = "метод, возвращающий значение поля", isCorrect = false }
                                    }
                                },
                                new Question()
                                {
                                    Text = "Singleton это?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer() { Text = "объект, реализующий некоторый интерфейс путем обращения к другому объекту через свойственный ему интерфейс", isCorrect = false },
                                        new Answer() { Text = "класс, не имеющий объектов", isCorrect = false },
                                        new Answer() { Text = "объект-заместитель, перенаправляющий вызовы к замещаемому тяжеловесному объекту", isCorrect = false },
                                        new Answer() { Text = "объект, создаваемый в единственном экземпляре", isCorrect = true }
                                    }
                                },
                                new Question()
                                {
                                    Text = "Класс, параметризованный типом данных называется?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer() { Text = "трафарет", isCorrect = false },
                                        new Answer() { Text = "модель", isCorrect = false },
                                        new Answer() { Text = "шаблон", isCorrect = true },
                                        new Answer() { Text = "стандарт", isCorrect = false }
                                    }
                                },
                                new Question()
                                {
                                    Text = "За счёт чего реализуется принцип полиморфизма?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer() { Text = "наличия абстрактных классов", isCorrect = false },
                                        new Answer() { Text = "наличия виртуальных методов", isCorrect = true },
                                        new Answer() { Text = "наличия множественного наследования", isCorrect = false },
                                        new Answer() { Text = "наличия интерфейсов", isCorrect = false }
                                    }
                                },
                                new Question()
                                {
                                    Text = "В каком отношении могут быть объекты?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer() { Text = "базовом", isCorrect = false },
                                        new Answer() { Text = "композиции", isCorrect = true },
                                        new Answer() { Text = "агрегации", isCorrect = true },
                                        new Answer() { Text = "наследовании", isCorrect = true }
                                    }
                                },
                                new Question()
                                {
                                    Text = "Какие патерны являются структурными?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer() { Text = "Итератор", isCorrect = false },
                                        new Answer() { Text = "Компоновщик", isCorrect = true },
                                        new Answer() { Text = "Адаптер", isCorrect = true },
                                        new Answer() { Text = "Одинчка", isCorrect = false }
                                    }
                                },
                                new Question()
                                {
                                    Text = "Выберите верныя утверждения для паттерна декоратор:",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer() { Text = "структурный паттерн", isCorrect = true },
                                        new Answer() { Text = "создаётся в единственном экземпляре", isCorrect = false },
                                        new Answer() { Text = "добавляет новые обязанности объекту", isCorrect = true },
                                        new Answer() { Text = "паттерн поведения", isCorrect = false }
                                    }
                                },
                                new Question()
                                {
                                    Text = " Для какого из перечисленных паттернов лучше всего подходит метафора \"матрешки\"?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer() { Text = "Итератор", isCorrect = false },
                                        new Answer() { Text = "Прототип", isCorrect = false },
                                        new Answer() { Text = "Декоратор", isCorrect = true },
                                        new Answer() { Text = "Абстрактная фабрика", isCorrect = false }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            db.Themes.AddRange(themes);
            db.SaveChanges();
            base.Seed(db);
        }
    }
}
