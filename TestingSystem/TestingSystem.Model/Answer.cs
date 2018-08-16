using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Model
{
    public class Answer
    {
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Required text")]
        public string Text { get; set; }
        public bool isCorrect { get; set; }

        public int? QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
