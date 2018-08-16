using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TestingSystem.Common.Interfaces;
using TestingSystem.DataProvider.Manager;
using TestingSystem.Model;
using TestingSystem.Model.Identity;
using TestingSystem.Model.ViewModel;

namespace TestingSystem.Website.Controllers
{
    [Authorize(Roles = "user")]
    public class ManageController : Controller
    {
        private readonly ApplicationUserManager _userManager;

        public ManageController(ApplicationUserManager manager)
        {
            _userManager = manager;
        }

        public ActionResult Index()
        {
            ApplicationUser user = _userManager.FindById(User.Identity.GetUserId());
            UserViewModel uvm = new UserViewModel(user, _userManager.GetRoles(user.Id));
            return View(uvm);
        }
    }
}