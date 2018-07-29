using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ASDFWPF
{
    internal class IntToColor : IValueConverter
    {
        

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var r = (int)value;
            if (r > 10)
                return Colors.Red;
            if (r >= 4)
                return Colors.Orange;
            return Colors.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}