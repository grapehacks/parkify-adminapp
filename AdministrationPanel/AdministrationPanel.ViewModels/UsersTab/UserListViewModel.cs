using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.UsersTab
{
    public class UserListViewModel : AdministrationPanelViewModelBase
    {
        private readonly IDataProvider _dataProvider;
        private ObservableCollection<UserViewModel> _userList;

        public UserListViewModel(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _userList = new ObservableCollection<UserViewModel>();
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
                .Select(user => new UserViewModel(
                    user._id,
                    GetCardForUser(cardList, user._id),
                    user.name));

            UserList = new ObservableCollection<UserViewModel>(userViewModels);
        }

        private static string GetCardForUser(IEnumerable<Card> cards, string userId)
        {
            var cardWithUser = cards.Where(c => c.user != null);
            var card = cardWithUser.FirstOrDefault(c => c.user._id == userId);
            return card == null
                ? string.Empty
                : card.name;
        }
    }
}