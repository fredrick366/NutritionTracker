using NutritionTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTracker.Services
{
    public class MockDataStore : IDataStore<Food, Diary>
    {
        readonly List<Food> foods;
        readonly List<Diary> diarys;

        public MockDataStore()
        {
            foods = new List<Food>()
            {
                new Food { Id = Guid.NewGuid().ToString(), FoodName = "First food", Weight="This is a number for weight per 100g." },
                new Food { Id = Guid.NewGuid().ToString(), FoodName = "Second food", Weight="This is a number for weight per 100g." },
                new Food { Id = Guid.NewGuid().ToString(), FoodName = "Third food", Weight="This is a number for weight per 100g." },
                new Food { Id = Guid.NewGuid().ToString(), FoodName = "Fourth food", Weight="This is a number for weight per 100g." },
                new Food { Id = Guid.NewGuid().ToString(), FoodName = "Fifth food", Weight="This is a number for weight per 100g." },
                new Food { Id = Guid.NewGuid().ToString(), FoodName = "Sixth food", Weight="This is a number for weight per 100g." }
                //have new entries saving to database - or ^ this also saving- so can have show up on refresh
                //have food items from testData appear in the ^^ for the fooddetail
            };

            diarys = new List<Diary>()
            {
                new Diary { Id = Guid.NewGuid().ToString(), Text = "First Day", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Second Day", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Third Day", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Fourth Day", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Fifth Day", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Sixth Day", Description="This is an diary description." }
            };
            //test = date in string format from date picker
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
    //}

    //public class DiaryDataStore : IDataStore<Diary>
    //{
        

        //public DiaryDataStore()
        //{
            
        //}//add functionality to page to search for foods then later the radio buttons for meal times and summary button taking values from entry

        public async Task<bool> AddDiaryAsync(Diary diary)
        {
            diarys.Add(diary);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateDiaryAsync(Diary diary)
        {
            var oldDiary = diarys.Where((Diary arg) => arg.Id == diary.Id).FirstOrDefault();
            diarys.Remove(oldDiary);
            diarys.Add(diary);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteDiaryAsync(string id)
        {
            var oldDiary = diarys.Where((Diary arg) => arg.Id == id).FirstOrDefault();
            diarys.Remove(oldDiary);

            return await Task.FromResult(true);
        }

        public async Task<Diary> GetDiaryAsync(string id)
        {
            return await Task.FromResult(diarys.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Diary>> GetDiarysAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(diarys);
        }
    }
}