using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestingSystem.Common.Interfaces;
using TestingSystem.DataProvider.DataContext;
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

        // GET: Answer
        public ActionResult Index()
        {
            return View(_answerRepository.GetAll().ToList());
        }

        // GET: Answer/Details/5
        public ActionResult Details(int? id)
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

        // GET: Answer/Create
        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(_questionRepository.GetAll().ToList(), "Id", "Text");
            return View();
        }

        // POST: Answer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Answer/Edit/5
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

        // POST: Answer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Answer/Delete/5
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

        // POST: Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _answerRepository.Delete(id);
            _answerRepository.Save();
            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
