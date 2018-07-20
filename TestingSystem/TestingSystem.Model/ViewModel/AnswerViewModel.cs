using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Model.ViewModel
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public AnswerViewModel(Answer answer)
        {
            Id = answer.Id;
            Text = answer.Text;
        }
    }
}
