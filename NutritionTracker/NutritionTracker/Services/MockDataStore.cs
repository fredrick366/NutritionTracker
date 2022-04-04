using NutritionTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTracker.Services
{
    public class MockDataStore : IDataStore<Food>
    {
        readonly List<Food> foods;

        public MockDataStore()
        {
            foods = new List<Food>()
            {
                new Food { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Food { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Food { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Food { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Food { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Food { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddFoodAsync(Food food)
        {
            foods.Add(food);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateFoodAsync(Food food)
        {
            var oldFood = foods.Where((Food arg) => arg.Id == food.Id).FirstOrDefault();
            foods.Remove(oldFood);
            foods.Add(food);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteFoodAsync(string id)
        {
            var oldFood = foods.Where((Food arg) => arg.Id == id).FirstOrDefault();
            foods.Remove(oldFood);

            return await Task.FromResult(true);
        }

        public async Task<Food> GetFoodAsync(string id)
        {
            return await Task.FromResult(foods.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Food>> GetFoodsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(foods);
        }
    }
}