using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Model
{
    public class Test
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Range(1, 1000)]
        public int Duration { get; set; }
        public virtual List<Question> Questions { get; set; }

        public int? ThemeId { get; set; }
        public virtual Theme Theme { get; set; }

    }
}
