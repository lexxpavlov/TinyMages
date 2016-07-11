using System.Collections.Generic;
using System.Linq;
using TinyMages.Effects;

namespace TinyMages.Dealers
{
    public static class DealersSelector
    {
        private static readonly Dictionary<Type, IDealer> Dealers = new Dictionary<Type, IDealer>
        {
            [Type.Attack] = new AttackDealer(),
            [Type.Defense] = new DefenseDealer(),
            [Type.Heal] = new HealDealer(),
            [Type.Special] = new SpecialDealer(),
        };

        public static IDealer GetDealer(IEffect effect)
        {
            return Dealers[effect.Type];
        }
    }
}
