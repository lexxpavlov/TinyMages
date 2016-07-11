using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMages.Effects
{
    public class Attack : BaseEffect, IAttackEffect
    {
        public Attack(Nature nature, string name, double mana, double strength)
            : base(Type.Attack, nature, DurationType.Instant, name, mana, strength)
        {
        }
    }
}
