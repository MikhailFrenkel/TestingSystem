using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using PagedList;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.Website.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public class QuestionController : Controller
    {
        private readonly IRepository<Test> _testRepository;
        private readonly IRepository<Question> _questionRepository;

        public QuestionController(IRepository<Test> test, IRepository<Question> question)
        {
            _testRepository = test;
            _questionRepository = question;
        }

        public ActionResult Index(int? testId, int? questionId, int? page)
        {
            int pageSize = 4;
            int pageNumber = page ?? 1;
            List<Test> tests = new List<Test>() { new Test { Id = 0, Name = "All"} };
            tests.AddRange(_testRepository.GetAll().OrderBy(x => x.Name).ToList());
            ViewBag.TestId = new SelectList(tests, "Id", "Name");
            ViewBag.id = testId;
            ViewBag.qId = questionId;
            if (testId != null && testId != 0)
            {
                Test test = _testRepository.GetById((int)testId);
                if (test != null)
                {
                    return View(test.Questions.OrderBy(x => x.Test.Name).ToPagedList(pageNumber, pageSize));
                }
            }

            return View(_questionRepository.GetAll().OrderBy(x => x.Text).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            ViewBag.UrlReferrer = Request.UrlReferrer;
            ViewBag.TestId = new SelectList(_testRepository.GetAll().ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string urlReferrer, Question question)
        {
            if (ModelState.IsValid)
            {
                _questionRepository.Create(question);
                _questionRepository.Save();
                if (!String.IsNullOrEmpty(urlReferrer))
                    return Redirect(urlReferrer);
                return RedirectToAction("Index");
            }

            ViewBag.TestId = new SelectList(_testRepository.GetAll().ToList(), "Id", "Name", question.TestId);
            return View(question);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = _questionRepository.GetById((int)id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrlReferrer = Request.UrlReferrer;
            ViewBag.TestId = new SelectList(_testRepository.GetAll().ToList(), "Id", "Name", question.TestId);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string urlReferrer, Question question)
        {
            if (ModelState.IsValid)
            {
                _questionRepository.Update(question);
                _questionRepository.Save();
                if (!String.IsNullOrEmpty(urlReferrer))
                    return Redirect(urlReferrer);
                return RedirectToAction("Index");
            }
            ViewBag.TestId = new SelectList(_testRepository.GetAll().ToList(), "Id", "Name", question.TestId);
            return View(question);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = _questionRepository.GetById((int)id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrlReferrer = Request.UrlReferrer;
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string urlReferrer, int id)
        {
            _questionRepository.Delete(id);
            _questionRepository.Save();
            if (!String.IsNullOrEmpty(urlReferrer))
                return Redirect(urlReferrer);
            return RedirectToAction("Index");
        }

        public ActionResult Select(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            List<Answer> answers = _questionRepository.GetById((int)id).Answers.ToList();
            ViewBag.QuestionId = id;
            return PartialView(answers);
        }
    }
}
