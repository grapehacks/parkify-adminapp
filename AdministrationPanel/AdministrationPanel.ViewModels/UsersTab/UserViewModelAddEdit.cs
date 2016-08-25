using System;
using System.Windows;
using AdministrationPanel.ViewModels.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.UsersTab
{
    public class UserViewModelAddEdit : AdministrationPanelViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly IDataProvider _dataProvider;
        private string _email;
        private string _id;
        private bool _isAddMode;
        private bool _isEditMode;
        private string _name;
        private bool? _participate;
        private string _password;
        private bool _rememberLastChoice;
        private bool _removed;
        private string _saveButtonName;
        private bool _type;
        private string _unreadMsgCounter;
        private int _v;

        public UserViewModelAddEdit(User user, IMessenger messenger, IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _messenger = messenger;
            if (user == null)
            {
                //add
                IsAddMode = true;
                SaveButtonName = "Dodaj";
                UnreadMsgCounter = "0";
            }
            else
            {
                //edit
                SaveButtonName = "Edytuj";
                IsAddMode = false;
                Id = user._id;
                Email = user.email;
                Name = user.name;
                Password = user.password;
                Removed = user.removed;
                RememberLastChoice = user.rememberLastChoice;
                Participate = user.participate.ToBool();
                UnreadMsgCounter = user.unreadMsgCounter.ToString();
                Type = (user.type == UserType.Admin);
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

        public string UnreadMsgCounter
        {
            get { return _unreadMsgCounter; }
            set
            {
                if (value == _unreadMsgCounter) return;
                _unreadMsgCounter = value;
                OnPropertyChanged(() => UnreadMsgCounter);
            }
        }

        public string Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged(() => Id);
            }
        }

        public bool IsAddMode
        {
            get { return _isAddMode; }
            set
            {
                if (value == _isAddMode) return;
                _isAddMode = value;
                OnPropertyChanged(() => IsAddMode);
            }
        }

        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                if (value == _isEditMode) return;
                _isEditMode = value;
                OnPropertyChanged(() => IsEditMode);
            }
        }

        public string SaveButtonName
        {
            get { return _saveButtonName; }
            set
            {
                if (value == _saveButtonName) return;
                _saveButtonName = value;
                OnPropertyChanged(() => SaveButtonName);
            }
        }

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

        private UserParticipate BoolToParticipate(bool? participate)
        {
            if (participate == true)
                return UserParticipate.Yes;
            if (participate == false)
                return UserParticipate.No;
            return UserParticipate.NotDefined;
        }

        private User ReadUserDataForm()
        {
            var user = new User();
            user.participate = BoolToParticipate(Participate);
            user.__v = V;
            user._id = Id;
            user.email = Email;
            user.name = Name;
            user.password = Password;
            user.rememberLastChoice = RememberLastChoice;
            user.removed = Removed;
            user.type = Type ? UserType.Admin : UserType.User;
            user.unreadMsgCounter = int.Parse(UnreadMsgCounter);
            return user;
        }

        #region Save command

        private RelayCommand _save;

        public RelayCommand SaveCommand
        {
            get { return _save ?? (_save = new RelayCommand(Save)); }
        }

        private async void Save()
        {
            if (IsAddMode)
            {
                var usr = ReadUserDataForm();
                var res = await _dataProvider.AddUser(usr);
                if (res != null && res == usr._id)
                {
                    _messenger.Send(new CloseUserAddEditMessage());
                }
                else
                {
                    MessageBox.Show("nie udało sie dodac usera");
                }
            }
            else
            {
                var usr = ReadUserDataForm();
                var res = await _dataProvider.EditUser(usr);
                if (res != null && res == usr._id)
                {
                    _messenger.Send(new CloseUserAddEditMessage());
                }
                else
                {
                    MessageBox.Show("nie udało sie edytowac usera");
                }
            }
        }

        #endregion

        #region Cancel command

        private RelayCommand _cancel;

        public RelayCommand CancelCommand
        {
            get { return _cancel ?? (_cancel = new RelayCommand(Cancel)); }
        }

        private void Cancel()
        {
            _messenger.Send(new CloseUserAddEditMessage());
        }

        #endregion
    }
}