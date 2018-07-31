using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TestingSystem.DataProvider.Manager;
using TestingSystem.Model.Identity;
using TestingSystem.Model.ViewModel;

namespace TestingSystem.Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationSignInManager _signInManager;
        private readonly IAuthenticationManager _authManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, 
                                    IAuthenticationManager authManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authManager = authManager;
        }

        public ActionResult Login()
        {
            ViewBag.UrlReferrer = Request.UrlReferrer?.ToString();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string urlReferrer, LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindAsync(lvm.Login, lvm.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
                else
                {
                    ClaimsIdentity claim = await _userManager.CreateIdentityAsync(user, 
                                                DefaultAuthenticationTypes.ApplicationCookie);
                    _authManager.SignOut();
                    _authManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (urlReferrer != null)
                        return Redirect(urlReferrer);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(lvm);
        }

        public ActionResult Register()
        {
            ViewBag.UrlReferrer = Request.UrlReferrer?.ToString();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string urlReferrer, RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser {UserName = rvm.Login, Email = rvm.Email };
                IdentityResult result = await _userManager.CreateAsync(user, rvm.Password);
                if (result.Succeeded)
                {
                    if (urlReferrer != null)
                        return Redirect(urlReferrer);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }

            return View(rvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}