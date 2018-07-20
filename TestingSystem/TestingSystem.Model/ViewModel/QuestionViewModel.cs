using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Model.ViewModel
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        [Required]
        public List<int> CorrectAnswers { get; set; }
        public virtual List<AnswerViewModel> Answers { get; set; }

        public QuestionViewModel(Question question)
        {
            Id = question.Id;
            Text = question.Text;
            Answers = new List<AnswerViewModel>();
            CorrectAnswers = new List<int>();
            foreach (var answer in question.Answers)
            {
                if (answer.isCorrect)
                    CorrectAnswers.Add(answer.Id);
                Answers.Add(new AnswerViewModel(answer));
            }
        }
    }
}
