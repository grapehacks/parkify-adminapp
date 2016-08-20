using AdministrationPanel.ViewModels.HistoryTab;
using AdministrationPanel.ViewModels.HomeTab;
using AdministrationPanel.ViewModels.UsersTab;
using AdministrationPanel.ViewModels.CardsTab;
using AdministrationPanel.ViewModels.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace AdministrationPanel.ViewModels
{
    public class MainViewModel : AdministrationPanelViewModelBase
    {
        private readonly UserListViewModel _userListViewModel;
        private readonly HomeTabViewModel _homeTabViewModel;
        private readonly HistoryTabViewModel _historyTabViewModel;
		private readonly CardListViewModel _cardListViewModel;
        private readonly IMessenger _messenger;

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
			CardListViewModel cardListViewModel,
            IMessenger messenger)
        {
            _userListViewModel = userListViewModel;
            _homeTabViewModel = homeTabViewModel;
            _historyTabViewModel = historyTabViewModel;
			_cardListViewModel = cardListViewModel;
            _messenger = messenger;
        }

        #region ChangeDrawDate command
        private RelayCommand _changeDrawDate;

        public RelayCommand ChangeDrawDateCommand
        {
            get
            {
                return _changeDrawDate ?? (_changeDrawDate = new RelayCommand(ChangeDrawDate));
            }
        }

        private void ChangeDrawDate()
        {
            _messenger.Send(new LoggedOutMessage());

        }
        #endregion
    }
}