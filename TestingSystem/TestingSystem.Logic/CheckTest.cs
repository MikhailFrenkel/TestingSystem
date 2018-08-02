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
            result.Questions = new List<QuestionViewModel>();
            foreach (var question in test.Questions)
            {
                result.Questions.Add(new QuestionViewModel(question));
            }

            for (int i = 0; i < result.Questions.Count; i++)
            {
                result.Questions[i].CorrectAnswers = tvm.Questions[i].CorrectAnswers;
            }

            for (int i = 0; i < tvm.Questions.Count; i++)
            {
                if (tvm.Questions[i].CorrectAnswers != null)
                {
                    Question question = test.Questions.Find(x => x.Id == tvm.Questions[i].Id);
                    if (question != null)
                    {
                        int temp = 0;
                        foreach (var answer in tvm.Questions[i].CorrectAnswers)
                        {
                            if (question.Answers.Find(x => x.Id == answer && x.isCorrect) != null)
                                temp++;

                            if (question.Answers.Find(x => x.Id == answer && !x.isCorrect) != null)
                                temp--;
                        }

                        if (temp == question.CorrectAnswer)
                            result.CountCorrectQuestion++;
                    }
                }
            }

            result.DateOfPassing = DateTime.Now;
            return result;
        }
    }
}
