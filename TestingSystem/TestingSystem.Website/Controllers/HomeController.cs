﻿using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TestingSystem.Common.Interfaces;
using TestingSystem.DataProvider.Manager;
using TestingSystem.Model;
using TestingSystem.Model.ViewModel;
using TestingSystem.Logic;
using TestingSystem.Model.Identity;

namespace TestingSystem.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Result> _resultRepository;
        private readonly IRepository<Test> _testRepository;
        private readonly ApplicationUserManager _userManager;

        public HomeController(IRepository<Result> result, IRepository<Test> test, ApplicationUserManager userManager)
        {
            _testRepository = test;
            _resultRepository = result;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View(_testRepository.GetAll().ToList());
        }

        public ActionResult Test(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _testRepository.GetById((int)id);
            if (test == null)
                return HttpNotFound();
            TestViewModel tvm = new TestViewModel(test);
            return View(tvm);
        }

        [Authorize(Roles = "user")]
        public ActionResult StartTest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _testRepository.GetById((int)id);
            if (test == null)
                return HttpNotFound();
            if (test.Questions?.Count == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TestViewModel tvm = new TestViewModel(test);
            return View(tvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user")]
        public ActionResult StartTest(TestViewModel tvm)
        {
            if (ModelState.IsValid)
            {
                TempData["tvm"] = tvm;
                return RedirectToAction("Result");
            }
            tvm = new TestViewModel(_testRepository.GetById(tvm.Id));
            return View(tvm);
        }

        [Authorize(Roles = "user")]
        public ActionResult Result()
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TestViewModel tvm = TempData["tvm"] as TestViewModel;
            if (tvm == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ResultViewModel rvm = CheckTest.Check(_testRepository.GetById(tvm.Id), tvm);
            ApplicationUser user = _userManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                Result userResult = new Result(rvm, user);
                _resultRepository.Create(userResult);
                _resultRepository.Save();
            }

            return View(rvm);
        }
    }
}