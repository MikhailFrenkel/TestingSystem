using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.Website.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public class AnswerController : Controller
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Answer> _answerRepository;

        public AnswerController(IRepository<Question> question, IRepository<Answer> answer)
        {
            _questionRepository = question;
            _answerRepository = answer;
        }

        public ActionResult Create(int? questionId)
        {
            if (questionId != null)
            {
                Question question = _questionRepository.GetById((int)questionId);
                if (question != null)
                    ViewBag.QuestionId = new SelectList(new List<Question> {question}, "Id", "Text");
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            
            else
                ViewBag.QuestionId = new SelectList(_questionRepository.GetAll().ToList(), "Id", "Text");

            ViewBag.UrlReferrer = Request.UrlReferrer?.ToString();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string urlReferrer, Answer answer)
        {
            if (ModelState.IsValid)
            {
                _answerRepository.Create(answer);
                _answerRepository.Save();
                if (!String.IsNullOrEmpty(urlReferrer))
                    return Redirect(urlReferrer);
                return RedirectToAction("Index", "Question");
            }
            if (!String.IsNullOrEmpty(urlReferrer))
                ViewBag.UrlReferrer = urlReferrer;
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

            ViewBag.UrlReferrer = Request.UrlReferrer?.ToString();
            ViewBag.QuestionId = new SelectList(_questionRepository.GetAll().ToList(), "Id", "Text", answer.QuestionId);
            return View(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string urlReferrer, Answer answer)
        {
            if (ModelState.IsValid)
            {
                _answerRepository.Update(answer);
                _answerRepository.Save();
                if (!String.IsNullOrEmpty(urlReferrer))
                    return Redirect(urlReferrer);
                return RedirectToAction("Index", "Question");
            }
            if (!String.IsNullOrEmpty(urlReferrer))
                ViewBag.UrlReferrer = urlReferrer;
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
            ViewBag.UrlReferrer = Request.UrlReferrer?.ToString();
            return View(answer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string urlReferrer, int id)
        {
            _answerRepository.Delete(id);
            _answerRepository.Save();
            if (!String.IsNullOrEmpty(urlReferrer))
                return Redirect(urlReferrer);
            return RedirectToAction("Index", "Question");
        }
    }
}
