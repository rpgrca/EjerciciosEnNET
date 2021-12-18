using System;
namespace Day18.Logic
{
    public class SnailFishNumberSplitter : IReducer
    {
        private SnailFishNumber _value;
        private readonly SnailFishNumber _snailFishNumberToSplitParent;
        private readonly RegularNumber _snailFishNumberToSplit;
        private readonly bool _canReduce;

        public bool CanReduce() => _canReduce;

        public SnailFishNumberSplitter(SnailFishNumber value)
        {
            _value = value;

            var visitor = new SplitterScannerVisitor();
            value.Accept(visitor);

            _canReduce = visitor.MustSplit();
            _snailFishNumberToSplitParent = visitor.SnailFishNumberToSplitParent;
            _snailFishNumberToSplit = visitor.SnailFishNumberToSplit;
        }

        public SnailFishNumber Apply()
        {
            if (_snailFishNumberToSplitParent.LeftSide == _snailFishNumberToSplit)
            {
                _snailFishNumberToSplitParent.LeftSide = new SnailFishNumber(
                    new RegularNumber((int)Math.Floor(_snailFishNumberToSplit.Value / 2.0)),
                    new RegularNumber((int)Math.Ceiling(_snailFishNumberToSplit.Value / 2.0)));
            }
            else
            {
                _snailFishNumberToSplitParent.RightSide = new SnailFishNumber(
                    new RegularNumber((int)Math.Floor(_snailFishNumberToSplit.Value / 2.0)),
                    new RegularNumber((int)Math.Ceiling(_snailFishNumberToSplit.Value / 2.0)));
            }

            var visitor = new ReorderRegularNumberVisitor();
            _value.Accept(visitor);

            return _value;
        }
    }
}