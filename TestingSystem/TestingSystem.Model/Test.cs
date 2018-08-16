using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Model
{
    public class Test
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required duration")]
        [Range(1, 1000,ErrorMessage = "Required duration between 1 and 1000")]
        public int Duration { get; set; }

        public virtual List<Question> Questions { get; set; }

        public byte[] Image { get; set; }
    }
}
