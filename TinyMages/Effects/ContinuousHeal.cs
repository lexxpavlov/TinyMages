using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMages.Effects
{
    public class ContinuousHeal : BaseContinuousEffect
    {
        public ContinuousHeal(Nature nature, string name, double mana, double strength, int duration)
            : base(Type.Heal, nature, name, mana, strength, duration)
        {

        }
    }
}
