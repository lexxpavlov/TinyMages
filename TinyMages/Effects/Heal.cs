using TinyMages.Characters;

namespace TinyMages.Effects
{
    public class Heal : BaseEffect
    {
        public Heal(Nature nature, string name, double mana, double strength)
            : base(Type.Heal, nature, DurationType.Instant, name, mana, strength)
        {

        }

        public override bool CanDeal(ICharacter mage)
        {
            return mage.Health < mage.MaxHealth;
        }
    }
}
