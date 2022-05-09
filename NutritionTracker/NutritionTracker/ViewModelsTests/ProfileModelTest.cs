using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Models;
using NutritionTracker.Views;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    public class ProfileModelTest : BaseViewModelTest
    {
        private string text;
        private string description;
        private string dob;
        private string weight;
        private string height;
        private string medical;
        private string dailygoal;
        private string username;
        private string password;
        //dob, weight, height, medical, daily goal, username, password

        public Command AddProfileCommand { get; }
        public ProfileModelTest()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            AddProfileCommand = new Command(OnAddProfile);
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description)
                && !String.IsNullOrWhiteSpace(dob)
                && !String.IsNullOrWhiteSpace(weight)
                && !String.IsNullOrWhiteSpace(height)
                && !String.IsNullOrWhiteSpace(medical)
                && !String.IsNullOrWhiteSpace(dailygoal)
                && !String.IsNullOrWhiteSpace(username)
                && !String.IsNullOrWhiteSpace(password);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            //This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            //edit profile for person

            //Food newFood = new Food()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    FoodName = FoodNames,
            //    Weight = Weights
            //};

            //await DataStore.AddFoodAsync(newFood);

            //This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnAddProfile(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ProfilePage));
        }
    }
}
