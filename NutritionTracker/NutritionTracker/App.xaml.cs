using NutritionTracker.Services;
using NutritionTracker.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NutritionTracker.Data;

namespace NutritionTracker
{
    public partial class App : Application
    {
        static databaseManager database;

        public static databaseManager Database
        {
            get
            {
                if (database == null)
                {
                    database = new databaseManager(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nutrition.db3"));
                }
                return database;
            }
        }

        static SessionStorage session;

        public static SessionStorage Session
        {
            get
            {
                if (session == null)
                {
                    session = new SessionStorage();
                }
                return session;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
