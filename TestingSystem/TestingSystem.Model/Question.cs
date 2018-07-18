using System.Collections.Generic;

namespace TestingSystem.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

        public int? TestId { get; set; }
        public virtual Test Test { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
