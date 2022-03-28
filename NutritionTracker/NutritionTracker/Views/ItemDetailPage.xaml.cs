using NutritionTracker.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionTracker.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}