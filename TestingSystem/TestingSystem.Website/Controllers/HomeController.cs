using System.Linq;
using System.Web.Mvc;
using TestingSystem.Common.Interfaces;
using TestingSystem.DataProvider.Repositories;
using TestingSystem.Model;

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
            return View();
        }

        public ActionResult Test()
        {
            return View(_themeRepository.GetAll());
        }
    }
}