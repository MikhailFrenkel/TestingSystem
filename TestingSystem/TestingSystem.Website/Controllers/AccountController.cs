﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PagedList;
using TestingSystem.Common.Interfaces;
using TestingSystem.DataProvider.Manager;
using TestingSystem.Model;
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
        public async Task<ActionResult> Login(LoginViewModel lvm)
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
                    if (!String.IsNullOrEmpty(lvm.UrlReferrer))
                        return Redirect(lvm.UrlReferrer);
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
        public async Task<ActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser {UserName = rvm.Login, Email = rvm.Email};
                IdentityResult result = await _userManager.CreateAsync(user, rvm.Password);
                if (result.Succeeded)
                {
                    _userManager.AddToRole(user.Id, "user");
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    if (!String.IsNullOrEmpty(rvm.UrlReferrer))
                        return Redirect(rvm.UrlReferrer);
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

        public ActionResult AllUsers(string searchString, int? page)
        {
            List<UserViewModel> uvm = new List<UserViewModel>();
            foreach (var user in _userManager.Users)
            {
                uvm.Add(new UserViewModel(user, _userManager.GetRoles(user.Id)));
            }

            int pageSize = 8;
            int pageNumber = page ?? 1;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();
                if (!String.IsNullOrEmpty(searchString))
                {
                    uvm = uvm.Where(x => x.UserName.Contains(searchString)).OrderBy(x => x.UserName).ToList();

                    return View(uvm.ToPagedList(pageNumber, pageSize));
                }
            }
            return View(uvm.OrderBy(x => x.UserName).ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Result(string userName)
        {
            if (String.IsNullOrEmpty(userName))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            List<Result> res = _userManager.FindByName(userName).Results.ToList();
            return PartialView(res);
        }
    }
}