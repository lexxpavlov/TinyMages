using System;
using System.Globalization;
using System.Linq;

namespace TinyMages.Converters
{
    public class BooleanMultiConverter : MultiConverterBase
    {
        public enum BooleanType
        {
            AllTrue,
            AllFalse,
            AnyTrue,
            AnyFalse,
        }

        public BooleanType Type { get; set; }

        public override object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (Type)
            {
                case BooleanType.AllTrue:
                    return value.All(v => (bool)v);
                case BooleanType.AllFalse:
                    return value.All(v => !(bool)v);
                case BooleanType.AnyTrue:
                    return value.All(v => (bool)v);
                case BooleanType.AnyFalse:
                    return value.All(v => !(bool)v);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
