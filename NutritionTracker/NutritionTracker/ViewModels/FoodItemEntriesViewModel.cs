using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Services;

namespace NutritionTracker.ViewModels
{
    class FoodItemEntriesViewModel : BaseViewModel
    {
        public FoodItemEntriesViewModel()
        {
            title = "Browse Diary Entries";

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

            foodItems = dbm.getFoodItemsByDayAsync(_day);
        }

        private day _day;
        private user _user;
        private DateTime _date;
        private List<foodItem> _foodItems;

        public DateTime date                //UI field
        {
            get { return _date; }
            set { _date = value; }
        }

        public List<foodItem> foodItems     //Displayed as list
        {
            get { return _foodItems; }
            set { _foodItems = value; }
        }

        public int saveDay()                //Saves day to database
        {
            if(_day == null)
            {
                day newDay = new day(_user.id, date);
                return dbm.saveDayAsync(newDay);
            } else
            {
                return dbm.saveDayAsync(_day);
            }
        }
    }
}