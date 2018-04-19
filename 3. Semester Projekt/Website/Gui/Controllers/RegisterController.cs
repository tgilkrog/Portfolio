using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gui.UserServiceRef;
using Gui.FavoritServiceRef;
using Gui.Models;
using System.Text.RegularExpressions;

namespace Gui.Controllers
{
    public class RegisterController : Controller
    {
        UserServiceClient client = new UserServiceClient();
        FavoritesServiceClient faClient = new FavoritesServiceClient();

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult AutomaticRedirect()
        {
            return RedirectToAction("Index", "Home");
        }


        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create

        [HttpPost]
        public ActionResult Create(Gui.UserServiceRef.User user)
        {
            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("Password", "Du har ikke indtastet et Password");
            }
            if (string.IsNullOrEmpty(user.LastName))
            {
                ModelState.AddModelError("LastName", "Du har ikke indtastet dit Lastname");
            }
            if (string.IsNullOrEmpty(user.FirstName))
            {
                ModelState.AddModelError("FirstName", "Du har ikke indtastet dit Firstname");
            }
            if (string.IsNullOrEmpty(user.Gender))
            {
                ModelState.AddModelError("Gender", "Du har ikke valgt et køn");
            }
            if (string.IsNullOrEmpty(user.UserName))
            {
                ModelState.AddModelError("UserName", "Du har ikke indtastet et Username");
            }
            if (!string.IsNullOrEmpty(user.Email))
            {
                string emailRegex = @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(user.Email))
                {
                    ModelState.AddModelError("Email", "Indtast venligst korrekt Email");
                }
            }
            else
            {
                ModelState.AddModelError("Email", "Du har ikke indtastet din Email");
            }
            if (!string.IsNullOrEmpty(user.Phone))
            {
                string phoneRegex = "^([0-9]{8})$";
                Regex pe = new Regex(phoneRegex);
                if (!pe.IsMatch(user.Phone))
                {
                    ModelState.AddModelError("Phone", "Indtast venligst korrekt Telefon nr");
                }
            }
            else
            {
                ModelState.AddModelError("Phone", "Du har ikke indtastet Telefon nr");
            }
            if (ModelState.IsValid)
            {

                client.CreateUser(user);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
