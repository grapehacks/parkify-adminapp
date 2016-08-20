using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AdministrationPanel.ViewModels.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.UsersTab
{
    public class UserListViewModel : AdministrationPanelViewModelBase
    {
        private readonly IDataProvider _dataProvider;
        private readonly UserViewModel.Factory _userViewModelFactory;
        private ObservableCollection<UserViewModel> _userList;
        private readonly IMessenger _messenger;


        public UserListViewModel(IDataProvider dataProvider, UserViewModel.Factory factory, IMessenger messenger)
        {
            _dataProvider = dataProvider;
            _userViewModelFactory = factory;
            _userList = new ObservableCollection<UserViewModel>();
            _messenger = messenger;
        }

        public ObservableCollection<UserViewModel> UserList
        {
            get { return _userList; }
            set
            {
                if (Equals(value, _userList)) return;
                _userList = value;
                OnPropertyChanged(() => UserList);
            }
        }

        public async void Load()
        {
            var users = await _dataProvider.GetUsers();
            var cards = await _dataProvider.GetCards();

            var userList = users == null ? new List<User>() : users.ToList();
            var cardList = cards == null ? new List<Card>() : cards.ToList();

            var userViewModels = userList
                .Select(user => _userViewModelFactory(
                    user,
                    GetCardForUser(cardList, user._id),
                    user.name));

            UserList = new ObservableCollection<UserViewModel>(userViewModels);
        }

        private static string GetCardForUser(IEnumerable<Card> cards, string userId)
        {
			//var card = cards.FirstOrDefault(c => c.user._id == userId);
			//return card == null
			//	? string.Empty
			//	: card.name;
			return "";
        }

        #region AddUser command
        private RelayCommand _addUser;

        public RelayCommand AddUserCommand
        {
            get
            {
                return _addUser ?? (_addUser = new RelayCommand(AddUser));
            }
        }

        private void AddUser()
        {
            _messenger.Send(new ShowUserAddEditMessage());
        }
        #endregion
    }

}