using Day18.Logic.Numbers;
using Day18.Logic.Visitors;

namespace Day18.Logic
{
    public interface IReducer
    {
        SnailFishNumber Apply();
        bool CanReduce();
    }

    public class SnailFishNumberExploder : IReducer
    {
        private readonly bool _canReduce;
        public bool CanReduce() => _canReduce;

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

            if (_deepestSnailNumberParent.LeftSide == _deepestSnailNumber)
            {
                _deepestSnailNumberParent.LeftSide = new RegularNumber(0);
            }
            else
            {
                _deepestSnailNumberParent.RightSide = new RegularNumber(0);
            }

            var visitor = new ReorderRegularNumberVisitor();
            _value.Accept(visitor);

            return _value;
        }
    }
}