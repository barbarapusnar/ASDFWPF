using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ASDFWPF
{
    internal class BoolToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var r = (bool)value;
            if (r)
                return Colors.Red;
            return Color.FromArgb(0xff, 0x71, 0x6F, 0x64);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}