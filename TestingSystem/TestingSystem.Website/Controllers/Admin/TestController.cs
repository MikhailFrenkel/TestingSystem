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
    public class TestController : Controller
    {
        private UnitOfWork _unitOfWork;

        public TestController()
        {
            _unitOfWork = new UnitOfWork();
        }

        // GET: Test
        public ActionResult Index()
        {
            return View(_unitOfWork.Tests.GetAll());
        }

        [HttpGet]
        public ActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTest(Test test)
        {
            _unitOfWork.Tests.Create(test);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteTest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _unitOfWork.Tests.GetById((int)id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        [HttpPost, ActionName("DeleteTest")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTestConfirmed(int id)
        {
            _unitOfWork.Tests.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult EditTest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _unitOfWork.Tests.GetById((int)id);
            if (test == null)
                return HttpNotFound();
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTest(Test test)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tests.Update(test);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(test);
        }
    }
}