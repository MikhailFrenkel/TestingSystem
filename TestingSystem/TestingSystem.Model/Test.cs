using System.Collections.Generic;

namespace TestingSystem.Model
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public int? ThemeId { get; set; }
        public virtual Theme Theme { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
