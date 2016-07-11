using System;
using System.Globalization;
using System.Windows;

namespace TinyMages.Converters
{
    public class NumberToVisibilityConverter : NumberToBooleanConverter
    {
        public bool Hidden { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = (bool) base.Convert(value, typeof(bool), parameter, culture);
            return result
                ? Visibility.Visible
                : Hidden ? Visibility.Hidden : Visibility.Collapsed;
        }
    }
}
