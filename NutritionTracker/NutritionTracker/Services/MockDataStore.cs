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
                new Food { Id = Guid.NewGuid().ToString(), Text = "First food", Description="This is an food description." },
                new Food { Id = Guid.NewGuid().ToString(), Text = "Second food", Description="This is an food description." },
                new Food { Id = Guid.NewGuid().ToString(), Text = "Third food", Description="This is an food description." },
                new Food { Id = Guid.NewGuid().ToString(), Text = "Fourth food", Description="This is an food description." },
                new Food { Id = Guid.NewGuid().ToString(), Text = "Fifth food", Description="This is an food description." },
                new Food { Id = Guid.NewGuid().ToString(), Text = "Sixth food", Description="This is an food description." }
                //have new entries saving to database - or ^ this also saving- so can have show up on refresh
            };

            diarys = new List<Diary>()
            {
                new Diary { Id = Guid.NewGuid().ToString(), Text = "First entry", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Second entry", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Third entry", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Fourth entry", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Fifth entry", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Sixth entry", Description="This is an diary description." }
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