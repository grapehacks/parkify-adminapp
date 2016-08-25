using System.Windows;
using AdministrationPanel.ViewModels.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Model;
using Model.DataTypes;
using System;

namespace AdministrationPanel.ViewModels
{
    public class CalendarWindowViewModel : AdministrationPanelViewModelBase
    {
        private readonly IDataProvider _dataProvider;
        private readonly RelayCommand _setDateCommand;
        private readonly RelayCommand _cancelCommand;
        private readonly IMessenger _messenger;

        private DateTime _date;

        public CalendarWindowViewModel(IDataProvider dataProvider, IMessenger messenger)
        {
            _dataProvider = dataProvider;
            _setDateCommand = new RelayCommand(SetDate);
            _cancelCommand = new RelayCommand(Cancel);
            _messenger = messenger;
        }

        public RelayCommand SetDateCommand
        {
            get { return _setDateCommand; }
        }

        public RelayCommand CancelCommand
        {
            get { return _cancelCommand; }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (value == _date) return;
                _date = value;
                OnPropertyChanged(() => Date);
            }
        }
        
        private async void SetDate()
        {
            var datePing = new Ping();
            datePing.date = Date;
            var result = await _dataProvider.SetDrawDate(datePing);
            if (result)
            {
                _messenger.Send(new CloseCalendarPickerMessage());
            }
            else
            {
                MessageBox.Show("nie udało sie ustawic daty");
            }
        }

        private void Cancel()
        {
            _messenger.Send(new CloseCalendarPickerMessage());
        }
    }
}
