using System;
using Day18.Logic.Numbers;
using Day18.Logic.Reducers;
using Day18.Logic.Visitors;

namespace Day18.Logic
{
    public class SnailFishNumberSplitter : IReducer
    {
        private readonly SnailFishNumber _value;
        private readonly RegularNumber _snailFishNumberToSplit;
        private readonly bool _canReduce;
        private SnailFishNumber _snailFishNumberToSplitParent;

        public SnailFishNumberSplitter(SnailFishNumber value)
        {
            _value = value;

            var visitor = new SplitterScannerVisitor();
            value.Accept(visitor);

            _canReduce = visitor.MustSplit();
            _snailFishNumberToSplit = visitor.SnailFishNumberToSplit;
        }

        public SnailFishNumber Apply()
        {
            var visitor = new ReduceBySplittingVisitor(_snailFishNumberToSplit);
            _value.Accept(visitor);
            _snailFishNumberToSplitParent = visitor.SnailFishNumberToSplitParent;

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

            var orderVisitor = new ReorderRegularNumberVisitor();
            _value.Accept(orderVisitor);

            return _value;
        }

        public bool CanReduce() => _canReduce;
    }
}