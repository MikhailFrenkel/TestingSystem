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
        public IEnumerable<Answer> CorrectAnswers { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public int TestId { get; set; }
    }
}
