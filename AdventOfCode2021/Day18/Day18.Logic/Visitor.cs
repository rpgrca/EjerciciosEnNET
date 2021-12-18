using System.ComponentModel.DataAnnotations;
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

    public class ExploderScannerVisitor : INumberVisitor
    {
        private int _level;
        private SnailFishNumber _currentNumber;
        private SnailFishNumber _parentNumber;

        public SnailFishNumber DeepestSnailNumberParent { get; private set; }
        public SnailFishNumber DeepestSnailNumber { get; private set; }
        public int DeepestLevel { get; private set; }

        public ExploderScannerVisitor()
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

    public class ReduceByExplosionVisitor : INumberVisitor
    {
        private readonly SnailFishNumber _deepestFishNumber;

        public ReduceByExplosionVisitor(SnailFishNumber deepestFishNumber)
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

    public class SplitterScannerVisitor : INumberVisitor
    {
        private RegularNumber _currentNumber;
        private SnailFishNumber _parentNumber;
        public RegularNumber SnailFishNumberToSplit { get; private set; }
        public SnailFishNumber SnailFishNumberToSplitParent { get; private set; }

        public void Visit(SnailFishNumber snailFishNumber)
        {
            _parentNumber = snailFishNumber;
        }

        public void Visit(RegularNumber regularNumber)
        {
            _currentNumber = regularNumber;

            if (_currentNumber.Value >= 10 && SnailFishNumberToSplit is null)
            {
                SnailFishNumberToSplit = _currentNumber;
                SnailFishNumberToSplitParent = _parentNumber;
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

        public void AddLevel()
        {
        }

        public void RemoveLevel()
        {
        }

        public bool MustSplit() => SnailFishNumberToSplit != null;
    }
}