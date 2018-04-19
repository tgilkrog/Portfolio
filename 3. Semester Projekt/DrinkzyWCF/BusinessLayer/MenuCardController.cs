using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DBLayer;

namespace BusinessLayer
{
    public class MenuCardController
    {
        private MenuCardDB db = new MenuCardDB();

        public void createMenuCard(int CuID)
        {
            db.CreateMenuCard(CuID);
        }

        public void AddDrink(MenuCard mc, int drinkID)
        {
            db.AddDrink(mc, drinkID);
        }

        public MenuCard GetMenu(int cusId)
        {
            return db.GetMenuCardByCustomerID(cusId);
        }

        public List<Drink> getAllDrinksByMenucard(int menID)
        {
            return db.GetAllDrinksByCustomer(menID);
        }

        public void DeleteDrinkFromMenu(int menuID, int drinkid)
        {
            db.DeleteDrinkFromMenu(menuID, drinkid);
        }

        /*Denne metode bruges til vores search funktion, den tager en string ind som parameter*/
        public List<Drink> getDrinksBySearchOnMenucard(string search, int cusId)
        {
            List<Drink> searchDrinks = new List<Drink>();
            string search2 = search.ToLower().Trim();

            foreach (Drink d in db.GetMenuCardByCustomerID(cusId).Drinks)
            {
                Drink drink = null;

                if (d.Name.ToLower().Contains(search2) || d.Description.ToLower().Contains(search2))
                    drink = d;

                foreach (Ingredient i in d.Ingredients)
                {
                    if (i.Name.ToLower().Contains(search2))
                        drink = d;
                }

                if (drink != null)
                    searchDrinks.Add(d);
            }

            return searchDrinks;
        }

    }
}
