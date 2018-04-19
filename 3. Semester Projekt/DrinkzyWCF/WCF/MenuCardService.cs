using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using BusinessLayer;

namespace WCF
{
    class MenuCardService : IMenuCardService
    {
        MenuCardController mCtr = new MenuCardController();

        public void addDrink(MenuCard mc, int drinkID)
        {
            mCtr.AddDrink(mc, drinkID);
        }

        public void createMenuCard(int CuID)
        {
            mCtr.createMenuCard(CuID);
        }

        public List<Drink> getAllDrinksByMenucard(int menID)
        {
            return mCtr.getAllDrinksByMenucard(menID);
        }

        public MenuCard GetMenuByCustomerID(int cusId)
        {
            return mCtr.GetMenu(cusId);
        }

        public void DeleteDrinkFromMenu(int menuID, int drinkid)
        {
            mCtr.DeleteDrinkFromMenu(menuID, drinkid);
        }

        public List<Drink> getDrinksBySearchOnMenucard(string search, int cusId)
        {
            return mCtr.getDrinksBySearchOnMenucard(search, cusId);
        }
    }
}
