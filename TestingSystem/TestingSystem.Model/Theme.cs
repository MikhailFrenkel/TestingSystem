using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Model
{
    public class Theme
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
