using System.Windows;
using AdministrationPanel.ViewModels.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.UsersTab
{
    public class UserViewModelAddEdit : AdministrationPanelViewModelBase
    {
        private readonly IMessenger _messenger;

        public UserViewModelAddEdit(User user, IMessenger messenger)
        {
            _messenger = messenger;
            if (user == null)
            {
                //add
                IsAddMode = true;
            }
            else
            {
                //edit
                IsAddMode = false;
                Id = user._id;
                Email = user.email;
                Name = user.name;
                Password = user.password;
                Removed = user.removed;
                RememberLastChoice = user.rememberLastChoice;
                Participate = ParticipanteToBool(user.participate);
                Type = user.type == UserType.Admin ? true : false;
            }
        }

        private bool? ParticipanteToBool(UserParticipate participate)
        {
            switch (participate)
            {
                case UserParticipate.No:
                    return false;
                case UserParticipate.Yes:
                    return true;
            }
            return null;
        }

        private string _email;

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

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged(() => Name);
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

        public bool Removed
        {
            get { return _removed; }
            set
            {
                if (value == _removed) return;
                _removed = value;
                OnPropertyChanged(() => Removed);
            }
        }

        public int V
        {
            get { return _v; }
            set
            {
                if (value == _v) return;
                _v = value;
                OnPropertyChanged(() => V);
            }
        }

        public bool RememberLastChoice
        {
            get { return _rememberLastChoice; }
            set
            {
                if (value == _rememberLastChoice) return;
                _rememberLastChoice = value;
                OnPropertyChanged(() => RememberLastChoice);
            }
        }


        private string _name;

        private string _password;

        private bool _removed;

        private int _v;

        private bool _rememberLastChoice;

        private bool? _participate;

        public bool? Participate
        {
            get { return _participate; }
            set
            {
                if (value == _participate) return;
                _participate = value;
                OnPropertyChanged(() => Participate);
            }
        }

        public bool Type
        {
            get { return _type; }
            set
            {
                if (value == _type) return;
                _type = value;
                OnPropertyChanged(() => Type);
            }
        }

        private bool _type;


        public string SaveButtonLabel { get { return IsAddMode ? "Dodaj" : "Edytuj"; } }
        public string UnreadMsgCounter { get; private set; }
        public string Id { get; private set; }

        public bool IsAddMode { get; private set; }
        public bool IsEditMode { get { return !IsAddMode; } }

        #region Save command
        private RelayCommand _save;

        public RelayCommand SaveCommand
        {
            get
            {
                return _save ?? (_save = new RelayCommand(Save));
            }
        }

        private void Save()
        {
            _messenger.Send(new LoggedOutMessage());

        }
        #endregion

        #region Cancel command
        private RelayCommand _cancel;

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancel ?? (_cancel = new RelayCommand(Cancel));
            }
        }

        private void Cancel()
        {
            _messenger.Send(new LoggedOutMessage());

        }
        #endregion
    }
}
