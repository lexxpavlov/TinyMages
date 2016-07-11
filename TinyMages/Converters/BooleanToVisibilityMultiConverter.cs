using System;
using System.Globalization;
using System.Windows;

namespace TinyMages.Converters
{
    public class BooleanToVisibilityMultiConverter : BooleanMultiConverter
    {
        public bool Hidden { get; set; }

        public override object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = (bool) base.Convert(value, typeof(bool), parameter, culture);
            return result
                ? Visibility.Visible
                : Hidden ? Visibility.Hidden : Visibility.Collapsed;
        }
    }
}
