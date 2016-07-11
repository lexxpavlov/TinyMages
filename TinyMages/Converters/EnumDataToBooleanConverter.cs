using System;
using System.Globalization;
using TinyMages.Util;

namespace TinyMages.Converters
{
    public class EnumDataToBooleanConverter : ConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumData = value as EnumData<Type>;
            return enumData == null;
        }
    }
}
