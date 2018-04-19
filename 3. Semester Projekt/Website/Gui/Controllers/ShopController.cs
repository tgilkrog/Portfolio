using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gui.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult shoppage()
        {
            return View();
        }

        public ActionResult Drinks()
        {
            return View();
        }
        public ActionResult Shots()
        {
            return View();
        }
        public ActionResult Snacks()
        {
            return View();
        }
    }
}