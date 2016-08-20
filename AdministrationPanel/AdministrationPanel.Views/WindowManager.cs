using AdministrationPanel.ViewModels;
using AdministrationPanel.ViewModels.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace AdministrationPanel.Views
{
    public class WindowManager : AdministrationPanelViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly MainWindow _mainWindow;
        private readonly LoginWindowViewModel _loginWindowViewModel;
        private readonly LoginWindow _loginWindow;
        private readonly CalendarPickerWindow _calendarPickerWindow;
        private readonly CalendarWindowViewModel _calendarViewModel;
        private readonly UserAddEditWindow _userAddEditWindow;
        private readonly IMessenger _messenger;

        public WindowManager(
            MainViewModel mainViewModel, 
            MainWindow mainWindow, 
            LoginWindowViewModel loginWindowViewModel, 
            LoginWindow loginWindow, 
            CalendarWindowViewModel calendarViewModel,
            CalendarPickerWindow calendarWindow,
            UserAddEditWindow userAddEditWindow,
            IMessenger messenger)
        {
            _mainViewModel = mainViewModel;
            _mainWindow = mainWindow;
            _loginWindowViewModel = loginWindowViewModel;
            _loginWindow = loginWindow;
            _messenger = messenger;

            _calendarViewModel = calendarViewModel;
            _calendarPickerWindow = calendarWindow;
            _calendarPickerWindow.DataContext = _calendarViewModel;

            _userAddEditWindow = userAddEditWindow;
            _mainWindow.DataContext = mainViewModel;
            _loginWindow.DataContext = loginWindowViewModel;

            _messenger.Register<LoggedInMessage>(this, OnLoggedInMessage);
            _messenger.Register<LoggedOutMessage>(this, OnLoggedOutMessage);

            _messenger.Register<ShowCalendarPickerMessage>(this, ShowCalendar);
            _messenger.Register<CloseCalendarPickerMessage>(this, HideCalendar);

            _messenger.Register<ShowUserAddEditMessage>(this, ShowAddEditUser);
        }

        private void OnLoggedOutMessage(LoggedOutMessage obj)
        {
            ShowLoginWindow();
        }

        private void OnLoggedInMessage(LoggedInMessage obj)
        {
            ShowMainWindow();
        }

        public void ShowLoginWindow()
        {
            _mainWindow.Hide();
            _loginWindow.Show();
        }

        public void ShowMainWindow()
        {
            _loginWindow.Hide();
            _mainWindow.Show();
            _mainViewModel.UserListViewModel.Load();
			_mainViewModel.CardListViewModel.Load();
            _mainViewModel.HistoryTabViewModel.Load();
        }

        public void ShowCalendar(ShowCalendarPickerMessage msg)
        {
            _calendarPickerWindow.ShowDialog();
        }

        public void HideCalendar(CloseCalendarPickerMessage msg)
        {
            _calendarPickerWindow.Hide();
        }

        public void ShowAddEditUser(ShowUserAddEditMessage msg)
        {
            _userAddEditWindow.Show();
        }
    }
}