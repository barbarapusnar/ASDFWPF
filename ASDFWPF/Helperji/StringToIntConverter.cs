using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ASDFWPF
{
    internal class StringToIntConverter : IValueConverter
    {
      

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vnos = (string)value;
            //FormattedText ft = new FormattedText(vnos,
            //                                CultureInfo.CurrentCulture,
            //                                FlowDirection.LeftToRight,
            //                                new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, FontWeights.Light, FontStretches.Normal),
            //                                26.667,
            //                                Brushes.Black);
            //Size s = new Size(ft.Width, ft.Height);


            return vnos.Length;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}