using NutritionTracker.Models;
using NutritionTracker.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    public class DiarysViewModelTest : BaseViewModelTest
    {
        private Diary _selectedDiary;

        public ObservableCollection<Diary> Diarys { get; }
        public Command LoadDiarysCommand { get; }
        public Command AddDiaryCommand { get; }
        public Command<Diary> DiaryTapped { get; }

        public DiarysViewModelTest()
        {
            Title = "Browse Diary Entries";
            Diarys = new ObservableCollection<Diary>();
            LoadDiarysCommand = new Command(async () => await ExecuteLoadDiarysCommand());

            DiaryTapped = new Command<Diary>(OnDiarySelected);

            AddDiaryCommand = new Command(OnAddDiary);
        }

        async Task ExecuteLoadDiarysCommand()
        {
            IsBusy = true;

            try
            {
                Diarys.Clear();
                var diarys = await DataStore.GetDiarysAsync(true);
                foreach (var diary in diarys)
                {
                    Diarys.Add(diary);
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
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedDiary = null;
        }

        public Diary SelectedDiary
        {
            get => _selectedDiary;
            set
            {
                SetProperty(ref _selectedDiary, value);
                OnDiarySelected(value);
            }
        }

        private async void OnAddDiary(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewDiaryPage));
        }

        async void OnDiarySelected(Diary diary)
        {
            if (diary == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(DiaryDetailPage)}?{nameof(DiaryDetailViewModelTest.DiaryId)}={diary.Id}");
        }
    }
}