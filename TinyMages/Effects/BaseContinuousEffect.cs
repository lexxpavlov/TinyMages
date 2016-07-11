
namespace TinyMages.Effects
{
    public abstract class BaseContinuousEffect : BaseEffect, IContinuousEffect
    {
        private int _duration;

        public int Duration
        {
            get
            {
                return _duration;
            }
            protected set
            {
                _duration = value;
                RaisePropertyChanged(nameof(Duration));
            }
        }

        public bool IsFinished => Duration <= 0;

        protected BaseContinuousEffect(Type type, Nature nature, string name, double mana, double strength, int duration)
            : base(type, nature, DurationType.Continuous, name, mana, strength)
        {
            Duration = duration;
        }

        public override void Dealed()
        {
            Duration--;
            if (IsFinished)
            {
                Apply();
            }
        }
    }
}
