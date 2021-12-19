using Day18.Logic.Numbers;

namespace Day18.Logic.Visitors
{
    public class SplitterScannerVisitor : INumberVisitor
    {
        private RegularNumber _currentNumber;
        public RegularNumber SnailFishNumberToSplit { get; private set; }

        public void Visit(SnailFishNumber snailFishNumber)
        {
        }

        public void Visit(RegularNumber regularNumber)
        {
            _currentNumber = regularNumber;

            if (_currentNumber.Value >= 10 && SnailFishNumberToSplit is null)
            {
                SnailFishNumberToSplit = _currentNumber;
            }
        }

        public void AddLevel()
        {
        }

        public void RemoveLevel()
        {
        }

        public bool MustSplit() => SnailFishNumberToSplit != null;
    }
}