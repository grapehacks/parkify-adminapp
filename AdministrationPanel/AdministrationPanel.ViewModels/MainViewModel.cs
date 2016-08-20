using AdministrationPanel.ViewModels.HistoryTab;
using AdministrationPanel.ViewModels.HomeTab;
using AdministrationPanel.ViewModels.UsersTab;

namespace AdministrationPanel.ViewModels
{
    public class MainViewModel : AdministrationPanelViewModelBase
    {
        private readonly UserListViewModel _userListViewModel;
        private readonly HomeTabViewModel _homeTabViewModel;
        private readonly HistoryTabViewModel _historyTabViewModel;

        public UserListViewModel UserListViewModel
        {
            get { return _userListViewModel; }
        }

        public HomeTabViewModel HomeTabViewModel
        {
            get { return _homeTabViewModel; }
        }

        public HistoryTabViewModel HistoryTabViewModel
        {
            get { return _historyTabViewModel; }
        }

        public MainViewModel(
            UserListViewModel userListViewModel, 
            HomeTabViewModel homeTabViewModel,
            HistoryTabViewModel historyTabViewModel)
        {
            _userListViewModel = userListViewModel;
            _homeTabViewModel = homeTabViewModel;
            _historyTabViewModel = historyTabViewModel;
        }
    }
}