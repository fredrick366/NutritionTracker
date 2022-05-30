using NutritionTracker.ViewModels;
using NutritionTracker.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NutritionTracker
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FoodDetailPage), typeof(FoodDetailPage));
            Routing.RegisterRoute(nameof(NewFoodPage), typeof(NewFoodPage));
            Routing.RegisterRoute(nameof(DiaryDetailPage), typeof(DiaryDetailPage));
            Routing.RegisterRoute(nameof(NewDiaryPage), typeof(NewDiaryPage));
            Routing.RegisterRoute(nameof(FoodItemEntriesPage), typeof(FoodItemEntriesPage));
            Routing.RegisterRoute(nameof(FoodsPage), typeof(FoodsPage));
            Routing.RegisterRoute(nameof(FoodItemEntrySettingsPage), typeof(FoodItemEntrySettingsPage));
        }

    }
}
