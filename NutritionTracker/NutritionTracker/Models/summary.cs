using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionTracker.Models
{
    public class summary
    {
        public summary(int TotalDailyIntake, day Day)
        {
            totalDailyIntake = TotalDailyIntake;
            day = Day;
        }

        private int _totalDailyIntake;
        private day _day;

        public int totalDailyIntake
        {
            get { return _totalDailyIntake; }
            set { _totalDailyIntake = value; }
        }

        public day day
        {
            get { return _day; }
            set { _day = value; }
        }
    }
}