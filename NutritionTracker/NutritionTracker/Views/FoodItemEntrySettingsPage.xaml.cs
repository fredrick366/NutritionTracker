using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodItemEntrySettingsPage : ContentPage
    {
        FoodItemEntrySettingsViewModel _viewModel;

        public FoodItemEntrySettingsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new FoodItemEntrySettingsViewModel();
        }
    }
}