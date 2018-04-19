using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDrinkService
    {
        [OperationContract]
        void CreateDrink(Drink drink);

        [OperationContract]
        Drink GetDrink(int id);

        [OperationContract]
        IEnumerable<Drink> getAllDrinks();

        [OperationContract]

        void UpdateDrink(Drink drink);

        [OperationContract]
        void DeleteDrinkById(int DrinkId);

        [OperationContract]
        void AddIngredientToDrink(int ingredientID, Drink drink);

        [OperationContract]
        void DeleteIngredientFromDrink(int ingredientID, Drink drink);

        [OperationContract]
        IEnumerable<Drink> SearchDrinks(string search);

        [OperationContract]
        void CreateAlchohol(Alchohol alchohol);

        [OperationContract]
        Alchohol GetAlchohol(int id);

        [OperationContract]
        IEnumerable<Alchohol> GetAllAlchohols();

        [OperationContract]
        HelFlask GetHelflask(int id);

        [OperationContract]
        IEnumerable<HelFlask> searchHelflask(string search);

        [OperationContract]
        IEnumerable<Alchohol> searchAlchohol(string search);
    }
}
