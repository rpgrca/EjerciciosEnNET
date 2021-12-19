using Day18.Logic.Numbers;
using Day18.Logic.Visitors;

namespace Day18.Logic.Reducers
{
    public class SnailFishNumberExploder : IReducer
    {
        private readonly bool _canReduce;
        private readonly SnailFishNumber _deepestSnailNumber;
        private readonly SnailFishNumber _deepestSnailNumberParent;
        private readonly SnailFishNumber _value;

        public SnailFishNumberExploder(SnailFishNumber value)
        {
            _value = value;

            var visitor = new ExploderScannerVisitor();
            _value.Accept(visitor);

            _canReduce = visitor.MustExplode();
            _deepestSnailNumber = visitor.DeepestSnailNumber;
            _deepestSnailNumberParent = visitor.DeepestSnailNumberParent;
        }

        public SnailFishNumber Apply()
        {
            _value.Accept(new ReduceByExplosionVisitor(_deepestSnailNumber));
            _deepestSnailNumberParent.ReplaceSideWith(_deepestSnailNumber, 0.AsNumber());

            var visitor = new ReorderRegularNumberVisitor();
            _value.Accept(visitor);

            return _value;
        }

        public bool CanReduce() => _canReduce;
    }
}