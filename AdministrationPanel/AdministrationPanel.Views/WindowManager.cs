using AdministrationPanel.ViewModels;

namespace AdministrationPanel.Views
{
    public class WindowManager
    {
        private readonly MainViewModel _mainViewModel;
        private readonly MainWindow _mainWindow;
        private readonly LoginWindowViewModel _loginWindowViewModel;
        private readonly LoginWindow _loginWindow;

        public WindowManager(
            MainViewModel mainViewModel, 
            MainWindow mainWindow, 
            LoginWindowViewModel loginWindowViewModel, 
            LoginWindow loginWindow)
        {
            _mainViewModel = mainViewModel;
            _mainWindow = mainWindow;
            _loginWindowViewModel = loginWindowViewModel;
            _loginWindow = loginWindow;

            _mainWindow.DataContext = mainViewModel;
            _loginWindow.DataContext = loginWindowViewModel;
        }

        public void ShowLoginWindow()
        {
            _mainWindow.Close();
            _loginWindow.Show();
        }

        public void ShowMainWindow()
        {
            _loginWindow.Close();
            _mainWindow.Show();
        }
    }
}