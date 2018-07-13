using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingSystem.DataProvider.Repositories;

namespace TestingSystem.Website.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}