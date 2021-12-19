using System;
using Day18.Logic.Numbers;
using Day18.Logic.Visitors;

namespace Day18.Logic
{
    public class SnailFishNumberSplitter : IReducer
    {
        private SnailFishNumber _value;
        private SnailFishNumber _snailFishNumberToSplitParent;
        private readonly RegularNumber _snailFishNumberToSplit;
        private readonly bool _canReduce;

        public bool CanReduce() => _canReduce;

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

                 if (((RegularNumber)((SnailFishNumber)_snailFishNumberToSplitParent.LeftSide).LeftSide).Value + ((RegularNumber)((SnailFishNumber)_snailFishNumberToSplitParent.LeftSide).RightSide).Value != _snailFishNumberToSplit.Value)
                 {
                     throw new ArgumentException("invalid split value");
                 }
            }
            else
            {
                _snailFishNumberToSplitParent.RightSide = new SnailFishNumber(
                    new RegularNumber((int)Math.Floor(_snailFishNumberToSplit.Value / 2.0)),
                    new RegularNumber((int)Math.Ceiling(_snailFishNumberToSplit.Value / 2.0)));

                 if (((RegularNumber)((SnailFishNumber)_snailFishNumberToSplitParent.RightSide).LeftSide).Value + ((RegularNumber)((SnailFishNumber)_snailFishNumberToSplitParent.RightSide).RightSide).Value != _snailFishNumberToSplit.Value)
                 {
                     throw new ArgumentException("invalid split value");
                 }
            }

            var orderVisitor = new ReorderRegularNumberVisitor();
            _value.Accept(orderVisitor);

            return _value;
        }
    }
}