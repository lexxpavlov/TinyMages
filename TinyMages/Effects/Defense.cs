using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMages.Effects
{
    public class Defense : BaseEffect, IDefenseEffect
    {
        public Defense(Nature nature, string name, double mana, double strength)
            : base(Type.Defense, nature, DurationType.Continuous, name, mana, strength)
        {
        }
    }
}
