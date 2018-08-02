using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Model.Identity;
using TestingSystem.Model.ViewModel;

namespace TestingSystem.Model
{
    public class Result
    {
        public int Id { get; set; }

        public string TestName { get; set; }

        public int CountCorrectQuestion { get; set; }

        public int CountQuestions { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfPassing { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public Result()
        {
        }

        public Result(ResultViewModel rvm, ApplicationUser user)
        {
            TestName = rvm.TestName;
            CountCorrectQuestion = rvm.CountCorrectQuestion;
            CountQuestions = rvm.CountQuestions;
            DateOfPassing = rvm.DateOfPassing;
            ApplicationUser = user;
            ApplicationUserId = user.Id;
        }
    }
}
