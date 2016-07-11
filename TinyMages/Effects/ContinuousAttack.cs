using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMages.Effects
{
    public class ContinuousAttack : BaseContinuousEffect, IAttackEffect
    {
        public ContinuousAttack(Nature nature, string name, double mana, double strength, int duration)
            : base(Type.Attack, nature, name, mana, strength, duration)
        {
        }
    }
}
