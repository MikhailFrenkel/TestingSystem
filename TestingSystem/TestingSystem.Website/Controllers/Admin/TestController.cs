using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using TestingSystem.Common.Interfaces;
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

        public ActionResult Index(int? themeId, int? page)
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;
            List<Theme> themes = new List<Theme>() {new Theme {Id = 0, Title = "All"} };
            themes.AddRange(_themeRepository.GetAll().OrderBy(x => x.Title).ToList());
            ViewBag.ThemeId = new SelectList(themes, "Id", "Title");
            ViewBag.id = themeId;
            if (themeId != null && themeId != 0)
            {
                Theme theme = _themeRepository.GetById((int)themeId);
                if (theme != null)
                {
                    return View(theme.Tests.OrderBy(x => x.Theme.Title).ToPagedList(pageNumber, pageSize));
                }
            }
            return View(_testRepository.GetAll().OrderBy(x => x.Theme.Title).ToPagedList(pageNumber, pageSize));
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
    }
}
