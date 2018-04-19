using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace WCF
{
    [ServiceContract]
    interface IMenuCardService
    {
        [OperationContract]
        void createMenuCard(int CuID);

        [OperationContract]
        void addDrink(MenuCard mc, int drinkID);
        [OperationContract]
        MenuCard GetMenuByCustomerID(int cusId);
        [OperationContract]
        List<Drink> getAllDrinksByMenucard(int menID);

        [OperationContract]
        void DeleteDrinkFromMenu(int menuID, int drinkid);

        [OperationContract]
        List<Drink> getDrinksBySearchOnMenucard(string search, int cusId);
    }
}
