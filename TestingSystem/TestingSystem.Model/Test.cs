using System.Collections.Generic;

namespace TestingSystem.Model
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public ICollection<Question> Questions { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
