using System;
using System.Collections.Generic;

namespace Day18.Logic
{
    public interface IVisitable
    {
        void Accept(INumberVisitor visitor);
    }

    public interface INumberVisitor
    {
        void Visit(SnailFishNumber snailFishNumber);
        void Visit(RegularNumber regularNumber);
        void Visit(Number number);
        void AddLevel();
        void RemoveLevel();
    }

    public class NumberExploderVisitor : INumberVisitor
    {
        private int _level;
        private SnailFishNumber _currentNumber;
        private SnailFishNumber _parentNumber;

        public SnailFishNumber DeepestSnailNumberParent { get; private set; }
        public SnailFishNumber DeepestSnailNumber { get; private set; }
        public int DeepestLevel { get; private set; }

        public NumberExploderVisitor()
        {
            _level = 0;
        }

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

        public void Visit(Number number)
        {
            if (number is SnailFishNumber snailFishNumber)
            {
                Visit(snailFishNumber);
            }

            if (number is RegularNumber regularNumber)
            {
                Visit(regularNumber);
            }
        }

        public bool MustExplode() => DeepestLevel >= 4;

        public void AddLevel()
        {
            _level++;
        }

        public void RemoveLevel()
        {
            _level--;
        }
    }

    public class ReducerByExplosionVisitor : INumberVisitor
    {
        private readonly SnailFishNumber _deepestFishNumber;

        public ReducerByExplosionVisitor(SnailFishNumber deepestFishNumber)
        {
            _deepestFishNumber = deepestFishNumber;
        }

        public void AddLevel()
        {
        }

        public void RemoveLevel()
        {
        }

        public void Visit(SnailFishNumber snailFishNumber)
        {
        }

        public void Visit(RegularNumber regularNumber)
        {
            if (regularNumber.IsLeftOf((RegularNumber)_deepestFishNumber.LeftSide))
            {
                regularNumber.Add((RegularNumber)_deepestFishNumber.LeftSide);
            }

            if (regularNumber.IsRightOf((RegularNumber)_deepestFishNumber.RightSide))
            {
                regularNumber.Add((RegularNumber)_deepestFishNumber.RightSide);
            }
        }

        public void Visit(Number number)
        {
            if (number is SnailFishNumber snailFishNumber)
            {
                Visit(snailFishNumber);
            }

            if (number is RegularNumber regularNumber)
            {
                Visit(regularNumber);
            }
        }
    }
}