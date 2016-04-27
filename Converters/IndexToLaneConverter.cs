using System;
using System.Globalization;
using System.Windows.Data;

namespace RaceDirector.Converters
{
    public class IndexToLaneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var lane = (int) value + 1;
            return $"Lane {(lane)}";;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}