using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NutritionTracker.Data;
using NutritionTracker.Models;
using NutritionTracker.Services;
using Xamarin.Forms;
using NutritionTracker.Views;

namespace NutritionTracker.ViewModels
{
    class DaysViewModel : BaseViewModel
    {
        public DaysViewModel()
        {
            title = "Browse Diary Entries";

            LoadDiarysCommand = new Command(ExecuteLoadDiarysCommand());

            DiaryTapped = new Command<day>(OnDiarySelected);

            AddDiaryCommand = new Command(OnAddDiary);

        }

        public Command LoadDiarysCommand { get; }
        public Command<day> DiaryTapped { get; }
        public Command AddDiaryCommand { get; }

        private user _user;
        private ObservableCollection<day> _days;
        private day _selectedDay;

        public ObservableCollection<day> days   //Displays as list
        {
            get { return _days; }
            set { _days = value; }
        }

        public day selectedDay              //Selected day
        {
            get { return _selectedDay; }
            set { _selectedDay = value; }
        }

        public void updateSession()         //Updates session variables
        {
            session.currentDay = selectedDay;
        }

        public int deleteDay(day day)       //Deletes selected day
        {
            return dbm.deleteDayAsync(day);
        }


        private Action<object> ExecuteLoadDiarysCommand()
        {
            Action<object> action = (object obj) =>
            {
                IsBusy = true;      //Not running
                try
                {
                    if (session.currentUser != null)
                    {
                        _user = session.currentUser;
                        days = new ObservableCollection<day>(dbm.getDaysByUserAsync(_user));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            };
            return action;
        }

        async void OnDiarySelected(day day)
        {
            if (day == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(DiaryDetailPage)}?{nameof(DiaryDetailViewModelTest.DiaryId)}={day.id}");
        }

        private async void OnAddDiary(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewDiaryPage));
        }
    }
}