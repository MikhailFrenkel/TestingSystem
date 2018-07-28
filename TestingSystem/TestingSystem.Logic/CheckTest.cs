using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Model;
using TestingSystem.Model.ViewModel;

namespace TestingSystem.Logic
{
    public static class CheckTest
    {
        public static ResultViewModel Check(Test test, TestViewModel tvm)
        {
            ResultViewModel result = new ResultViewModel();
            result.TestName = test.Name;
            result.CountQuestions = test.Questions.Count;
            for (int i = 0; i < test.Questions.Count; i++)
            {
                int temp = 0;
                foreach (var id in tvm.Questions[i].CorrectAnswers)
                {
                    if (test.Questions[i].Answers.FirstOrDefault(x => x.Id == id && x.isCorrect) != null)
                    {
                        temp++;
                    }
                }

                if (temp == test.Questions[i].CorrectAnswer)
                    result.CountCorrectQuestion++;
            }

            return result;
        }
    }
}
