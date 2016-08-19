﻿using AdministrationPanel.Model;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;

namespace AdministrationPanel.ViewModels
{
    public class HomeTabViewModel : AdministrationPanelViewModelBase
    {
        public HomeTabViewModel()
        {
            UsersCollection = new ObservableCollection<User>();
            UsersCollection.Add(new User { Name = "Yes", WillParticipate = UserParticipate.Yes });
            UsersCollection.Add(new User { Name = "No", WillParticipate = UserParticipate.No });
            UsersCollection.Add(new User { Name = "Unknown", WillParticipate = UserParticipate.Unknown });

            AvailibleCards = "7";
            UpcomingDraw = "28-10-2016";
            TotalCards = "10";
        }

        public ObservableCollection<User> UsersCollection { get; private set; }

        private string _upcomingDraw;
        private string _availibleCards;
        private string _totalCards;

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

        public RelayCommand ChangeDrawDateCommand => _changeDrawDate ?? (_changeDrawDate = new RelayCommand(ChangeDrawDate));

        private void ChangeDrawDate()
        {
            MessageBox.Show("asd");
        }
        #endregion
    }
}