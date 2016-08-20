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
        private readonly IMessenger _messenger;

        private DateTime _date;

        public CalendarWindowViewModel(IDataProvider dataProvider, IMessenger messenger)
        {
            _dataProvider = dataProvider;
            _setDateCommand = new RelayCommand(SetDate);
            _messenger = messenger;
        }

        public RelayCommand SetDateCommand
        {
            get { return _setDateCommand; }
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
            Ping datePing = new Ping();
            datePing.date = Date;
            var result = await _dataProvider.SetDrawDate(datePing);
            if (result)
                _messenger.Send(new CloseCalendarPickerMessage());
        }
    }
}
