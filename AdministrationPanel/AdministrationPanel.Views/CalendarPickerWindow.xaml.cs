using System;
using System.Windows;

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
