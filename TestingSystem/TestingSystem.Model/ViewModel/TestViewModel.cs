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
        public IList<QuestionViewModel> Questions { get; set; }

        public TestViewModel()
        {
        }

        public TestViewModel(Test test)
        {
            Id = test.Id;
            Name = test.Name;
            Questions = new List<QuestionViewModel>();
            foreach (var question in test.Questions)
            {
                Questions.Add(new QuestionViewModel(question));
            }
        }
    }
}
