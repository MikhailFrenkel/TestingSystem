using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Model
{
    public class Question
    {
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public int CorrectAnswer
        {
            get
            {
                int res = 0;
                foreach (var answer in Answers)
                {
                    if (answer.isCorrect)
                        res++;
                }
                return res;
            }
        }

        public int? TestId { get; set; }
        public virtual Test Test { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
