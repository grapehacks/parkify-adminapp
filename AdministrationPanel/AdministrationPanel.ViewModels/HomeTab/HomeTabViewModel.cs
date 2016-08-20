using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.CommandWpf;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.HomeTab
{
    public class HomeTabViewModel : AdministrationPanelViewModelBase
    {
        private readonly IDataProvider _dataProvider;
        public HomeTabViewModel(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
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

            UpcomingDraw = "28-10-2016";
        }

        private ObservableCollection<HomeTabUserViewModel> _usersCollection;
        private string _upcomingDraw;
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
        public string UpcomingDraw
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
            MessageBox.Show("ChangeDrawDate");
        }
        #endregion
    }
}
