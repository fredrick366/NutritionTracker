using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionTracker.Services
{
    public interface IDataStore<T, D>
    {
        Task<bool> AddFoodAsync(T food);
        Task<bool> UpdateFoodAsync(T food);
        Task<bool> DeleteFoodAsync(string id);
        Task<T> GetFoodAsync(string id);
        Task<IEnumerable<T>> GetFoodsAsync(bool forceRefresh = false);

        Task<bool> AddDiaryAsync(D diary);
        Task<bool> UpdateDiaryAsync(D diary);
        Task<bool> DeleteDiaryAsync(string id);
        Task<D> GetDiaryAsync(string id);
        Task<IEnumerable<D>> GetDiarysAsync(bool forceRefresh = false);
    }
}
