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
    interface IFavoritesService
    {
        [OperationContract]
        void createFavorites(int userID);

        [OperationContract]
        Favorites GetFavoritesByUserID(int id);

        [OperationContract]
        List<SuperAlchohol> GetAllDrinksByUser(int id);

        [OperationContract]
        void addDrink(int userId, int drinkId);
        [OperationContract]
        void AddAlchohol(int userId, int drinkId);

        [OperationContract]
        void AddHelflask(int userId, int drinkId);
    }
}
