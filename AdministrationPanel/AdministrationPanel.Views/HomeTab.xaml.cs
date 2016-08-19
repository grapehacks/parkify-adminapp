using System.Windows.Controls;
using AdministrationPanel.ViewModels;

namespace AdministrationPanel.Views
{
    public partial class HomeTab : UserControl
    {
        public HomeTab()
        {
            InitializeComponent();
            DataContext = new HomeTabViewModel();
        }
    }
}
