using NutritionTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTracker.Services
{
    public class DiaryDataStore : EDataStore<Diary>
    {
        readonly List<Diary> diarys;

        public DiaryDataStore()
        {
            diarys = new List<Diary>()
            {
                new Diary { Id = Guid.NewGuid().ToString(), Text = "First entry", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Second entry", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Third entry", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Fourth entry", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Fifth entry", Description="This is an diary description." },
                new Diary { Id = Guid.NewGuid().ToString(), Text = "Sixth entry", Description="This is an diary description." }
            };
        }//add functionality to page to search for foods then later the radio buttons for meal times and summary button taking values from entry

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