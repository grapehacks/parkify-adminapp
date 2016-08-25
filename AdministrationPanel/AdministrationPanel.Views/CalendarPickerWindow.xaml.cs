using System;
using System.Windows;

namespace AdministrationPanel.Views
{
    /// <summary>
    /// Interaction logic for CalendarPickerWindow.xaml
    /// </summary>
    public partial class CalendarPickerWindow : Window
    {
        public CalendarPickerWindow()
        {
            InitializeComponent();
            DatePicker.DisplayDateStart = DateTime.Now;
        }
    }
}
