using NutritionTracker.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    [QueryProperty(nameof(DiaryId), nameof(DiaryId))]
    public class DiaryDetailViewModel : BaseViewModel
    {
        private string diaryId;
        private string text;
        private string description;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string DiaryId
        {
            get
            {
                return diaryId;
            }
            set
            {
                diaryId = value;
                LoadDiaryId(value);
            }
        }

        public async void LoadDiaryId(string diaryId)
        {
            try
            {
                var diary = await DataStore.GetDiaryAsync(diaryId);
                Id = diary.Id;
                Text = diary.Text;
                Description = diary.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
