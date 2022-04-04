using NutritionTracker.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    [QueryProperty(nameof(FoodId), nameof(FoodId))]
    public class FoodDetailViewModel : BaseViewModel
    {
        private string foodId;
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

        public string FoodId
        {
            get
            {
                return foodId;
            }
            set
            {
                foodId = value;
                LoadFoodId(value);
            }
        }

        public async void LoadFoodId(string foodId)
        {
            try
            {
                var food = await DataStore.GetFoodAsync(foodId);
                Id = food.Id;
                Text = food.Text;
                Description = food.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
