using Gui.DrinkServiceRef;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gui.Controllers
{
    public class SearchController : Controller
    {
        private DrinkController dCtr = new DrinkController();
        private CustomerController cCtr = new CustomerController();
        private IngredientController iCtr = new IngredientController();

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string text)
        {
            return View(doBCVM(text));
        }

        public dynamic doBCVM(string search)
        {
            dynamic BCVM = new ExpandoObject();
            BCVM.Drinks = dCtr.search(search);
            BCVM.Customers = cCtr.SearchCustomers(search);
            BCVM.Ingredients = iCtr.SearchIngredient(search);
            return BCVM;
        }
    }
}
