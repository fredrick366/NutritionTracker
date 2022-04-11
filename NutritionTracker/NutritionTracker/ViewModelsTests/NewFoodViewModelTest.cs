using NutritionTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    public class NewFoodViewModelTest : BaseViewModelTest
    {
        private string text;
        private string description;

        public NewFoodViewModelTest()
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

        public string FoodNames
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Weights
        {
            get => description;
            set => SetProperty(ref description, value);
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
            Food newFood = new Food()
            {
                Id = Guid.NewGuid().ToString(),
                FoodName = FoodNames,
                Weight = Weights
            };

            await DataStore.AddFoodAsync(newFood);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
