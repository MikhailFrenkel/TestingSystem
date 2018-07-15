using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Model
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public ICollection<Question> Questions { get; set; }
        public int ThemeId { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
