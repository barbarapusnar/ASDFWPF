using System;
using System.Globalization;
using System.Windows.Data;

namespace ASDFWPF
{
    internal class StringToIntConverter : IValueConverter
    {
      

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vnos = (string)value;
            return vnos.Length;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}