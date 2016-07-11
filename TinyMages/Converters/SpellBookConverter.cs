using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using TinyMages.Characters;
using TinyMages.Effects;
using TinyMages.Util;
using SystemType = System.Type;

namespace TinyMages.Converters
{
    public class SpellBookConverter : MultiConverterBase
    {
        public override object Convert(object[] value, SystemType targetType, object parameter, CultureInfo culture)
        {
            if (value.Length != 4 || value[0] == null) return null;

            var mage = (ICaster)value[0];
            var spellbook = mage.SpellBook;
            var mana = mage.Mana;

            var type = value[1] is ComboBoxItem ? null : ((EnumData<Type>)value[1])?.Value;
            var durationType = ((EnumData<DurationType>)value[2])?.Value;
            var nature = ((EnumData<Nature>)value[3])?.Value;
            return spellbook.Where(e => e.Mana <= mana
                                    && (value[1] == null || e.Type == type)
                                    && (value[2] == null || e.DurationType == durationType)
                                    && (value[3] == null || e.Nature == nature)
                                  ).ToList();
        }
    }
}
