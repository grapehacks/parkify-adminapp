using System.Windows;
using AdministrationPanel.ViewModels;
using AdministrationPanel.ViewModels.HistoryTab;
using AdministrationPanel.ViewModels.HomeTab;
using AdministrationPanel.ViewModels.UsersTab;
using AdministrationPanel.ViewModels.CardsTab;
using Autofac;
using GalaSoft.MvvmLight.Messaging;
using Model;

namespace AdministrationPanel.Views
{
    public class Bootstrapper
    {
        public IContainer Container { get; set; }

        public void Bootstrap()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<ViewModels.UsersTab.ActionsViewModel>();
            containerBuilder.RegisterType<UserViewModel>();
			containerBuilder.RegisterType<CardListViewModel>();
            containerBuilder.RegisterType<HomeTabViewModel>();
            containerBuilder.RegisterType<HistoryTabViewModel>();
            containerBuilder.RegisterType<HistoryItemViewModel>();
            containerBuilder.RegisterType<CalendarPickerWindow>();
            containerBuilder.RegisterType<CalendarWindowViewModel>();
            containerBuilder.RegisterType<MainViewModel>().SingleInstance();
            containerBuilder.RegisterType<MainWindow>().SingleInstance();
			containerBuilder.RegisterType<UserListViewModel>().SingleInstance();
			containerBuilder.RegisterType<CardListViewModel>().SingleInstance();
            containerBuilder.RegisterType<HomeTabViewModel>().SingleInstance();
            containerBuilder.RegisterType<LoginWindow>().SingleInstance();
            containerBuilder.RegisterType<LoginWindowViewModel>().SingleInstance();
            containerBuilder.RegisterType<CalendarPickerWindow>().SingleInstance();
            containerBuilder.RegisterType<CalendarWindowViewModel>().SingleInstance();
            containerBuilder.RegisterType<WindowManager>().SingleInstance();
            containerBuilder.RegisterType<DataProvider>().As<IDataProvider>().SingleInstance();
            containerBuilder.RegisterType<ParkifyModel>().As<IParkifyModel>().SingleInstance();
            containerBuilder.RegisterType<Messenger>().As<IMessenger>().SingleInstance();

            Container = containerBuilder.Build();
        }

        public WindowManager GetWindowManager()
        {
            return Container.Resolve<WindowManager>();
        }
    }
}