using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.Website.Controllers.Admin
{
    public class AnswerController : Controller
    {
        private readonly IRepository<Test> _testRepository;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Answer> _answerRepository;

        public AnswerController(IRepository<Test> test, IRepository<Question> question, IRepository<Answer> answer)
        {
            _testRepository = test;
            _questionRepository = question;
            _answerRepository = answer;
        }

        public ActionResult Index(int? testId, int? page)
        {
            int pageSize = 3;
            int pageNumber = page ?? 1;
            List<Test> tests = new List<Test>() { new Test { Id = 0, Name = "All" } };
            tests.AddRange(_testRepository.GetAll().OrderBy(x => x.Name).ToList());
            ViewBag.TestId = new SelectList(tests, "Id", "Name");
            ViewBag.id = testId;
            if (testId != null && testId != 0)
            {
                Test test = _testRepository.GetById((int)testId);
                if (test != null)
                {
                    return View(_answerRepository.GetAll().Where(x => x.Question.TestId == testId).ToPagedList(pageNumber, pageSize));
                }
            }
            return View(_answerRepository.GetAll().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(_questionRepository.GetAll().ToList(), "Id", "Text");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,isCorrect,QuestionId")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                _answerRepository.Create(answer);
                _answerRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(_questionRepository.GetAll().ToList(), "Id", "Text", answer.QuestionId);
            return View(answer);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = _answerRepository.GetById((int)id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(_questionRepository.GetAll().ToList(), "Id", "Text", answer.QuestionId);
            return View(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,isCorrect,QuestionId")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                _answerRepository.Update(answer);
                _answerRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(_questionRepository.GetAll().ToList(), "Id", "Text", answer.QuestionId);
            return View(answer);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = _answerRepository.GetById((int)id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _answerRepository.Delete(id);
            _answerRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
