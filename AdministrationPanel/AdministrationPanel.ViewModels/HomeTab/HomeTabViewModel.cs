using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.CommandWpf;
using Model;
using Model.DataTypes;
using GalaSoft.MvvmLight.Messaging;
using AdministrationPanel.ViewModels.Messages;

namespace AdministrationPanel.ViewModels.HomeTab
{
    public class HomeTabViewModel : AdministrationPanelViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly IDataProvider _dataProvider;

        public HomeTabViewModel(IDataProvider dataProvider, IMessenger messenger)
        {
            _dataProvider = dataProvider;
            _messenger = messenger;
            Init();
        }

        private async void Init()
        {
            var usersList = await _dataProvider.GetUsers();
            if (usersList != null)
            {
                _usersCollection = new ObservableCollection<HomeTabUserViewModel>();
                foreach (var user in usersList)
                {
                    _usersCollection.Add(new HomeTabUserViewModel(user));
                }

                var view = CollectionViewSource.GetDefaultView(_usersCollection) as CollectionView;
                view.SortDescriptions.Add(new SortDescription("UserParticipate", ListSortDirection.Ascending));
            }

            var cards = await _dataProvider.GetCards();
            if (cards != null)
            {
                var list = cards.ToList();
                _totalCards = list.Count.ToString();
                _availibleCards = list.Count(x => x.active && !x.removed).ToString();
            }

			var date = await _dataProvider.GetDrawTime();
			if (date != null)
			{
				UpcomingDraw = date.date;
			}

			UpcomingDraw.ToShortDateString();
            //UpcomingDraw = "28-10-2016";
        }

        private ObservableCollection<HomeTabUserViewModel> _usersCollection;
        private System.DateTime _upcomingDraw;
        private string _availibleCards;
        private string _totalCards;

        public ObservableCollection<HomeTabUserViewModel> UsersCollection
        {
            get { return _usersCollection; }
            set
            {
                if (Equals(value, _usersCollection)) return;
                _usersCollection = value;
                OnPropertyChanged(() => UsersCollection);
            }
        }
		public System.DateTime UpcomingDraw
        {
            get { return _upcomingDraw; }
            set
            {
                if (value == _upcomingDraw) return;
                _upcomingDraw = value;
                OnPropertyChanged(() => UpcomingDraw);
            }
        }

        public string AvailibleCards
        {
            get { return _availibleCards; }
            set
            {
                if (value == _availibleCards) return;
                _availibleCards = value;
                OnPropertyChanged(() => AvailibleCards);
            }
        }

        public string TotalCards
        {
            get { return _totalCards; }
            set
            {
                if (value == _totalCards) return;
                _totalCards = value;
                OnPropertyChanged(() => TotalCards);
            }
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
            _messenger.Send(new ShowCalendarPickerMessage());

        }
        #endregion
    }
}
