using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfSlika2016
{
    [ValueConversion(typeof(bool), typeof(string))]
    class PolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,CultureInfo culture)
        {
            bool pol = (bool)value;
            if (pol == false)
            {
                return "Muski pol";
            }
            if (pol == true)
            {
                return "Ženski pol";
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter,CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
