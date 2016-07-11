using System;
using System.Globalization;
using System.Windows;

namespace TinyMages.Converters
{
    public class BooleanToVisibilityConverter : ConverterBase
    {
        public bool Inversed { get; set; }

        public bool Hidden { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = Inversed ? !(bool)value : (bool)value;
            return result
                ? Visibility.Visible
                : Hidden ? Visibility.Hidden : Visibility.Collapsed;
        }
    }
}
