using Data;
using Data.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private DrinkDataAccess drinkDataAccess;

        public DrinkRepository(string connection)
        {
            drinkDataAccess = new DrinkDataAccess(connection);
        }
        public async Task<List<Drink>> GetAllDrinks()
        {
            return await drinkDataAccess.GetAllAsync(); 
        }

        public async Task<Drink> GetDrinkById(int id)
        {
            return await drinkDataAccess.GetAsync(id);
        }

        public async Task<List<Drink>> GetDrinksByName(string name)
        {
            return await drinkDataAccess.SearchAsync(name);
        }
    }
}
