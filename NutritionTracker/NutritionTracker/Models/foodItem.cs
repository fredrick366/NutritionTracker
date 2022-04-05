using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NutritionTracker.Models
{
    public class foodItem
    {
        public foodItem() { }

        public foodItem(string Name, int Energy)
        {
            name = Name;
            energy = Energy;
        }

        private int _id;            //PK
        private string _name;
        private int _energy;

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

        public int energy
        {
            get { return _energy; }
            set { _energy = value; }
        }
    }
}
