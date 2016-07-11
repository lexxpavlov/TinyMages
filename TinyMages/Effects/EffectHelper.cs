using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TinyMages.Util;

namespace TinyMages.Effects
{
    public static class EffectHelper
    {
        #region Публичные методы

        public static IEffect Create(string effectName, Nature nature, string name, double mana, double strength, int duration = 1)
        {
            var ctor = GetBestConstructor(GetType(effectName));
            var parameters = GetParameters(ctor, effectName, nature, name, mana, strength, duration);
            return (IEffect)ctor.Invoke(parameters);
        }

        public static System.Type GetType(string effect)
        {
            return System.Type.GetType(typeof(IEffect).Namespace + "." + effect);
        }

        #endregion

        #region Приватные методы

        private static ConstructorInfo GetBestConstructor(System.Type type)
        {
            var ctors = type.GetConstructors();
            return ctors.FirstOrDefault(c => c.GetParameters().Length == 3)
                    ?? ctors.FirstOrDefault(c => c.GetParameters().Length == 2)
                    ?? ctors[0];
        }

        private static object[] GetParameters(ConstructorInfo ctor, string effect, Nature nature, string name, double mana, double strength, int duration)
        {
            switch (ctor.GetParameters().Length)
            {
                default: return new object[] { nature, name, mana };
                case 4: return new object[] { nature, name, mana, strength };
                case 5: return new object[] { nature, name, mana, strength, duration };
            }
        }

        #endregion
    }
}
