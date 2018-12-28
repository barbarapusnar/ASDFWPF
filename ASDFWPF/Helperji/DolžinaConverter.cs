using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ASDFWPF.Helperji
{
    class DolžinaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vnos = value.ToString();

            //kako dobiti tukaj širino vrtstice v pikslih???
          
            FormattedText ft = new FormattedText(vnos,
                                            CultureInfo.CurrentCulture,
                                            FlowDirection.LeftToRight,
                                            new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                                            36,
                                            Brushes.Black);
            return ft.Width;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
