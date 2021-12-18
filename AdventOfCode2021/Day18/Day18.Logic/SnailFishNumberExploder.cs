using System;
namespace Day18.Logic
{
    public class SnailFishNumberExploder
    {
        public SnailFishNumber Value { get; }

        public SnailFishNumberExploder(SnailFishNumber value)
        {
            var visitor = new ExploderScannerVisitor();
            value.Accept(visitor);

            if (visitor.MustExplode())
            {
                value.Accept(new ReduceByExplosionVisitor(visitor.DeepestSnailNumber));

                if (visitor.DeepestSnailNumberParent.LeftSide == visitor.DeepestSnailNumber)
                {
                    visitor.DeepestSnailNumberParent.LeftSide = new RegularNumber(0, -1);
                }
                else
                {
                    visitor.DeepestSnailNumberParent.RightSide = new RegularNumber(0, -1);
                }

                Value = value;
            }
        }
    }

    public class SnailFishNumberSplitter
    {
        public SnailFishNumber Value { get; }

        public SnailFishNumberSplitter(SnailFishNumber value)
        {
            var visitor = new SplitterScannerVisitor();
            value.Accept(visitor);

            if (visitor.MustSplit())
            {
                if (visitor.SnailFishNumberToSplitParent.LeftSide == visitor.SnailFishNumberToSplit)
                {
                    visitor.SnailFishNumberToSplitParent.LeftSide = new SnailFishNumber(
                        new RegularNumber((int)Math.Floor(visitor.SnailFishNumberToSplit.Value / 2.0)),
                        new RegularNumber((int)Math.Ceiling(visitor.SnailFishNumberToSplit.Value / 2.0)));
                }
                else
                {
                    visitor.SnailFishNumberToSplitParent.RightSide = new SnailFishNumber(
                        new RegularNumber((int)Math.Floor(visitor.SnailFishNumberToSplit.Value / 2.0)),
                        new RegularNumber((int)Math.Ceiling(visitor.SnailFishNumberToSplit.Value / 2.0)));
                }
            }

            Value = value;
        }
    }
}