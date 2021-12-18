namespace Day18.Logic
{
    public class SnailFishNumberExploder
    {
        public SnailFishNumber Value { get; }

        public SnailFishNumberExploder(SnailFishNumber value)
        {
            var visitor = new NumberExploderVisitor();
            value.Accept(visitor);

            if (visitor.MustExplode())
            {
                value.Accept(new ReducerByExplosionVisitor(visitor.DeepestSnailNumber));

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
}