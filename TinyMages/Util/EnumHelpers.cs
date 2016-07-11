using System;
using System.Collections.Generic;
using System.Linq;
using TinyMages.Effects;
using Type = TinyMages.Effects.Type;

namespace TinyMages.Util
{
    public class EnumData<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }

        public EnumData()
        {
        }

        public EnumData(string name, T value)
        {
            Name = name;
            Value = value;
        }
    }

    public static class EnumLists
    {
        private static List<EnumData<Type>> _type;
        public static List<EnumData<Type>> Type => _type ?? (_type = GetEnumList<Type>());

        private static List<EnumData<DurationType>> _durationType;
        public static List<EnumData<DurationType>> DurationType => _durationType ?? (_durationType = GetEnumList<DurationType>());

        private static List<EnumData<Nature>> _natureType;
        public static List<EnumData<Nature>> Nature => _natureType ?? (_natureType = GetEnumList<Nature>());

        private static List<EnumData<T>> GetEnumList<T>()
        {
            var names = Enum.GetNames(typeof(T));
            var values = (T[])Enum.GetValues(typeof(T));
            return names.Select((t, i) => new EnumData<T>(t, values[i])).ToList();
        }
    }
}
