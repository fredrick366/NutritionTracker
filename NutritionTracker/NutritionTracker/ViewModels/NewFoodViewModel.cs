using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Services;

namespace NutritionTracker.ViewModels
{
    public class NewFoodViewModel
    {
        public NewFoodViewModel()
        {
            _foodItem = session.currentFoodItem;

            if (_foodItem == null)          //If no foodItem has been passed through (creating) then this should run
            {
                name = "";
                energy = 0;
            }
            else                            //If a foodItem has been passed through (updating) then this should run
            {
                name = _foodItem.name;
                energy = _foodItem.energy;
            }
        }

        private databaseManager dbm = App.Database;
        private SessionStorage session = App.session;

        private foodItem _foodItem;
        private string _name;
        private int _energy;

        public string name                  //UI field
        {
            get { return _name; }
            set { _name = value; }
        }

        public int energy                   //UI field
        {
            get { return _energy; }
            set { _energy = value; }
        }

        public int saveFoodItem()           //Updates database with either new or existing foodItem record
        {
            if(_foodItem == null)
            {
                return dbm.saveFoodItemAsync(new foodItem(name, energy));
            } else
            {
                _foodItem.name = name;
                _foodItem.energy = energy;
                return dbm.saveFoodItemAsync(_foodItem);
            }
        }
    }
}
