using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    public class AboutViewModelTest : BaseViewModelTest
    {
        public AboutViewModelTest()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}