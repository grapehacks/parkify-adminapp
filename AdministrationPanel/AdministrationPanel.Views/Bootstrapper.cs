using System.Windows;
using AdministrationPanel.ViewModels;
using AdministrationPanel.ViewModels.HomeTab;
using AdministrationPanel.ViewModels.UsersTab;
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

            containerBuilder.RegisterType<MainViewModel>().SingleInstance();
            containerBuilder.RegisterType<MainWindow>().SingleInstance();
            containerBuilder.RegisterType<UserListViewModel>().SingleInstance();
            containerBuilder.RegisterType<HomeTabViewModel>().SingleInstance();
            containerBuilder.RegisterType<LoginWindow>().SingleInstance();
            containerBuilder.RegisterType<LoginWindowViewModel>().SingleInstance();
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