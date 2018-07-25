using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestingSystem.Common.Interfaces;
using TestingSystem.Model;
using TestingSystem.Model.ViewModel;

namespace TestingSystem.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Answer> _answerRepository;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Test> _testRepository;
        private readonly IRepository<Theme> _themeRepository;

        public HomeController(IRepository<Answer> answer, IRepository<Question> question,
                              IRepository<Test> test, IRepository<Theme> theme)
        {
            _answerRepository = answer;
            _questionRepository = question;
            _testRepository = test;
            _themeRepository = theme;
        }

        public ActionResult Index()
        {
            return View(_themeRepository.GetAll().ToList());
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
            return View(test);
        }

        public ActionResult StartTest(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StartTest(TestViewModel tvm)
        {
            if (ModelState.IsValid)
            {

            }
            tvm = new TestViewModel(_testRepository.GetById(tvm.Id));
            return View(tvm);
        }
    }
}