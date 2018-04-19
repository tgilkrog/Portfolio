using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using BusinessLayer;

namespace WCF
{
    class IngredientService : IIngredientService
    {
        private IngredientController ingCtr = new IngredientController();
        public void createIngredient(Ingredient i)
        {
            ingCtr.createIngredient(i);
        }

        public void DeleteIngredient(int IngID)
        {
            ingCtr.DeleteIngredient(IngID);
        }
        

        public IEnumerable<Ingredient> getAllIngredients()
        {
            return ingCtr.getAllIngredients();
        }

        public Ingredient GetIngredient(int id)
        {
            return ingCtr.GetIngredient(id);
        }

        public IEnumerable<Ingredient> SearchIngedient(string search)
        {
            return ingCtr.searchIngredient(search);
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            ingCtr.UpdateIngredient(ingredient);
        }
    }
}
