using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NutritionTracker.Models
{
    public class mealType
    {
        public mealType() { }

        public mealType(string Name)
        {
            name = Name;
        }

        private int _id;        //PK
        private string _name;

        [PrimaryKey, AutoIncrement]
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
    }
}
