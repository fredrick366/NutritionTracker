using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Data;
using NutritionTracker.Models;

namespace NutritionTracker.ViewModels
{
    public class SearchFoodViewModel
    {
        public SearchFoodViewModel() { }

        private databaseManager dbm = App.Database;

        private string _searchString;

        public string searchString          //UI field
        {
            get { return _searchString; }
            set { _searchString = value; }
        }

        public List<foodItem> getSearchResults()                        //This could either be triggered by a keystroke in the search bar or by clicking a search button
        {
            return dbm.getFoodItemByNameAsync(searchString);
        }
    }
}