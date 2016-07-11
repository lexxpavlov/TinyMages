using TinyMages.Characters;
using TinyMages.Effects;

namespace TinyMages.Dealers
{
    public class DefenseDealer : BaseDealer
    {
        protected override void DealEffect(int turn, IEffect effect, ICharacter target, ICaster caster)
        {
            caster.AppliedEffects.Add(new AppliedEffect(effect, turn));
        }
    }
}
