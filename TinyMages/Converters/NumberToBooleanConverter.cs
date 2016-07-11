using System;
using System.Globalization;

namespace TinyMages.Converters
{
    public class NumberToBooleanConverter : ConverterBase
    {
        private const double MathTolerance = 1e-10;

        public enum ConversionType
        {
            AreZero,
            Positive,
            Negative,
            PositiveOrNull,
            NegativeOrNull,
        }

        public ConversionType Type { get; set; }
        
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = System.Convert.ToDouble(value);
            switch (Type)
            {
                case ConversionType.AreZero:
                    return Math.Abs(val) < MathTolerance;
                case ConversionType.Positive:
                    return val > 0;
                case ConversionType.Negative:
                    return val < 0;
                case ConversionType.PositiveOrNull:
                    return val >= 0;
                case ConversionType.NegativeOrNull:
                    return val <= 0;
            }
            throw new NotSupportedException("Incorrect conversion type");
        }
    }
}
