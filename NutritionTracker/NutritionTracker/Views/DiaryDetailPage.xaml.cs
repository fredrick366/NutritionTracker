using NutritionTracker.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionTracker.Views
{
    public partial class DiaryDetailPage : ContentPage
    {
        public DiaryDetailPage()
        {
            InitializeComponent();
            BindingContext = new DiaryDetailViewModelTest();
        }
    }
}