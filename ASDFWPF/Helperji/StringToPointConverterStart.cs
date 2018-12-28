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
    class StringToPointConverterStart
    : IMultiValueConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var vnos = values[0].ToString();
            var dolžina = values[1].ToString();
            FormattedText ft = new FormattedText(vnos,
                                            CultureInfo.CurrentCulture,
                                            FlowDirection.LeftToRight,
                                            new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                                            36,
                                            Brushes.Black);
            FormattedText ft1 = new FormattedText(dolžina,
                                            CultureInfo.CurrentCulture,
                                            FlowDirection.LeftToRight,
                                            new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                                            36,
                                            Brushes.Black);
            Point p = new Point(ft.Width / ft1.Width, 0);
            return p;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
