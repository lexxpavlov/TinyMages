using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMages.Effects
{
    public class ContinuousDefense : BaseContinuousEffect, IDefenseEffect
    {
        public ContinuousDefense(Nature nature, string name, double mana, double strength, int duration)
            : base(Type.Defense, nature, name, mana, strength, duration)
        {
        }
    }
}
