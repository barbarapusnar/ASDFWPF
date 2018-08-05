using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ASDFWPF
{
    public class StringToColorConverter : IValueConverter
    {
        

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vnos = (string)value;
            var c1 = new LinearGradientBrush();
            var c = new Color();
            switch (vnos)
            {
                case "Sklop1":
                    c = Color.FromArgb(255, 7, 52, 7);
                    break;
                case "Sklop2":
                    c = Color.FromArgb(255, 8, 53, 70);
                    break;
                case "Sklop3":
                    c = Color.FromArgb(0xff, 0xcc, 0x18, 0x45);
                    break;
                case "Sklop4":
                    c = Color.FromArgb(0xff, 0xa8, 0x46, 0x0d);
                    break;
                case "Sklop5":
                    c = Color.FromArgb(0xff, 0x01, 0x7d, 0x63);
                    break;
                case "Sklop6":
                    c = Color.FromArgb(0xff, 0x09, 0x24, 0x80);
                    break;
                case "Sklop7":
                    c = Color.FromArgb(0xff, 0x43, 0x1a, 0x47);
                    break;
                case "Sklop8":
                    c = Color.FromArgb(0xff, 0xca, 0x6d, 0x0e);
                    break;
                case "Sklop9":
                    c = Color.FromArgb(0xff, 0x5a, 0x08, 0x5c);
                    break;
                case "Sklop10":
                    c = Color.FromArgb(0xff, 0x5c, 0x19, 0x11);
                    break;
                case "Sklop11":
                    c = Color.FromArgb(0xff, 0x1c, 0x30, 0x17);
                    break;
                case "Sklop12":
                    c = Color.FromArgb(0xff, 0x13, 0x16, 0x1f);
                    break;
            }
            return c;
        }

        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}