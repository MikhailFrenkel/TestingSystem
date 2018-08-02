using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingSystem.Model.ViewModel;

namespace TestingSystem.Model
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public virtual List<Answer> Answers { get; set; }

        public int CorrectAnswer
        {
            get
            {
                if (Answers != null)
                {
                    int res = 0;
                    foreach (var answer in Answers)
                    {
                        if (answer.isCorrect)
                            res++;
                    }

                    return res;
                }

                return 0;
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
