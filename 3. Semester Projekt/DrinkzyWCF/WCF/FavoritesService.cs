using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using BusinessLayer;

namespace WCF
{
    class FavoritesService : IFavoritesService
    {
        FavoritesController fCtr = new FavoritesController();

        public void addDrink(int userId, int drinkId)
        {
            fCtr.addDrink(userId, drinkId);
        }

        public void AddAlchohol(int userId, int drinkId)
        {
            fCtr.AddAlchohol(userId, drinkId);
        }

        public void AddHelflask(int userId, int drinkId)
        {
            fCtr.AddHelflask(userId, drinkId);
        }


        public void createFavorites(int userid)
        {
            fCtr.createFavorites(userid);
        }

        public List<SuperAlchohol> GetAllDrinksByUser(int id)
        {
            return fCtr.GetAllDrinksByUser(id);
        }

        public Favorites GetFavoritesByUserID(int id)
        {
            return fCtr.GetFavoritesByUserID(id);
        }
    }
}
