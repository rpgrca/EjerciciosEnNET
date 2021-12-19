using Day18.Logic.Numbers;

namespace Day18.Logic.Visitors
{
    public interface INumberVisitor
    {
        void Visit(SnailFishNumber snailFishNumber);
        void Visit(RegularNumber regularNumber);
        void AddLevel();
        void RemoveLevel();
    }
}