using System.Collections.Generic;

namespace TestingSystem.Model
{
    public class Theme
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
