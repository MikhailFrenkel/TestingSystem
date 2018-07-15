using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<Answer> CorrectAnswers { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public int TestId { get; set; }

        public Question()
        {
            CorrectAnswers = new List<Answer>();
            Answers = new List<Answer>();
        }

    }
}
