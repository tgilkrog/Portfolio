using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDrinkRepository
    {
        Task<List<Drink>> GetAllDrinks();
        Task<List<Drink>> GetDrinksByName(string name);
        Task<Drink> GetDrinkById(int id);
    }
}
