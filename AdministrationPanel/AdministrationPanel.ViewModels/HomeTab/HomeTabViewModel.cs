using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using Model.DataTypes;
using GalaSoft.MvvmLight.Messaging;
using AdministrationPanel.ViewModels.Messages;

namespace AdministrationPanel.ViewModels.HomeTab
{
    public class HomeTabViewModel : AdministrationPanelViewModelBase
    {
        private readonly IMessenger _messenger;

        public HomeTabViewModel(IMessenger messenger)
        {
            _usersCollection = new ObservableCollection<HomeTabUserViewModel>
            {
                new HomeTabUserViewModel {Name = "Yes", UserParticipate = UserParticipate.Yes},
                new HomeTabUserViewModel {Name = "No", UserParticipate = UserParticipate.No},
                new HomeTabUserViewModel {Name = "Unknown", UserParticipate = UserParticipate.NotDefined}
            };

            AvailibleCards = "7";
            UpcomingDraw = "28-10-2016";
            TotalCards = "10";

            _messenger = messenger;
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
            _messenger.Send(new ShowCalendarPickerMessage());

        }
        #endregion
    }
}
