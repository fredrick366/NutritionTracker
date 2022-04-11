using NutritionTracker.Models;
using NutritionTracker.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    public class FoodsViewModelTest : BaseViewModelTest
    {
        private Food _selectedFood;

        public ObservableCollection<Food> Foods { get; }
        public Command LoadFoodsCommand { get; }
        public Command AddFoodCommand { get; }
        public Command<Food> FoodTapped { get; }

        public FoodsViewModelTest()
        {
            Title = "Add new Food";
            Foods = new ObservableCollection<Food>();
            LoadFoodsCommand = new Command(async () => await ExecuteLoadFoodsCommand());

            FoodTapped = new Command<Food>(OnFoodSelected);

            AddFoodCommand = new Command(OnAddFood);
        }

        async Task ExecuteLoadFoodsCommand()
        {
            IsBusy = true;

            try
            {
                Foods.Clear();
                var foods = await DataStore.GetFoodsAsync(true);
                foreach (var food in foods)
                {
                    Foods.Add(food);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedFood = null;
        }

        public Food SelectedFood
        {
            get => _selectedFood;
            set
            {
                SetProperty(ref _selectedFood, value);
                OnFoodSelected(value);
            }
        }

        private async void OnAddFood(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewFoodPage));
        }

        async void OnFoodSelected(Food food)
        {
            if (food == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(FoodDetailPage)}?{nameof(FoodDetailViewModelTest.FoodId)}={food.Id}");
        }
    }
}