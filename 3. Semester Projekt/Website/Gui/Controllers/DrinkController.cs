using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gui.DrinkServiceRef;
using Gui.OrderLineServiceRef;
using Gui.OrderServiceRef;
using Gui.WalletServiceRef;
using Gui.FavoritServiceRef;
using Gui.UserServiceRef;
using System.Dynamic;
using Gui.StorageServiceRef;

namespace Gui.Controllers
{
    public class DrinkController : Controller
    {
        private UserServiceClient uClient = new UserServiceClient();
        private DrinkServiceClient client = new DrinkServiceClient();
        private OrderLineServiceClient lc = new OrderLineServiceClient();
        private OrderServiceClient orderClient = new OrderServiceClient();
        private OrderController oCtr = new OrderController();
        private WalletServiceClient walletClient = new WalletServiceClient();
        private StorageServiceClient sClient = new StorageServiceClient();
        

        // GET: Drink
        public ActionResult Index()
        {
            return View(client.getAllDrinks());
        }

        public ActionResult AlchoholIndex()
        {
            return View(client.GetAllAlchohols());
        }

        // GET: Drink/Details/5
        public ActionResult Details(int drinkId)
        {

            return View(client.GetDrink(drinkId));
        }

        public ActionResult AlchoholDetails(int drinkId)
        {
            return View(client.GetAlchohol(drinkId));
        }

        public ActionResult HelflaskDetails(int drinkId)
        {
            return View(client.GetHelflask(drinkId));
        }

        // GET: Drink/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drink/Create
        [HttpPost]
        public ActionResult Create(int amount, int drinkId, int cusID, string UserName)
        {
            Gui.OrderLineServiceRef.OrderLine orderline = new Gui.OrderLineServiceRef.OrderLine();
            orderline.Amount = amount;

            if (sClient.getStorageByDrinkAndStorage(drinkId, cusID).Amount >= amount)
            {
                if (orderClient.GetOrderByStatus("Incomplete") != null && orderClient.GetUser(UserName).ID == orderClient.GetOrderByStatus("Incomplete").User.ID)
                {
                    if (orderClient.GetOrderByStatus("Incomplete").Customer.ID == cusID)
                    {
                        orderline.Drink = lc.GetDrink(drinkId);
                        orderline.TotalPrice = orderline.Drink.Price * orderline.Amount;
                        lc.CreateOrderLine(orderline, orderClient.GetOrderByStatus("Incomplete").ID);


                        decimal hej = orderline.Drink.Price * orderline.Amount;
                        hej = orderClient.GetOrderByStatus("Incomplete").TotalPrice + hej;
                        orderClient.UpdatePrice(orderClient.GetOrderByStatus("Incomplete"), hej);
                        return RedirectToAction("Details", "Customer", new { id = cusID });
                    }
                    else if (orderClient.GetOrderByStatus("Incomplete").Customer.ID != cusID)
                    {
                        orderClient.DeleteOrderByID(orderClient.GetOrderByStatus("Incomplete").ID);
                        oCtr.CreateOrder(cusID);
                        return Create(amount, drinkId, cusID, UserName);
                    }
                }
                else
                {
                    oCtr.CreateOrder(cusID);
                    return Create(amount, drinkId, cusID, UserName);
                }
            }
            return RedirectToAction("Details", "Customer", new { id = cusID });
        }
        public ActionResult CreateHelflask()
        {
            return View();
        }

        // POST: Drink/Create
        [HttpPost]
        public ActionResult CreateHelflask(int amount, int drinkId, int cusID, string UserName)
        {
            Gui.OrderLineServiceRef.OrderLine orderline = new Gui.OrderLineServiceRef.OrderLine();
            orderline.Amount = amount;

            if (sClient.getHelflaskStorageByHelflaskAndStorage(drinkId, cusID).Amount >= amount)
            {
                if (orderClient.GetOrderByStatus("Incomplete") != null && orderClient.GetUser(UserName).ID == orderClient.GetOrderByStatus("Incomplete").User.ID)
                {
                    if (orderClient.GetOrderByStatus("Incomplete").Customer.ID == cusID)
                    {
                        orderline.Drink = lc.GetHelflask(drinkId);
                        orderline.TotalPrice = orderline.Drink.Price * orderline.Amount;
                        lc.CreateOrderLineHelflask(orderline, orderClient.GetOrderByStatus("Incomplete").ID);


                        decimal hej = orderline.Drink.Price * orderline.Amount;
                        hej = orderClient.GetOrderByStatus("Incomplete").TotalPrice + hej;
                        orderClient.UpdatePrice(orderClient.GetOrderByStatus("Incomplete"), hej);
                        return RedirectToAction("Details", "Customer", new { id = cusID });
                    }
                    else if (orderClient.GetOrderByStatus("Incomplete").Customer.ID != cusID)
                    {
                        orderClient.DeleteOrderByID(orderClient.GetOrderByStatus("Incomplete").ID);
                        oCtr.CreateOrder(cusID);
                        return CreateHelflask(amount, drinkId, cusID, UserName);
                    }
                }
                else
                {
                    oCtr.CreateOrder(cusID);
                    return CreateHelflask(amount, drinkId, cusID, UserName);
                }

            }

            return RedirectToAction("Details", "Customer", new { id = cusID });
        }

