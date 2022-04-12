using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Services;

namespace NutritionTracker.ViewModels
{
    class DaysViewModel
    {
        public DaysViewModel()
        {
            _user = session.currentUser;
            days = dbm.getDaysByUserAsync(_user);
        }

        private databaseManager dbm = App.Database;
        private SessionStorage session = App.session;

        private user _user;
        private List<day> _days;

        public List<day> days               //Displays as list
        {
            get { return _days; }
            set { _days = value; }
        }

        public int deleteDay(day day)       //Deletes selected day
        {
            return dbm.deleteDayAsync(day);
        }
    }
}