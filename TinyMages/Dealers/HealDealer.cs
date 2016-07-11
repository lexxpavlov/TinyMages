using TinyMages.Characters;
using TinyMages.Effects;

namespace TinyMages.Dealers
{
    public class HealDealer : BaseDealer
    {
        protected override void DealEffect(int turn, IEffect effect, ICharacter target, ICaster caster)
        {
            var health = caster.Health + effect.Strength;
            caster.Health = health < caster.MaxHealth ? health : caster.MaxHealth;
        }
    }
}
