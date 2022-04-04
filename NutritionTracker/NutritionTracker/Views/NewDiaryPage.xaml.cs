using NutritionTracker.Models;
using NutritionTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionTracker.Views
{
    public partial class NewDiaryPage : ContentPage
    {
        public Diary Diary { get; set; }

        public NewDiaryPage()
        {
            InitializeComponent();
            BindingContext = new NewDiaryViewModel();
        }
    }
}