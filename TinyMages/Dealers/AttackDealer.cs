using TinyMages.Characters;
using TinyMages.Effects;

namespace TinyMages.Dealers
{
    public class AttackDealer : BaseDealer
    {
        protected override void DealEffect(int turn, IEffect effect, ICharacter target, ICaster caster)
        {
            double damage = effect.Strength + caster.Strength + caster.GetNatureStrength(effect.Nature) - target.Defense - target.GetNatureDefense(effect.Nature);
            if (damage < 0) damage = 0;
            target.Health -= damage;
        }
    }
}
