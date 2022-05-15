using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionTracker.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand LoginCommand { protected set; get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            if (username != "tkzhyon" || password != "secret")
            {
                DisplayInvalidLoginPrompt();
            }
        }
    }
}