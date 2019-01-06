using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ASDFWPF
{
    internal class StringToIntConverter :IValueConverter
    {
      //dejansko je to ToDouble

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vnos = value.ToString();
            FormattedText ft = new FormattedText(vnos,
                                            CultureInfo.CurrentCulture,
                                            FlowDirection.LeftToRight,
                                            new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                                            36,
                                            Brushes.Black);
            //if (vnos[vnos.Length - 1] == ' ')
            //    ft.Width = ft.Width + ft.WidthIncludingTrailingWhitespace;
            return ft.WidthIncludingTrailingWhitespace;
        }

       

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }

      
    }
}