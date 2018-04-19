using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DrinkService : IDrinkService
    {
        DrinkController DrinkCtr;
        AlchoholController aCtr;
        HelflaskController hCtr;

        public DrinkService()
        {
            DrinkCtr = new DrinkController();
            aCtr = new AlchoholController();
            hCtr = new HelflaskController();
        }
        public void CreateDrink(Drink drink)
        {
            DrinkCtr.CreateDrink(drink);
        }

        public Drink GetDrink(int id)
        {
            return DrinkCtr.GetDrink(id);
        }
        public IEnumerable<Drink> getAllDrinks()
        {
            return DrinkCtr.getAllDrinks();
        }


        public void UpdateDrink(Drink drink)
        {
            DrinkCtr.UpdateDrink(drink);
        }

        public void DeleteDrinkById(int DrinkId)
        {
            DrinkCtr.DeleteDrinkById(DrinkId);
        }

        public void AddIngredientToDrink(int ingredientID, Drink drink)
        {
            DrinkCtr.AddIngredientToDrink(ingredientID, drink);
        }

        public void DeleteIngredientFromDrink(int ingredientID, Drink drink)
        {
            DrinkCtr.DeleteIngredientFromDrink(ingredientID, drink);
        }
        public IEnumerable<Drink> SearchDrinks(string search)
        {
            return DrinkCtr.searchDrinks(search);
        }

        public void CreateAlchohol(Alchohol alchohol)
        {
            aCtr.CreateAlchohol(alchohol);
        }

        public Alchohol GetAlchohol(int id)
        {
            return aCtr.GetAlchohol(id);
        }
        public HelFlask GetHelflask(int id)
        {
            return hCtr.GetHelflask(id);
        }

        public IEnumerable<Alchohol> GetAllAlchohols()
        {
            return aCtr.GetAllAlchohol();
        }

        public IEnumerable<HelFlask> searchHelflask(string search)
        {
            return hCtr.searchHelflask(search);
        }

        public IEnumerable<Alchohol> searchAlchohol(string search)
        {
            return aCtr.searchAlchohol(search);
        }
    }
}
