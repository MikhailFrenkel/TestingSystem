using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.Website.Controllers.Admin
{
    public class QuestionController : Controller
    {
        private readonly IRepository<Test> _testRepository;
        private readonly IRepository<Question> _questionRepository;

        public QuestionController(IRepository<Test> test, IRepository<Question> question)
        {
            _testRepository = test;
            _questionRepository = question;
        }

        public ActionResult Index(int? testId)
        {
            if (testId != null)
            {
                Test test = _testRepository.GetById((int)testId);
                if (test != null)
                {
                    return View(test.Questions);
                }
            }
            return View(_questionRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            ViewBag.TestId = new SelectList(_testRepository.GetAll().ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,TestId")] Question question)
        {
            if (ModelState.IsValid)
            {
                _questionRepository.Create(question);
                _questionRepository.Save();
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
            ViewBag.TestId = new SelectList(_testRepository.GetAll().ToList(), "Id", "Name", question.TestId);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,TestId")] Question question)
        {
            if (ModelState.IsValid)
            {
                _questionRepository.Update(question);
                _questionRepository.Save();
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
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _questionRepository.Delete(id);
            _questionRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
