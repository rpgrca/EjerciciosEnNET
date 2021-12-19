using Day18.Logic.Numbers;

namespace Day18.Logic.Visitors
{
    public class ReduceByExplosionVisitor : INumberVisitor
    {
        private readonly SnailFishNumber _deepestFishNumber;

        public ReduceByExplosionVisitor(SnailFishNumber deepestFishNumber) =>
            _deepestFishNumber = deepestFishNumber;

        public void AddLevel()
        {
        }

        public void RemoveLevel()
        {
        }

        public void Visit(SnailFishNumber snailFishNumber)
        {
        }

        public void Visit(RegularNumber regularNumber)
        {
            if (regularNumber.IsLeftOf((RegularNumber)_deepestFishNumber.LeftSide))
            {
                regularNumber.Add((RegularNumber)_deepestFishNumber.LeftSide);
            }

            if (regularNumber.IsRightOf((RegularNumber)_deepestFishNumber.RightSide))
            {
                regularNumber.Add((RegularNumber)_deepestFishNumber.RightSide);
            }
        }
    }
}