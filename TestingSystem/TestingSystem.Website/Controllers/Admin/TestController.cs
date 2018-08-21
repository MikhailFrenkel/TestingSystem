using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;

namespace TestingSystem.Website.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public class TestController : Controller
    {
        private readonly IRepository<Test> _testRepository;

        public TestController(IRepository<Test> test)
        {
            _testRepository = test;
        }

        public ActionResult Index(string searchString, int? page)
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();
                if (!String.IsNullOrEmpty(searchString))
                {
                    List<Test> tests = _testRepository.GetAll().Where(x => x.Name.Contains(searchString)).ToList();
                    return View(tests.ToPagedList(pageNumber, pageSize));
                }
            }

            return View(_testRepository.GetAll().OrderBy(x => x.Name).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            ViewBag.UrlReferrer = Request.UrlReferrer;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string urlReferrer, Test test, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    if (uploadImage.ContentType == "image/jpg" || uploadImage.ContentType == "image/png")
                    {
                        test.ExtensionImage = uploadImage.ContentType;
                        test.Image = new byte[uploadImage.ContentLength];
                        uploadImage.InputStream.Read(test.Image, 0, uploadImage.ContentLength);
                    }
                }
                _testRepository.Create(test);
                _testRepository.Save();
                if (!String.IsNullOrEmpty(urlReferrer))
                    return Redirect(urlReferrer);
                return RedirectToAction("Index");
            }
            if (!String.IsNullOrEmpty(urlReferrer))
                ViewBag.UrlReferrer = urlReferrer;
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
            ViewBag.UrlReferrer = Request.UrlReferrer;
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string urlReferrer, Test test, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    if (uploadImage.ContentType == "image/jpg" || uploadImage.ContentType == "image/png")
                    {
                        test.ExtensionImage = uploadImage.ContentType;
                        test.Image = new byte[uploadImage.ContentLength];
                        uploadImage.InputStream.Read(test.Image, 0, uploadImage.ContentLength);
                    }
                }
                _testRepository.Update(test);
                _testRepository.Save();
                if (!String.IsNullOrEmpty(urlReferrer))
                    return Redirect(urlReferrer);
                return RedirectToAction("Index");
            }
            if (!String.IsNullOrEmpty(urlReferrer))
                ViewBag.UrlReferrer = urlReferrer;
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
            ViewBag.UrlReferrer = Request.UrlReferrer;
            return View(test);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string urlReferrer, int id)
        {
            _testRepository.Delete(id);
            _testRepository.Save();
            if (!String.IsNullOrEmpty(urlReferrer))
                return Redirect(urlReferrer);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public FileContentResult GetImage(int id)
        {
            Test test = _testRepository.GetById(id);
            if (test?.Image != null)
            {
                return File(test.Image, test.ExtensionImage);
            }

            return null;
        }
    }
}
