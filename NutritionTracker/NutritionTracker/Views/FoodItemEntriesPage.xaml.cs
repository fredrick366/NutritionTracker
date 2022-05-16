using NutritionTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionTracker.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodItemEntriesPage : ContentPage
    {
        //FoodItemEntriesViewModel _viewModel;

        public FoodItemEntriesPage()
        {
            InitializeComponent();
            BindingContext = new FoodItemEntriesViewModel();
        }
    }
}