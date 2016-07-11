using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace TinyMages.Converters
{
    public abstract class MultiConverterBase : MarkupExtension, IMultiValueConverter
    {
        #region IMultiValueConverter

        public abstract object Convert(object[] value, Type targetType, object parameter, CultureInfo culture);

        public virtual object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Cannot convert back");
        }

        #endregion

        #region MarkupExtension members

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #endregion
    }
}
