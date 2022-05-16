using NutritionTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NutritionTracker.Services;

namespace NutritionTracker.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodItemEntriesPage : ContentPage
    {
        //FoodItemEntriesViewModel _viewModel;

        public SessionStorage session = App.Session;

        public FoodItemEntriesPage()
        {
            InitializeComponent();
            BindingContext = new FoodItemEntriesViewModel();
        }

        protected override void OnDisappearing()
        {
            session.currentDay = null;
        }
    }
}