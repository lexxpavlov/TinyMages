using System.Collections.Generic;

namespace TinyMages.Effects
{
    public static class EnumsExtensions
    {
        private static Dictionary<Type, string> _typeEnumNames;

        public static ActionType GetActionType(this Nature nature)
        {
            switch (nature)
            {
                case Nature.None: return ActionType.None;
                case Nature.Physic: return ActionType.Physic;
                default: return ActionType.Magic;
            }
        }

        public static Dictionary<Type, string> GetNames(this Type type)
        {
            if (_typeEnumNames == null)
            {
                var names = System.Enum.GetNames(typeof(Type));
                var values = (Type[])System.Enum.GetValues(typeof(Type));
                _typeEnumNames = new Dictionary<Type, string>();
                for (int i = 0; i < names.Length; i++)
                {
                    _typeEnumNames.Add(values[i], names[i]);
                }
            }
            return _typeEnumNames;
        }
    }

    public static class EffectExtensions
    {
        public static int GetDuration(this IEffect effect)
        {
            return (effect as IContinuousEffect)?.Duration ?? 1;
        }
    }
}
