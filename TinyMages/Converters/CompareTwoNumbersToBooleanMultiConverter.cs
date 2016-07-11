using System;
using System.Globalization;
using System.Linq;

namespace TinyMages.Converters
{
    public class CompareTwoNumbersToBooleanMultiConverter : MultiConverterBase
    {
        private const double MathTolerance = 1e-10;

        public enum CompareType
        {
            Equals,
            Lesser,
            Greater,
            LesserOrEqual,
            GreaterOrEqual,
        }

        public CompareType Type { get; set; }

        public override object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Length != 2)
            {
                throw new ArgumentException("Only two bindings are allow");
            }
            var a = (double) value[0];
            var b = (double) value[1];
            switch (Type)
            {
                case CompareType.Equals:
                    return Math.Abs(a - b) < MathTolerance;
                case CompareType.Lesser:
                    return a < b;
                case CompareType.Greater:
                    return a > b;
                case CompareType.LesserOrEqual:
                    return a <= b;
                case CompareType.GreaterOrEqual:
                    return a >= b;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
