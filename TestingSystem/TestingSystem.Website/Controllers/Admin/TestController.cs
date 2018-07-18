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
    public class TestController : Controller
    {
        private readonly IRepository<Theme> _themeRepository;
        private readonly IRepository<Test> _testRepository;

        public TestController(IRepository<Theme> theme, IRepository<Test> test)
        {
            _themeRepository = theme;
            _testRepository = test;
        }

        public ActionResult Index()
        {
            return View(_testRepository.GetAll().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _testRepository.GetById((int)id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        public ActionResult Create()
        {
            ViewBag.ThemeId = new SelectList(_themeRepository.GetAll().ToList(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Duration,ThemeId")] Test test)
        {
            if (ModelState.IsValid)
            {
                _testRepository.Create(test);
                _testRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ThemeId = new SelectList(_themeRepository.GetAll().ToList(), "Id", "Title", test.ThemeId);
            return View(test);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _testRepository.GetById((int)id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThemeId = new SelectList(_themeRepository.GetAll().ToList(), "Id", "Title", test.ThemeId);
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Duration,ThemeId")] Test test)
        {
            if (ModelState.IsValid)
            {
                _testRepository.Update(test);
                _testRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ThemeId = new SelectList(_themeRepository.GetAll().ToList(), "Id", "Title", test.ThemeId);
            return View(test);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _testRepository.GetById((int)id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _testRepository.Delete(id);
            _testRepository.Save();
            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _testRepository.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
