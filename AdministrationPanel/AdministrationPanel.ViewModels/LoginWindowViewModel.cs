using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels
{
    public class LoginWindowViewModel : AdministrationPanelViewModelBase
    {
        private readonly IDataProvider _dataProvider;
        private readonly RelayCommand _loginCommand;

        private string _email;
        private string _error;
        private string _password;

        public LoginWindowViewModel(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _loginCommand = new RelayCommand(Login);
        }

        public RelayCommand LoginCommand
        {
            get { return _loginCommand; }
        }

        public string Error
        {
            get { return _error; }
            set
            {
                if (value == _error) return;
                _error = value;
                OnPropertyChanged(() => Error);
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (value == _email) return;
                _email = value;
                OnPropertyChanged(() => Email);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged(() => Password);
            }
        }

        private async void Login()
        {
            var credential = new Credentials
            {
                Email = Email,
                Password = Password
            };

            var result = await _dataProvider.Authenticate(credential);

            if (result)
            {
                MessageBox.Show("Success");
            }
            else
            {
                Error = "Login failed";
            }
        }
    }
}