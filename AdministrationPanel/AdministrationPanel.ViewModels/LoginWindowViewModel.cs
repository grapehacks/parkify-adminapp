using System.Windows;
using AdministrationPanel.ViewModels.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels
{
    public class LoginWindowViewModel : AdministrationPanelViewModelBase
    {
        private readonly IDataProvider _dataProvider;
        private readonly RelayCommand _loginCommand;
        private readonly IMessenger _messenger;

        private string _email;
        private string _error;
        private string _password;

        public LoginWindowViewModel(IDataProvider dataProvider, IMessenger messenger)
        {
            _dataProvider = dataProvider;
            _messenger = messenger;
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
                email = Email,
                password = Password
            };

            var result = await _dataProvider.Authenticate(credential);

            if (result == null)
            {
                _messenger.Send(new LoggedInMessage());
            }
            else
            {
                Email = string.Empty;
                Password = string.Empty;
                Error = result.errorMessage;
            }
        }
    }
}