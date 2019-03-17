using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDataAccess<T> where T : class
    {
        Task<T> InsertAsync(T item);
        Task<List<T>> GetAllAsync();
        Task<bool> UpdateAsync(T item);
        Task<T> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<List<T>> GetListWhereAsync(int id);
        Task<List<T>> SearchAsync(string search);
    }
}