        public ActionResult CreateAlchohol()
        {
            return View();
        }

        // POST: Drink/Create
        [HttpPost]
        public ActionResult CreateAlchohol(int amount, int drinkId, int cusID, string UserName)
        {
            Gui.OrderLineServiceRef.OrderLine orderline = new Gui.OrderLineServiceRef.OrderLine();
            orderline.Amount = amount;

            if (sClient.getAlchoholStorageByDrinkAndStorage(drinkId, cusID).Amount >= amount)
            {
                if (orderClient.GetOrderByStatus("Incomplete") != null && orderClient.GetUser(UserName).ID == orderClient.GetOrderByStatus("Incomplete").User.ID)
                {
                    if (orderClient.GetOrderByStatus("Incomplete").Customer.ID == cusID)
                    {
                        orderline.Drink = lc.GetAlchohol(drinkId);
                        orderline.TotalPrice = orderline.Drink.Price * orderline.Amount;
                        lc.CreateOrderLineAlchohol(orderline, orderClient.GetOrderByStatus("Incomplete").ID);


                        decimal hej = orderline.Drink.Price * orderline.Amount;
                        hej = orderClient.GetOrderByStatus("Incomplete").TotalPrice + hej;
                        orderClient.UpdatePrice(orderClient.GetOrderByStatus("Incomplete"), hej);
                        return RedirectToAction("Details", "Customer", new { id = cusID });
                    }
                    else if (orderClient.GetOrderByStatus("Incomplete").Customer.ID != cusID)
                    {
                        orderClient.DeleteOrderByID(orderClient.GetOrderByStatus("Incomplete").ID);
                        oCtr.CreateOrder(cusID);
                        return CreateAlchohol(amount, drinkId, cusID, UserName);
                    }
                }
                else
                {
                    oCtr.CreateOrder(cusID);
                    return CreateAlchohol(amount, drinkId, cusID, UserName);
                }
            }
            return RedirectToAction("Details", "Customer", new { id = cusID });
        }


        // GET: Drink/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Drink/Edit/5
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

        // GET: Drink/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Drink/Delete/5
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

        public dynamic doBCVM(int id)
        {
            dynamic BCVM = new ExpandoObject();
            BCVM.Drink = client.GetDrink(id);
            BCVM.Ingredients = client.GetDrink(id).Ingredients;
            return BCVM;
        }

        public IEnumerable<Gui.DrinkServiceRef.Drink> search(string text)
        {
            return client.SearchDrinks(text);
        }

        public ActionResult AddFavorit(int drinkID, string userName)
        {
            FavoritesServiceClient fClient = new FavoritesServiceClient();
            int newID = uClient.GetUserByUserName(userName).ID;
            fClient.addDrink(newID, drinkID);
            return RedirectToAction("Details", new { drinkId = drinkID });
        }

        public ActionResult AddAlchohol(int drinkID, string userName)
        {
            FavoritesServiceClient fClient = new FavoritesServiceClient();
            fClient.AddAlchohol(uClient.GetUserByUserName(userName).ID, drinkID);
            return RedirectToAction("AlchoholDetails", new { drinkId = drinkID });
        }

        public ActionResult AddHelflask(int drinkID, string userName)
        {
            FavoritesServiceClient fClient = new FavoritesServiceClient();
            fClient.AddHelflask(uClient.GetUserByUserName(userName).ID, drinkID);
            return RedirectToAction("HelflaskDetails", new { drinkId = drinkID });
        }
    }
}
