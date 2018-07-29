using System;
using System.Globalization;
using System.Windows.Data;

namespace ASDFWPF
{
    public class StringFormatConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return value;
            }

            return string.Format((string)parameter, value);
        }

        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}