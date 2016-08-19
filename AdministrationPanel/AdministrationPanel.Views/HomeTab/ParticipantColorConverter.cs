using System;
using System.Globalization;
using System.Windows.Data;
using Model.DataTypes;
using System.Windows.Media;

namespace AdministrationPanel.Views.HomeTab
{
    [ValueConversion(typeof(UserParticipate), typeof(Color))]
    public class ParticipantColorConverter : IValueConverter
    {
        private static readonly SolidColorBrush red;
        private static readonly SolidColorBrush gray;
        private static readonly SolidColorBrush green;

        static ParticipantColorConverter()
        {
            red = new SolidColorBrush(Colors.IndianRed);
            gray = new SolidColorBrush(Colors.DarkGray);
            green= new SolidColorBrush(Colors.DarkSeaGreen);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (UserParticipate)value;
            switch (type)
            {
                case UserParticipate.No:
                    return red;
                case UserParticipate.NotDefined:
                    return gray;
                case UserParticipate.Yes:
                    return green;
            }
            throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
