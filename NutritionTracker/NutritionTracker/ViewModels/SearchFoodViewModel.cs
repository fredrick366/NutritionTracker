using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Services;

namespace NutritionTracker.ViewModels
{
    public class SearchFoodViewModel : BaseViewModel
    {
        public SearchFoodViewModel() { }

        private string _searchString;
        private foodItem _selectedFoodItem;

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

        public void updateSession()
        {
            session.currentFoodItem = selectedFoodItem;
        }

        public List<foodItem> getSearchResults()                        //This could either be triggered by a keystroke in the search bar or by clicking a search button
        {
            return dbm.getFoodItemByNameAsync(searchString);
        }
    }
}