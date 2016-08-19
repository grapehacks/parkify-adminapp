using System.Windows;
using AdministrationPanel.ViewModels;
using AdministrationPanel.Model;

namespace AdministrationPanel.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
