using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ASDFWPF.Helperji
{
    class StringToDoubleConverter : IValueConverter
    {
        //dejansko je to ToInt
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vnos = (string)value;
           
            return vnos.Length; //poglej če je dolžina teksta res 40
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
