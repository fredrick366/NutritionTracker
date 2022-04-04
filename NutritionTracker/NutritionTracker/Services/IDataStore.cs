using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionTracker.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddFoodAsync(T food);
        Task<bool> UpdateFoodAsync(T food);
        Task<bool> DeleteFoodAsync(string id);
        Task<T> GetFoodAsync(string id);
        Task<IEnumerable<T>> GetFoodsAsync(bool forceRefresh = false);
    }
}
