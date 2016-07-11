using System;
using System.Globalization;
using System.Windows;

namespace TinyMages.Converters
{
    public class RemainsConverter : MultiConverterBase
    {
        public override object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Length != 2)
            {
                throw new ArgumentException("Incorrect values count");
            }
            int removeTurn = (int) value[0];
            int turn = (int) value[1];
            return removeTurn - turn;
        }
    }
}
