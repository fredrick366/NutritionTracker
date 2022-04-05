using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NutritionTracker.Models
{
    public class foodItemEntry
    {
        public foodItemEntry() { }

        public foodItemEntry(int DayId, int FoodItemId, int MealTypeId, int Weight)
        {
            dayId = DayId;
            foodItemId = FoodItemId;
            mealTypeId = MealTypeId;
            weight = Weight;
        }

        private int _dayId;         //PF
        private int _foodItemId;    //PF
        private int _mealTypeId;
        private int _weight;

        [PrimaryKey]
        public int dayId
        {
            get { return _dayId; }
            set { _dayId = value; }
        }

        [PrimaryKey]
        public int foodItemId
        {
            get { return _foodItemId; }
            set { _foodItemId = value; }
        }

        public int mealTypeId
        {
            get { return _mealTypeId; }
            set { _mealTypeId = value; }
        }

        public int weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
    }
}
