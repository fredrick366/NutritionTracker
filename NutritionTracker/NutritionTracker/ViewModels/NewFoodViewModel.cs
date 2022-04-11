using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Data;
using NutritionTracker.Models;

namespace NutritionTracker.ViewModels
{
    class NewFoodViewModel
    {
        public NewFoodViewModel() { }

        private databaseManager dbm = new databaseManager(databaseSettings.defaultPath);

        private int _id;
        private string _name;
        private int _energy;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int energy
        {
            get { return _energy; }
            set { _energy = value; }
        }

        public int saveFoodItem()                               //Updates database with either new or existing foodItem record
        {
            foodItem foodItem = new foodItem(name, energy);
            foodItem.id = id;                                   //If id is null then dbm will realise this and will create

            return dbm.saveFoodItemAsync(foodItem);
        }

        public void getFoodItem()                               //Searches for foodItem by id that may have been passed through for editing
        {
            foodItem foodItem = dbm.getFoodItemByIdAsync(_id);
            if(foodItem == null)                                //If no id has been passed through (creating) then this should run
            {
                name = "";
                energy = 0;
            } else                                              //If an id has been passed through (updating) then this should run
            {
                id = foodItem.id;
                name = foodItem.name;
                energy = foodItem.energy;
            }
        }
    }
}
