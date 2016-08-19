using System.Windows.Controls;
using AdministrationPanel.ViewModels.HomeTab;

namespace AdministrationPanel.Views.HomeTab
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
