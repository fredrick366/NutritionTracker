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
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodItemEntriesPage : ContentPage
    {
        FoodItemEntriesViewModel _viewModel;

        public FoodItemEntriesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new FoodItemEntriesViewModel();
        }
    }
}