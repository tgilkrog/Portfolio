using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gui.UserServiceRef;
using Gui.WalletServiceRef;
using Gui.AuthServiceRef;
using Gui.ServiceSecurityRef;
using Gui.OrderServiceRef;
using System.Net;
using System.Dynamic;
using Gui.Helpers;

namespace Gui.Controllers
{
    public class UserController : Controller
    {
        UserServiceClient UserClient = new UserServiceClient();
        WalletServiceClient WalletClient = new WalletServiceClient();
        OrderServiceClient OrderClient = new OrderServiceClient();

        // GET: User
        public ActionResult Index(string userName)
        {
            userName = AuthHelper.CurrentUser.Username;
            int id = UserClient.GetUserByUserName(userName).ID;
            UserClient.createWalletAndFavorites(id);
            return View(doBCVM(id));
        }

        public dynamic doBCVM(int userID)
        {
            dynamic BCVM = new ExpandoObject();
            BCVM.Order = OrderClient.GetOrdersByUserId(userID);
            BCVM.User = UserClient.GetUser(userID);
            return BCVM;
        }

        public ActionResult WalletDetails(int id)
        {
            if(WalletClient.GetWallet(id) == null)
            {
                Wallet w = new Wallet
                {
                    User = WalletClient.GetUserById(id),
                    Balance = 0,
                    MinBalance = 0,
                    MaxBalance = 0,
                    LockTime = DateTime.Now
                };
                WalletClient.CreateWallet(w);
            }
            return View(WalletClient.GetWallet(id));
        }
        [HttpPost]
        public ActionResult EditBalance(int id, string text)
        {
            decimal balance = WalletClient.GetWallet(id).Balance;
            balance = balance + decimal.Parse(text);
            WalletClient.UpdateBalanceByUserId(balance, id);
            return RedirectToAction("WalletDetails", new {id});
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(string userName, string uPassword)
        {
            bool check = UserClient.Login(userName, uPassword);
            int id = 0;

            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;
            AuthServiceClient authClient = new AuthServiceClient();
            var isLoggedIn = authClient.Login(userName, uPassword);
            if (isLoggedIn)
            {
                id = UserClient.GetUserByUserName(userName).ID;

                SecurityServiceClient client = new SecurityServiceClient("WSHttpBinding_ISecurityService");
                client.ClientCredentials.UserName.UserName = userName;
                client.ClientCredentials.UserName.Password = uPassword;
                var data = client.GetData(1337);
            }

            return RedirectToAction("Index", new { id = id });
        }
    }
}
