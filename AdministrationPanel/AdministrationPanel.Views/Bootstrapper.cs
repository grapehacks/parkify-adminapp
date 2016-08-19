using System.Windows;
using AdministrationPanel.ViewModels;
using Autofac;

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

            Container = containerBuilder.Build();
        }

        public Window GetMainWindow()
        {
            var viewModel = Container.Resolve<MainViewModel>();
            var window = Container.Resolve<MainWindow>();

            window.DataContext = viewModel;
            return window;
        }
    }
}