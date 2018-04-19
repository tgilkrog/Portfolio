using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using ModelLayer;

namespace BusinessLayer
{
    public class FavoritesController
    {
        private FavoritesDB db = new FavoritesDB();

        public void createFavorites(int userID)
        {
            db.CreateFavorites(userID);
        }

        public Favorites GetFavoritesByUserID(int id)
        {
            return db.GetFavoritesByUserID(id);
        }

        public List<SuperAlchohol> GetAllDrinksByUser(int id)
        {
            return db.GetAllDrinksByUser(id);
        }

        public void addDrink(int userId, int drinkId)
        {
            db.AddDrink(userId, drinkId);
        }

        public void AddAlchohol(int userId, int drinkId)
        {
            db.AddAlchohol(userId, drinkId);
        }

        public void AddHelflask(int userId, int drinkId)
        {
            db.AddHelflask(userId, drinkId);
        }
    }
}
