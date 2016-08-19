using System.Windows;

namespace AdministrationPanel.Views
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        { 
            base.OnStartup(e);

            var bootstrapper = new Bootstrapper();
            bootstrapper.Bootstrap();
            var window = bootstrapper.GetMainWindow();
            window.Show();
        }
    }
}