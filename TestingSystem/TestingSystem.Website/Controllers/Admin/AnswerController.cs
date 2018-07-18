using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.Website.Controllers.Admin
{
    public class AnswerController : Controller
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Answer> _answerRepository;

        public AnswerController(IRepository<Question> question, IRepository<Answer> answer)
        {
            _questionRepository = question;
            _answerRepository = answer;
        }

        public ActionResult Index(int? questionId)
        {
            if (questionId != null)
            {
                Question question = _questionRepository.GetById((int)questionId);
                if (question != null)
                {
                    return View(question.Answers);
                }
            }
            return View(_answerRepository.GetAll().ToList());
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
