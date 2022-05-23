using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Views;
using NutritionTracker.Services;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    public class SearchFoodViewModel : BaseViewModel
    {
        public SearchFoodViewModel()
        {
            title = "Search for food item";
            AddFoodCommand = new Command(AddFoodItem);
            SearchFoodItems = new Command(getSearchResults());
        }

        private string _searchString;
        private foodItem _selectedFoodItem;
        private List<foodItem> _foodItemsRaw;

        public ObservableCollection<foodItem> foodItems;
        public Command AddFoodCommand { get; }
        public Command SearchFoodItems { get; }

        public string searchString          //UI field
        {
            get { return _searchString; }
            set { _searchString = value; }
        }

        public foodItem selectedFoodItem    //Selected FoodItem
        {
            get { return _selectedFoodItem; }
            set { _selectedFoodItem = value; }
        }
        public foodItem selectedFood
        {
            get => _selectedFoodItem;
            set
            {
                SetProperty(ref _selectedFoodItem, value);
                OnFoodSelected(value);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            selectedFood = null;
        }
        async void OnFoodSelected(foodItem foodItem)
        {
            if (foodItem == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(FoodDetailPage)}?{nameof(FoodDetailViewModelTest.FoodId)}={foodItem.id}");
        }

        public void updateSession()
        {
            session.currentFoodItem = selectedFoodItem;
        }

        public Action<object> getSearchResults()                        //This could either be triggered by a keystroke in the search bar or by clicking a search button
        {
            Action<object> action = (object obj) =>
            {
                _foodItemsRaw = dbm.getFoodItemByNameAsync(searchString);
                foodItems = new ObservableCollection<foodItem>(_foodItemsRaw);
            };
            _foodItemsRaw = dbm.getFoodItemByNameAsync(searchString);
            foodItems = new ObservableCollection<foodItem>(_foodItemsRaw);

            return action;
        }

        public async void AddFoodItem()
        {
            await Shell.Current.GoToAsync(nameof(NewFoodPage));
        }
    }
}