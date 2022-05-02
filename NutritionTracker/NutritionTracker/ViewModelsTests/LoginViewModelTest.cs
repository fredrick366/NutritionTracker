using NutritionTracker.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    public class LoginViewModelTest : BaseViewModelTest
    {
        public Command LoginCommand { get; }

        public LoginViewModelTest()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        
        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            //have this link to a profile page? or have th option once logged in?
        }
    }
}
