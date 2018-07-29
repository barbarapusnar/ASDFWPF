using System;
using System.Globalization;
using System.Windows.Data;


namespace ASDFWPF

{
    /// <summary>
    /// Value converter that translates true to false and vice versa.
    /// </summary>
    public class BooleanNegationConverter : IValueConverter
    {
       

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is bool && (bool)value);
        }

        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is bool && (bool)value);
        }
    }
}
