using System;
using System.Globalization;

namespace TinyMages.Converters
{
    public class IsSelectedItemConverter : ConverterBase
    {
        public bool Inversed { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = (int)value >= 0;
            return Inversed ? !result : result;

        }
    }
}
