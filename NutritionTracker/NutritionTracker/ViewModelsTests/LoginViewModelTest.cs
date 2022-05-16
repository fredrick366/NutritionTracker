using NutritionTracker.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using NutritionTracker.Models;

namespace NutritionTracker.ViewModels
{
    public class LoginViewModelTest : BaseViewModelTest
    {
        public Command LoginCommand { get; }

        public LoginViewModelTest()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private string _username;
        private string _password;

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            //have this link to a profile page? or have th option once logged in?
        }
    }
}
