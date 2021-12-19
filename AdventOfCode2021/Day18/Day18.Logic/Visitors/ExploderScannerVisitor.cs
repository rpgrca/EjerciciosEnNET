using Day18.Logic.Numbers;

namespace Day18.Logic.Visitors
{
    public class ExploderScannerVisitor : INumberVisitor
    {
        private int _level;
        private SnailFishNumber _currentNumber;
        private SnailFishNumber _parentNumber;

        public SnailFishNumber DeepestSnailNumberParent { get; private set; }
        public SnailFishNumber DeepestSnailNumber { get; private set; }
        public int DeepestLevel { get; private set; }

        public ExploderScannerVisitor() => _level = 0;

        public void Visit(SnailFishNumber snailFishNumber)
        {
            _parentNumber = _currentNumber;
            _currentNumber = snailFishNumber;

            if (_level > DeepestLevel)
            {
                DeepestLevel = _level;
                DeepestSnailNumberParent = _parentNumber;
                DeepestSnailNumber = _currentNumber;
            }
        }

        public void Visit(RegularNumber regularNumber)
        {
        }

        public bool MustExplode() => DeepestLevel > 4;

        public void AddLevel() => _level++;

        public void RemoveLevel() => _level--;
    }
}