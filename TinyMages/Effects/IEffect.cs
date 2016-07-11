using System;
using TinyMages.Characters;

namespace TinyMages.Effects
{
    public interface IEffect
    {
        Type Type { get; }
        Nature Nature { get; }
        DurationType DurationType { get; }

        string Name { get; }
        double Mana { get; }
        double Strength { get; }

        bool IsApplied { get; }

        bool CanDeal(ICharacter mage);
        void Dealed();

        void Apply();
        IEffect Clone();
    }
}
