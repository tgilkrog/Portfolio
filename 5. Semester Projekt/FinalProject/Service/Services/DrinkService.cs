using Data.Models;
using Domain.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DrinkService : IDrinkService
    {
        private IDrinkRepository drinkRepository;

        public DrinkService(IDrinkRepository drinkRepository)
        {
            this.drinkRepository = drinkRepository;
        }

        public async Task<List<Drink>> GetAllDrinks()
        {
            return await drinkRepository.GetAllDrinks();
        }

        public async Task<Drink> GetDrinkById(int id)
        {
            return await drinkRepository.GetDrinkById(id);
        }

        public async Task<List<Drink>> GetDrinksByName(string name)
        {
            return await drinkRepository.GetDrinksByName(name);
        }
    }
}
