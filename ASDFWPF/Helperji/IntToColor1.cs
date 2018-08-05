using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ASDFWPF
{
    class IntToColor1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var r = (int)value;
            if (r == 1)
                //return Color.FromArgb(0xc8,0x9e,0x12,0x08);
                return Colors.Red;
            if (r == 2)
                //return Color.FromArgb(0xc8, 0x84, 0x74, 0x09);
                return Colors.Orange;
            if (r == 3)
                return Colors.Orange;
            //return Color.FromArgb(0xc8, 0xa2, 0x8e, 0x0c);
            if (r == 4)
                return Colors.Orange;
            //return Color.FromArgb(0xc8, 0x70, 0xa2, 0x0c);
            // return Color.FromArgb(0xc8, 0x21, 0x66, 0x03);
            return Colors.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
