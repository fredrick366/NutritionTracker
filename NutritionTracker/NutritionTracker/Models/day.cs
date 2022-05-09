using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NutritionTracker.Models
{
    public class day
    {
        public day() { }
        public day(int UserId, DateTime Date)
        {
            userId = UserId;
            date = Date;
        }

        private int _id;            //PK
        private int _userId;
        private DateTime _date;

        [PrimaryKey, AutoIncrement]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int userId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string text                  //Date that is displayed, ie the title of the day in the day list
        {
            get { return _date.ToString("D"); }
        }
    }
}
