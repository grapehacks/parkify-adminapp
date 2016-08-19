using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using Model.DataTypes;

namespace AdministrationPanel.Views.HomeTab
{
    [ValueConversion(typeof(UserParticipate), typeof(Color))]
    public class ParticipantColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (UserParticipate)value;
            switch (type)
            {
                case UserParticipate.No:
                    return Color.IndianRed;
                case UserParticipate.NotDefined:
                    return Color.DarkGray;
                case UserParticipate.Yes:
                    return Color.DarkSeaGreen;
            }
            throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
