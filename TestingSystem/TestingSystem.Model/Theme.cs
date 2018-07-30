using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Model
{
    public class Theme
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual List<Test> Tests { get; set; }
    }
}
