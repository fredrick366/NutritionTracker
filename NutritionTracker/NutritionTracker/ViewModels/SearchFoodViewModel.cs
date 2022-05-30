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
            searchString = "";
            AddFoodCommand = new Command(AddFoodItem);
            SearchFoodItems = new Command(getSearchResults());
        }

        private string _searchString;
        private foodItem _selectedFoodItem;
        private List<foodItem> _foodItemsRaw;
        private ObservableCollection<foodItem> _foodItems;
        private string _name;
        private int _energy;

        public ObservableCollection<foodItem> foodItems
        {
            get { return _foodItems; }
            set { _foodItems = value; }
        }
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
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string energy
        {
            get { return _energy.ToString(); }
            set { _energy = int.Parse(value); }
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
                IsBusy = true;

                _foodItemsRaw = dbm.getFoodItemByNameAsync(searchString);
                foodItems = new ObservableCollection<foodItem>(_foodItemsRaw);

                IsBusy = false;
            };
            IsBusy = true;

            _foodItemsRaw = dbm.getFoodItemByNameAsync(searchString);
            foodItems = new ObservableCollection<foodItem>(_foodItemsRaw);

            IsBusy = false;

            return action;
        }

        public void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            searchString = e.NewTextValue;
            
            getSearchResults();
            SearchFoodItems.Execute(null);

            //_foodItemsRaw = dbm.getFoodItemByNameAsync(searchString);
            //foodItems = new ObservableCollection<foodItem>(_foodItemsRaw);
        }

        public async void AddFoodItem()
        {
            await Shell.Current.GoToAsync(nameof(NewFoodPage));
        }
    }
}