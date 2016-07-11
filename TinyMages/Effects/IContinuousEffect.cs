
namespace TinyMages.Effects
{
    public interface IContinuousEffect : IEffect
    {
        int Duration { get; }
        bool IsFinished { get; }
    }
}
