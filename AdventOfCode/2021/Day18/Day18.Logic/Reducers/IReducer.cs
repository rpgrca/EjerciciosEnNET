using Day18.Logic.Numbers;

namespace Day18.Logic.Reducers
{
    public interface IReducer
    {
        SnailFishNumber Apply();
        bool CanReduce();
    }
}