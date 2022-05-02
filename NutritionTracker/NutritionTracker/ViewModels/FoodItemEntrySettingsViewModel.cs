using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Services;

namespace NutritionTracker.ViewModels
{
    class FoodItemEntrySettingsViewModel
    {
        public FoodItemEntrySettingsViewModel()
        {
            _day = session.currentDay;
            _foodItem = session.currentFoodItem;
            mealTypes = dbm.getAllMealTypesAsync();
        }

        private databaseManager dbm = App.Database;
        private SessionStorage session = App.session;

        private day _day;                   //Day this foodItemEntry is associated with
        private foodItem _foodItem;         //FoodItem being entered
        private int _weight;                //Weight of foodItem consumed
        private List<mealType> _mealTypes;  //List of possible mealTypes
        private mealType _selectedMealType; //Mealtype this foodItem is consumed over

        public int weight                   //UI field
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public List<mealType> mealTypes     //Displayed in radio buttons
        {
            get { return _mealTypes; }
            set { _mealTypes = value; }
        }

        public mealType selectedMealType    //Selected radio button
        {
            get { return _selectedMealType; }
            set { _selectedMealType = value; }
        }

        public void updateSession()
        {
            session.currentFoodItem = null;
        }

        public int createFoodItemEntry()    //Creates foodItemEntry based on user inputs
        {
            foodItemEntry foodItemEntry = new foodItemEntry(_day.id, _foodItem.id, selectedMealType.id, weight);
            return dbm.saveFoodItemEntryAsync(foodItemEntry);
        }
    }
}
