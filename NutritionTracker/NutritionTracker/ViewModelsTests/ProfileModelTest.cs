using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Models;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    public class ProfileModelTest : BaseViewModelTest
    {
        private string text;
        private string description;
        //dob, weight, height, medical, daily goal, username, password
        public ProfileModelTest()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
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

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
