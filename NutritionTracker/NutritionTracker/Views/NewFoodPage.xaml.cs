using NutritionTracker.Models;
using NutritionTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionTracker.Views
{
    public partial class NewFoodPage : ContentPage
    {
        public Food Food { get; set; }

        public NewFoodPage()
        {
            InitializeComponent();
            BindingContext = new NewFoodViewModelTest();
        }
    }
}