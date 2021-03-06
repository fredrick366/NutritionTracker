using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Services;
using Xamarin.Forms;
using NutritionTracker.Views;

namespace NutritionTracker.ViewModels
{
    public class FoodItemEntriesViewModel : BaseViewModel
    {
        public FoodItemEntriesViewModel()
        {
            title = "Diary Entries";

            _day = session.currentDay;
            _user = session.currentUser;

            if (_day == null)
            {
                _date = DateTime.Today;
            }
            else
            {
                _date = _day.date;
            }

            EditFoodItemEntryCommand = new Command<foodItem>(EditFoodItemEntry);
            AddCommand = new Command(AddFoodItem);
            LoadFoodItemsCommand = new Command(LoadFoodItems());
            CancelCommand = new Command(cancelDay);
            SaveCommand = new Command(saveDay());
        }

        public Command CancelCommand { get; }
        public Command SaveCommand { get; }
        public Command LoadFoodItemsCommand { get; }
        public Command AddCommand { get; }
        public Command EditFoodItemEntryCommand { get; }

        private day _day;
        private user _user;
        private DateTime _date;
        private List<foodItem> _foodItemsRaw;
        private ObservableCollection<foodItem> _foodItems;

        public day day
        {
            get { return _day; }
            set { _day = value; }
        }

        public DateTime date                //UI field
        {
            get { return _date; }
            set { _date = value; }
        }

        public List<foodItem> foodItemsRaw  //Displayed as list
        {
            get { return _foodItemsRaw; }
            set { _foodItemsRaw = value; }
        }

        public ObservableCollection<foodItem> foodItems
        {
            get { return _foodItems; }
            set { _foodItems = value; }
        }


        public Action<object> saveDay()             //Saves day to database
        {
            Action<object> action = (object obj) =>
            {
                if (_day == null)
                {
                    day newDay = new day(_user.id, date);
                }
            };

            if(_day == null)
            {
                day newDay = new day(_user.id, date);
            }
            //if (_day == null)
            //{
            //    day newDay = new day(_user.id, date);
            //    return dbm.saveDayAsync(newDay);
            //}
            //else
            //{
            //    return dbm.saveDayAsync(_day);
            //}

            return action;
        }

        public async void cancelDay()               //Clicks back button
        {
            session.currentDay = null;
            await Shell.Current.GoToAsync(nameof(DiarysPage));
        }

        public Action<object> LoadFoodItems()       //Loads foodItems for this day
        {
            Action<object> action = (object obj) =>
            {
                foodItemsRaw = dbm.getFoodItemsByDayAsync(_day);
                foodItems = new ObservableCollection<foodItem>(foodItemsRaw);
            };

            foodItemsRaw = dbm.getFoodItemsByDayAsync(_day);
            foodItems = new ObservableCollection<foodItem>(foodItemsRaw);

            return action;
        }

        public async void AddFoodItem()
        {
            session.previousPage = this.GetType().ToString();
            await Shell.Current.GoToAsync(nameof(FoodsPage));
        }

        public async void EditFoodItemEntry(foodItem foodItem)
        {
            session.currentFoodItem = foodItem;
            session.currentDay = _day;
            session.previousPage = this.GetType().ToString();
            await Shell.Current.GoToAsync(nameof(FoodItemEntrySettingsPage));
        }
    }
}