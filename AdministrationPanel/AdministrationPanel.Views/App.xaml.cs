using System.Windows;

namespace AdministrationPanel.Views
{
    public partial class App
    {
        private Bootstrapper _bootstrapper;

        protected override void OnStartup(StartupEventArgs e)
        { 
            base.OnStartup(e);

            _bootstrapper = new Bootstrapper();
            _bootstrapper.Bootstrap();
            var manager = _bootstrapper.GetWindowManager();
            manager.ShowLoginWindow();
        }
    }
}