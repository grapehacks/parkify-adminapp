using AdministrationPanel.ViewModels.HomeTab;
using AdministrationPanel.ViewModels.UsersTab;

namespace AdministrationPanel.ViewModels
{
    public class MainViewModel : AdministrationPanelViewModelBase
    {
        private readonly UserListViewModel _userListViewModel;
        private readonly HomeTabViewModel _homeTabViewModel;

        public UserListViewModel UserListViewModel
        {
            get { return _userListViewModel; }
        }

        public HomeTabViewModel HomeTabViewModel
        {
            get { return _homeTabViewModel; }
        }

        public MainViewModel(UserListViewModel userListViewModel, HomeTabViewModel homeTabViewModel)
        {
            _userListViewModel = userListViewModel;
            _homeTabViewModel = homeTabViewModel;
        }
    }
}