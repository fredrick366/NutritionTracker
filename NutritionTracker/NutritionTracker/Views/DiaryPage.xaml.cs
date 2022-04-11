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
    public partial class DiarysPage : ContentPage
    {
        DiarysViewModel _viewModels;

        public DiarysPage()
        {
            InitializeComponent();

            BindingContext = _viewModels = new DiarysViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModels.OnAppearing();
        }
    }
}