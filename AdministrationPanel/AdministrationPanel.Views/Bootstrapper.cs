using System.Windows;
using AdministrationPanel.ViewModels;
using AdministrationPanel.ViewModels.HomeTab;
using AdministrationPanel.ViewModels.UsersTab;
using Autofac;
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
            containerBuilder.RegisterType<UserListViewModel>();
            containerBuilder.RegisterType<HomeTabViewModel>();
            containerBuilder.RegisterType<LoginWindow>();
            containerBuilder.RegisterType<LoginWindowViewModel>();
            containerBuilder.RegisterType<WindowManager>();
            containerBuilder.RegisterType<DataProvider>().As<IDataProvider>();
            containerBuilder.RegisterType<ParkifyModel>().As<IParkifyModel>();

            Container = containerBuilder.Build();
        }

        public WindowManager GetWindowManager()
        {
            return Container.Resolve<WindowManager>();
        }
    }
}