using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Data;
using System.Globalization;

namespace WpfSlika2016
{
    [ValueConversion(typeof(string), typeof(string))]
    class SlikaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string slika = (string)value;
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());//exe verzija aplikacije
            DirectoryInfo root = di.Parent.Parent;//vracamo se dva puta u nazad da bi se na root pozicionirali
            string putanja = System.IO.Path.Combine(root.FullName, "Slike", slika);//kreiramo putanju
            return putanja;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
