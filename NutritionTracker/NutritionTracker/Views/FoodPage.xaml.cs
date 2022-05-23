using NutritionTracker.Models;
using NutritionTracker.ViewModels;
using NutritionTracker.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionTracker.Views
{
    public partial class FoodsPage : ContentPage
    {
        SearchFoodViewModel _viewModel;

        public FoodsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new SearchFoodViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}