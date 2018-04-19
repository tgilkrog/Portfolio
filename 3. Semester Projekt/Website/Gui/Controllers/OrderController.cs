using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gui.OrderServiceRef;
using Gui.OrderLineServiceRef;
using Gui.WalletServiceRef;
using Gui.UserServiceRef;
using Gui.CustomerServiceRef;
using Gui.StorageServiceRef;
using System.Dynamic;
using Gui.Helpers;

namespace Gui.Controllers
{
    public class OrderController : Controller
    {
        OrderServiceClient client = new OrderServiceClient();
        OrderLineServiceClient olClient = new OrderLineServiceClient();
        WalletServiceClient walletClient = new WalletServiceClient();
        StorageServiceClient storageClient = new StorageServiceClient();

        // GET: Order
        public ActionResult Index()
        {
            return View(client.GetAllOrders());
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View(doBCVM(id));
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
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

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View(olClient.GetOrderLine(id));
        }

        [HttpPost]
        public ActionResult EditAmount(int id, int orderID, string text)
        {
            olClient.EditOrderLinePrice(id, orderID, text);
            return RedirectToAction("Details", new { id = orderID });
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrderLineServiceRef.OrderLine orderline, string text)
        {
            try
            {
                int amount = orderline.Amount + Convert.ToInt32(text);
                orderline = olClient.GetOrderLine(id);
                orderline.TotalPrice = amount * orderline.Drink.Price;
                orderline.Amount = amount;
                olClient.EditOrderLine(orderline);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Order/Delete/5
        public ActionResult DeleteOrder(int ID)
        {
            client.DeleteOrderByID(ID);
            return RedirectToAction("Index", "User", new { userName = AuthHelper.CurrentUser.Username });
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult DeleteOrder(int ID, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(string type, int orderlineID, int id)
        {
            olClient.DeleteOrderLineByID(type, orderlineID, id);
            return View("Details", doBCVM(id));
        }

        [HttpPost]
        public ActionResult Delete(int OrderLineId, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public dynamic doBCVM(int id)
        {
            dynamic BCVM = new ExpandoObject();
            BCVM.Order = client.GetOrder(id);
            BCVM.OrderLines = client.GetOrder(id).OrderLines;
            return BCVM;
        }

        public ActionResult CompleteOrder(int id)
        {
            Order order = client.GetOrder(id);

            if (storageClient.CompleteOrder(order.ID) == true)
            {
                //storageClient.CompleteOrder(order.ID);
                order.Status = "Complete";
                decimal hej = walletClient.getWalletByUsername(AuthHelper.CurrentUser.Username).Balance - order.TotalPrice;
                walletClient.UpdateBalanceByUserId(hej, client.GetUser(AuthHelper.CurrentUser.Username).ID);
                client.CompleteOrder(order);

                return View("OrderSucces");
            }
            else
            {
                client.DeleteOrderByID(order.ID);
                return View("OrderFailed");
            }

            
        }

        public ActionResult CreateOrder(int cusID)
        {
            DateTime date = DateTime.Now;

            Order order = new Order
            {
                TotalPrice = 0,
                Discount = 0,
                Date = date,
                Status = "Incomplete",
                User = client.GetUser(AuthHelper.CurrentUser.Username),
                Customer = client.GetCustomer(cusID)
            };

            client.CreateOrder(order);
            return RedirectToAction("Index");
        }
    }
}