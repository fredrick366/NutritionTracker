using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionTracker.Services
{
    public interface EDataStore<T>
    {
        Task<bool> AddDiaryAsync(T diary);
        Task<bool> UpdateDiaryAsync(T diary);
        Task<bool> DeleteDiaryAsync(string id);
        Task<T> GetDiaryAsync(string id);
        Task<IEnumerable<T>> GetDiarysAsync(bool forceRefresh = false);
    }
}
