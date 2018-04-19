using Gui.Helpers;
using Gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gui.Controllers
{
    public class AuthController : Controller
    {
        // GET: AuthController
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;
            ServiceHelper.GetServiceClientWithCredentials(lvm.Username, lvm.Password);
            bool canLogIn = false;
            using (var authsvc = ServiceHelper.GetAuthServiceClient())
            {
                canLogIn = authsvc.Login(lvm.Username, lvm.Password);
            }

            if (!canLogIn)
            {
                ViewBag.StatusMessage = "Could not login with the given credentials";
                return View();
            }
            else
            {
                AuthHelper.Login(lvm);
                return RedirectToAction("Index", "User", new { userName = lvm.Username });
            }
        }

        public ActionResult Logout()
        {
            AuthHelper.Logout();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult MembersOnly()
        {
            return View();
        }
    }
}