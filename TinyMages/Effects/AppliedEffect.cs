namespace TinyMages.Effects
{
    public class AppliedEffect
    {
        public IEffect Effect { get; }
        public int AppliedTurn { get; }
        public int RemoveTurn { get; }

        public AppliedEffect(IEffect effect, int appliedTurn, int remainTurns = 0)
        {
            Effect = effect;
            AppliedTurn = appliedTurn;
            RemoveTurn = appliedTurn;
            RemoveTurn += remainTurns > 0 ? remainTurns : effect.GetDuration();
        }
    }
}
