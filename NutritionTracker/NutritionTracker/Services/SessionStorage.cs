using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Models;

namespace NutritionTracker.Services
{
    public class SessionStorage
    {
        public SessionStorage()
        {
            currentUser = null;
            currentFoodItem = null;
            currentDay = null;
        }

        private user _currentUser;
        private foodItem _currentFoodItem;
        private day _currentDay;

        public user currentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public foodItem currentFoodItem
        {
            get { return _currentFoodItem; }
            set { _currentFoodItem = value; }
        }

        public day currentDay
        {
            get { return _currentDay; }
            set { _currentDay = value; }
        }
    }
}
