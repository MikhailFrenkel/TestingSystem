using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.Website.Controllers.Admin
{
    public class ThemeController : Controller
    {
        private readonly IRepository<Theme> _themeRepository;

        public ThemeController(IRepository<Theme> theme)
        {
            _themeRepository = theme;
        }

        public ActionResult Index()
        {
            return View(_themeRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] Theme theme)
        {
            if (ModelState.IsValid)
            {
                _themeRepository.Create(theme);
                _themeRepository.Save();
                return RedirectToAction("Index");
            }

            return View(theme);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = _themeRepository.GetById((int)id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] Theme theme)
        {
            if (ModelState.IsValid)
            {
                _themeRepository.Update(theme);
                _themeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(theme);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = _themeRepository.GetById((int)id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _themeRepository.Delete(id);
            _themeRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
