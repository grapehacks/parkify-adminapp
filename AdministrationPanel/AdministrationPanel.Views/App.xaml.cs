using System;
using System.Threading.Tasks;
using System.Windows;

namespace AdministrationPanel.Views
{
    public partial class App
    {
        private Bootstrapper _bootstrapper;

        protected override void OnStartup(StartupEventArgs e)
        {
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            base.OnStartup(e);

            _bootstrapper = new Bootstrapper();
            _bootstrapper.Bootstrap();
            var manager = _bootstrapper.GetWindowManager();
            manager.ShowLoginWindow();
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine("-ffuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu");
            e.SetObserved();
        }
    }
}