using AdministrationPanel.ViewModels.HistoryTab;
using AdministrationPanel.ViewModels.HomeTab;
using AdministrationPanel.ViewModels.UsersTab;
using AdministrationPanel.ViewModels.CardsTab;

namespace AdministrationPanel.ViewModels
{
    public class MainViewModel : AdministrationPanelViewModelBase
    {
        private readonly UserListViewModel _userListViewModel;
        private readonly HomeTabViewModel _homeTabViewModel;
        private readonly HistoryTabViewModel _historyTabViewModel;
		private readonly CardListViewModel _cardListViewModel;

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

		public CardListViewModel CardListViewModel
		{
			get { return _cardListViewModel; }
		}

        public MainViewModel(
            UserListViewModel userListViewModel, 
            HomeTabViewModel homeTabViewModel,
            HistoryTabViewModel historyTabViewModel,
			CardListViewModel cardListViewModel)
        {
            _userListViewModel = userListViewModel;
            _homeTabViewModel = homeTabViewModel;
            _historyTabViewModel = historyTabViewModel;
			_cardListViewModel = cardListViewModel;
        }
    }
}