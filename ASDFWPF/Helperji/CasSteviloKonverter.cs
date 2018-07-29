using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ASDFWPF
{
    class CasSteviloKonverter:IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal) //decimalna števila izpiše na 2 decimalki
                return ((decimal)value).ToString("00.00");
            else
                 if (value is int)
            {
                if (parameter == null)
                {
                    return ((int)value).ToString("d1"); //cela števila na 1 mesto
                }
                else //lahko pa v XAML-u določim kako naj se izpišejo
                {
                    return ((int)value).ToString(parameter.ToString());
                }

            }
            return value;
        }

       

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
