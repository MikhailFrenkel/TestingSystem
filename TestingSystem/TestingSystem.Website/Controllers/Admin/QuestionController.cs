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
    public class QuestionController : Controller
    {
        private readonly IRepository<Test> _testRepository;
        private readonly IRepository<Question> _questionRepository;

        public QuestionController(IRepository<Test> test, IRepository<Question> question)
        {
            _testRepository = test;
            _questionRepository = question;
        }

        public ActionResult Index()
        {
            return View(_questionRepository.GetAll().ToList());
        }

        public ActionResult Details(int? id)
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
