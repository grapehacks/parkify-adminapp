using AdministrationPanel.ViewModels.UsersTab;

namespace AdministrationPanel.ViewModels
{
    public class MainViewModel : AdministrationPanelViewModelBase
    {
        private readonly UserListViewModel _userListViewModel;

        public UserListViewModel UserListViewModel
        {
            get { return _userListViewModel; }
        }

        public MainViewModel(UserListViewModel userListViewModel)
        {
            _userListViewModel = userListViewModel;
        }
    }
}