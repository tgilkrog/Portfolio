using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IDrinkService
    {
        Task<List<Drink>> GetAllDrinks();
        Task<List<Drink>> GetDrinksByName(string name);
        Task<Drink> GetDrinkById(int id);
    }
}
