using System.Collections.Generic;
using TinyMages.Effects;

namespace TinyMages.Characters
{
    public interface ICharacter
    {
        string Name { get; }
        ActionType ActionType { get; }

        double Health { get; set; }
        double MaxHealth { get; set; }
        double Strength { get; set; }
        double Defense { get; set; }

        double GetNatureStrength(Nature nature);
        void SetNatureStrength(Nature nature, double value, bool update = false);
        double GetNatureDefense(Nature nature);
        void SetNatureDefense(Nature nature, double value, bool update = false);

        IList<IEffect> PreparedEffects { get; }
        IList<AppliedEffect> AppliedEffects { get; }

        void AddEffect(IEffect effect);
        
    }
}
