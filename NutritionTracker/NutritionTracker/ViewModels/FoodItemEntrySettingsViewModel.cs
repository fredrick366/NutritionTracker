using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Views;
using NutritionTracker.Services;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    class FoodItemEntrySettingsViewModel : BaseViewModel
    {
        public FoodItemEntrySettingsViewModel()
        {
            _day = session.currentDay;
            _foodItem = session.currentFoodItem;
            _weight = 100;
            name = _foodItem.name;
            mealTypes = dbm.getAllMealTypesAsync();

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private day _day;                   //Day this foodItemEntry is associated with
        private foodItem _foodItem;         //FoodItem being entered
        private int _weight;                //Weight of foodItem consumed
        private List<mealType> _mealTypes;  //List of possible mealTypes
        private string _selectedMealType; //Mealtype this foodItem is consumed over
        private string _name;               //FoodItem Name

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

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

        public string selectedMealType    //Selected radio button
        {
            get { return _selectedMealType; }
            set { _selectedMealType = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void updateSession()
        {
            session.previousPage = this.GetType().ToString();
            session.currentFoodItem = null;
        }

        private bool ValidateSave()
        {
            return weight > 0
                && selectedMealType != null;
        }

        private async void OnSave()
        {
            foodItemEntry foodItemEntry = new foodItemEntry(_day.id, _foodItem.id, int.Parse(selectedMealType), weight);

            dbm.saveFoodItemEntryAsync(foodItemEntry);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync(nameof(FoodItemEntriesPage));
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        public int createFoodItemEntry()    //Creates foodItemEntry based on user inputs
        {
            foodItemEntry foodItemEntry = new foodItemEntry(_day.id, _foodItem.id, int.Parse(selectedMealType), weight);
            return dbm.saveFoodItemEntryAsync(foodItemEntry);
        }
    }
}
