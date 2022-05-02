using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Services;

namespace NutritionTracker.ViewModels
{
    class SummaryViewModel
    {
        public SummaryViewModel()
        {
            int dailyIntake;

            _user = session.currentUser;

            foreach(day d in dbm.getDaysByUserAsync(_user))
            {
                dailyIntake = 0;

                foreach(foodItemEntry fie in dbm.getFoodItemEntrysByDayAsync(d))
                {
                    dailyIntake = dailyIntake + (dbm.getFoodItemByIdAsync(fie.foodItemId).energy * fie.weight / 100);
                }

                summaries.Add(new summary(dailyIntake, d));
            }
        }

        private databaseManager dbm = App.Database;
        private SessionStorage session = App.session;


        private user _user;
        private int _recommendedDailyIntake;
        private List<summary> _summaries;

        public int recommendedDailyIntake
        {
            get { return _recommendedDailyIntake; }
            set { _recommendedDailyIntake = value; }
        }

        public List<summary> summaries
        {
            get { return _summaries; }
            set { _summaries = value; }
        }
    }
}