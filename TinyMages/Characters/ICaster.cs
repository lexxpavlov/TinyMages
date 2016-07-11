using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMages.Effects;

namespace TinyMages.Characters
{
    public interface ICaster : ICharacter
    {
        double Mana { get; set; }
        double MaxMana { get; set; }

        IList<IEffect> SpellBook { get; }
    }
}
