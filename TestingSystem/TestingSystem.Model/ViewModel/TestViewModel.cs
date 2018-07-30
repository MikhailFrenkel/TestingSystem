using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Model.ViewModel
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public IList<QuestionViewModel> Questions { get; set; }

        public TestViewModel()
        {
        }

        public TestViewModel(Test test)
        {
            Id = test.Id;
            Name = test.Name;
            Duration = test.Duration;
            Description = test.Description;
            Questions = new List<QuestionViewModel>();
            foreach (var question in test.Questions)
            {
                Questions.Add(new QuestionViewModel(question));
            }
        }

        public bool IsCanPass
        {
            get
            {
                if (Questions == null)
                {
                    return false;
                }

                if (Questions.Count == 0)
                {
                    return false;
                }

                foreach (var question in Questions)
                {
                    if (!question.IsCanPass)
                        return false;
                }

                return true;
            }
        }
    }
}
