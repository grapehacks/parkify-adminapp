using System.Collections.ObjectModel;

namespace AdministrationPanel.ViewModels.UsersTab
{
    public class UserListViewModel : AdministrationPanelViewModelBase
    {
        private ObservableCollection<UserViewModel> _userList;

        public UserListViewModel()
        {
            _userList = new ObservableCollection<UserViewModel>()
            {
                new UserViewModel("1", "1-A", "Jan Kowalski"),
                new UserViewModel("2", "1-B", "Jan Kowalski"),
                new UserViewModel("3", "1-C", "Jan Kowalski"),
                new UserViewModel("4", "1-D", "Jan Kowalski"),
                new UserViewModel("5", "1-E", "Jan Kowalski"),
            };
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
    }
}