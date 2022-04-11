using NutritionTracker.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionTracker.Views
{
    public partial class FoodDetailPage : ContentPage
    {
        public FoodDetailPage()
        {
            InitializeComponent();
            BindingContext = new FoodDetailViewModelTest();
        }
    }
}