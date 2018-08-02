using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Model.ViewModel
{
    public class ResultViewModel
    {
        [Required]
        public string TestName { get; set; }

        public int CountCorrectQuestion { get; set; }

        [Required]
        public int CountQuestions { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfPassing { get; set; }

        public IList<QuestionViewModel> Questions { get; set; }
    }
}
