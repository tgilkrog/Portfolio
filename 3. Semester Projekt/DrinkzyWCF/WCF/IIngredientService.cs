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
    interface IIngredientService
    {
        [OperationContract]
        void createIngredient(Ingredient i);
        [OperationContract]
        Ingredient GetIngredient(int id);
        [OperationContract]
        IEnumerable<Ingredient> getAllIngredients();

        [OperationContract]
        IEnumerable<Ingredient> SearchIngedient(string search);

        [OperationContract]
        void DeleteIngredient(int IngID);

        [OperationContract]
        void UpdateIngredient(Ingredient ingredient);
    }
}
