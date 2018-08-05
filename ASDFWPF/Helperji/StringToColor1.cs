using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ASDFWPF
{
    public class StringToColor1 : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vnos = (string)value;

            var c = new Color();
            switch (vnos)
            {
                case "Sklop1":
                    c = Color.FromArgb(255, 197, 245, 197);
                    break;
                case "Sklop2":
                    c = Color.FromArgb(255, 123, 142, 191);
                    break;
                case "Sklop3":
                    c = Color.FromArgb(0xff, 0xb2, 0x1c, 0x59);
                    break;
                case "Sklop4":
                    c = Color.FromArgb(0xff, 0xf5, 0xc5, 0xc5);
                    break;
                case "Sklop5":
                    c = Color.FromArgb(0xff, 0x10, 0x43, 0x34);
                    break;
                case "Sklop6":
                    c = Color.FromArgb(0xff, 0x97, 0x9b, 0xa4);
                    break;
                case "Sklop7":
                    c = Color.FromArgb(0xff, 0x26, 0x0b, 0x10);
                    break;
                case "Sklop8":
                    c = Color.FromArgb(0xff, 0x18, 0x00, 0x02);
                    break;
                case "Sklop9":
                    c = Color.FromArgb(0xff, 0xcb, 0x8d, 0xee);
                    break;
                case "Sklop10":
                    c = Color.FromArgb(0xff, 0xb4, 0x5f, 0x38);
                    break;
                case "Sklop11":
                    c = Color.FromArgb(0xff, 0x32, 0x54, 0x60);
                    break;
                case "Sklop12":
                    c = Color.FromArgb(0xff, 0x4c, 0x68, 0x6b);
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