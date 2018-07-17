using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestingSystem.DataProvider.Repositories;
using TestingSystem.Model;

namespace TestingSystem.Website.Controllers.Admin
{
    public class ThemeController : Controller
    {
        private UnitOfWork _unitOfWork;

        public ThemeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View(_unitOfWork.Themes.GetAll());
        }

        [HttpGet]
        public ActionResult CreateTheme()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTheme(Theme theme)
        {
            _unitOfWork.Themes.Create(theme);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteTheme(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = _unitOfWork.Themes.GetById((int)id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        [HttpPost, ActionName("DeleteTheme")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteThemeConfirmed(int id)
        {
            _unitOfWork.Themes.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult EditTheme(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = _unitOfWork.Themes.GetById((int)id);
            if (theme == null)
                return HttpNotFound();
            return View(theme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTheme(Theme theme)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Themes.Update(theme);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(theme);
        }
    }
}