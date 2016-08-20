using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdministrationPanel.Views
{
    /// <summary>
    /// Interaction logic for CalendarPickerWindow.xaml
    /// </summary>
    public partial class CalendarPickerWindow : Window
    {
        public DateTime Date
        {
            get;
            private set;
        }

        public CalendarPickerWindow()
        {
            InitializeComponent();
            this.datePicker.DisplayDateStart = DateTime.Today;
        }


        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
