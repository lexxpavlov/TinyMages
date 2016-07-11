using TinyMages.Characters;
using TinyMages.Effects;

namespace TinyMages.Dealers
{
    public interface IDealer
    {
        void Deal(int turn, IEffect effect, ICharacter target, ICaster caster);
    }
}
