using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DBLayer;

namespace BusinessLayer
{
    public class IngredientController
    {
        private IngredientsDB db = new IngredientsDB();

        public void createIngredient(Ingredient i)
        {
            db.CreateIngredient(i);
        }
        public void DeleteIngredient(int IngID)
        {
            db.DeleteIngredient(IngID);
        }

        public Ingredient GetIngredient(int id)
        {
            return db.GetIngredient(id);
        }
        public void UpdateIngredient(Ingredient ingredient)
        {
            db.UpdateIngredient(ingredient);
        }

        public IEnumerable<Ingredient> getAllIngredients()
        {
            return db.GetAllIngredients();
        }

        public IEnumerable<Ingredient> searchIngredient(string search)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string search2 = search.ToLower().Trim();

            foreach (Ingredient i in db.GetAllIngredients())
            {
                if (i.Name.ToLower().Contains(search2))
                {
                    ingredients.Add(i);
                }
            }

            return ingredients;
        }
    }
}
