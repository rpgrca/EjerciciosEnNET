using Day18.Logic.Numbers;

namespace Day18.Logic.Visitors
{
    public class ReduceBySplittingVisitor : INumberVisitor
    {
        private readonly RegularNumber _numberToSplit;

        public SnailFishNumber SnailFishNumberToSplitParent { get; private set; }

        public ReduceBySplittingVisitor(RegularNumber numberToSplit) =>
            _numberToSplit = numberToSplit;

        public void AddLevel()
        {
        }

        public void RemoveLevel()
        {
        }

        public void Visit(SnailFishNumber snailFishNumber)
        {
            if (snailFishNumber.HasAsSide(_numberToSplit))
            {
                SnailFishNumberToSplitParent = snailFishNumber;
            }
        }

        public void Visit(RegularNumber regularNumber)
        {
        }
    }
}