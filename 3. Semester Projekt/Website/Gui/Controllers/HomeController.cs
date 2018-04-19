using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gui.CustomerServiceRef;
using Gui.ServiceSecurityRef;
using Gui.AuthServiceRef;
using System.Net;

namespace Gui.Controllers
{
    public class HomeController : Controller
    {
        CustomerServiceClient client = new CustomerServiceClient();

        //ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Beskrivelse";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontaktsiden";

            return View();
        }
        public ActionResult FindBar()
        {
            ViewBag.Message = "Find en bar";

            return View(client.GetAllCustomers());
        }

        public ActionResult shoppage()
        {
            ViewBag.Message = "Butikside";

            return View();
        }
        

        public ActionResult Register()
        {
            ViewBag.Message = "Registrer siden";
            return View();
        }
    }
}