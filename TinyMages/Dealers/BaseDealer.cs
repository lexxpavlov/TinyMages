using TinyMages.Characters;
using TinyMages.Effects;

namespace TinyMages.Dealers
{
    public abstract class BaseDealer : IDealer
    {
        protected abstract void DealEffect(int turn, IEffect effect, ICharacter target, ICaster caster);

        public virtual void Deal(int turn, IEffect effect, ICharacter target, ICaster caster)
        {
            if (!effect.IsApplied)
            {
                DealEffect(turn, effect, target, caster);
            }
            effect.Dealed();
        }
    }
}
