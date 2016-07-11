
namespace TinyMages.Effects
{
    public abstract class BasePermanentEffect : BaseEffect, IPermanentEffect
    {

        protected BasePermanentEffect(Type type, Nature nature, string name, double mana, double strength)
            : base(type, nature, DurationType.Permanent, name, mana, strength)
        {
        }

        public override void Dealed()
        {
            IsApplied = true;
        }
    }
}
