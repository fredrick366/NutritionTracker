using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NutritionTracker.Data;

namespace NutritionTracker.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            generateTestData();
            loginTestUser();
        }

        public void generateTestData()
        {
            testData td = new testData();
            databaseManager dbm = App.Database;

            foreach(var d in td.createDays())
            {
                dbm.saveDayAsync(d);
            }
            foreach(var fi in td.createFoodItems())
            {
                dbm.saveFoodItemAsync(fi);
            }
            foreach(var fie in td.createFoodItemEntries())
            {
                dbm.saveFoodItemEntryAsync(fie);
            }
            foreach(var mt in td.createMealTypes())
            {
                dbm.saveMealTypeAsync(mt);
            }
            foreach(var u in td.createUsers())
            {
                dbm.saveUserAsync(u);
            }
        }

        public void loginTestUser()
        {
            App.Session.currentUser = App.Database.getUserByLoginAsync("user1", "password");
        }
    }
}