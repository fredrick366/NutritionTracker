using NutritionTracker.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    [QueryProperty(nameof(FoodId), nameof(FoodId))]
    public class FoodDetailViewModelTest : BaseViewModelTest
    {
        private string foodId;
        private string text;
        private string description;
        public string Id { get; set; }

        public string FoodName
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Weight
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
                FoodName = food.FoodName;
                Weight = food.Weight;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
