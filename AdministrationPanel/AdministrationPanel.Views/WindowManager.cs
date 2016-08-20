﻿using AdministrationPanel.ViewModels;
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
        private readonly IMessenger _messenger;

        public WindowManager(
            MainViewModel mainViewModel, 
            MainWindow mainWindow, 
            LoginWindowViewModel loginWindowViewModel, 
            LoginWindow loginWindow, 
            IMessenger messenger)
        {
            _mainViewModel = mainViewModel;
            _mainWindow = mainWindow;
            _loginWindowViewModel = loginWindowViewModel;
            _loginWindow = loginWindow;
            _messenger = messenger;

            _mainWindow.DataContext = mainViewModel;
            _loginWindow.DataContext = loginWindowViewModel;

            _messenger.Register<LoggedInMessage>(this, OnLoggedInMessage);
            _messenger.Register<LoggedOutMessage>(this, OnLoggedOutMessage);
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
        }
    }
}