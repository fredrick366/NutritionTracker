using NutritionTracker.Models;
using NutritionTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionTracker.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Food Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewFoodViewModel();
        }
    }
}