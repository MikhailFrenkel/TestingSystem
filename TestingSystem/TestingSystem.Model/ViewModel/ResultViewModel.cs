using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Model.ViewModel
{
    public class ResultViewModel
    {
        public string TestName { get; set; }
        public int CountCorrectQuestion { get; set; }
        public int CountQuestions { get; set; }
    }
}
