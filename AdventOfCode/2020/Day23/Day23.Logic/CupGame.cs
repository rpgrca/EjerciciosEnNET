using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day23.Logic
{
    public class CupGame
    {
        private readonly Dictionary<int, LinkedListNode<int>> _index;
        private readonly LinkedList<int> _cups;
        private readonly string _data;
        private int _minimum = int.MaxValue;
        private int _maximum = int.MinValue;
        private LinkedListNode<int> _currentCup;
        private readonly int[] _taken;
        private LinkedListNode<int> _destinationCup;
        private LinkedListNode<int> _first;

        public int FirstNumberAfterOne { get; private set; }
        public int SecondNumberAfterOne { get; private set; }
        public ulong MultiplyFirstAndSecondNumberAfterOne { get; private set; }

        public CupGame(string data)
        {
            _data = data;
            _cups = new LinkedList<int>();
            _index = new Dictionary<int, LinkedListNode<int>>();
            _taken = new int[] { 0, 0, 0 };

            ParseCups();
        }

        public CupGame(string data, int amount)
            : this(data) =>
            CompleteListOfNumbersUntilReaching(amount);

        private void CompleteListOfNumbersUntilReaching(int amount)
        {
            for (var index = _maximum + 1; index <= amount; index++)
            {
                _index.Add(index, _cups.AddLast(index));
            }

            _maximum = amount;
        }

        private void ParseCups()
        {
            foreach (var cup in _data.Select(c => int.Parse($"{c}")))
            {
                var lastNode = _cups.AddLast(cup);
                _index.Add(cup, lastNode);

                if (cup < _minimum) _minimum = cup;
                if (cup > _maximum) _maximum = cup;
            }

            _currentCup = _first = _cups.First;
        }

        public void RemoveThreeCupsAfterCurrentCup()
        {
            PutAsideThreeCups();
            RemovePutAsideCupsFromCircle();
            RemovePutAsideCupsFromIndex();
        }

        private void PutAsideThreeCups()
        {
            _taken[0] = _currentCup.NextOrFirst().Value;
            _taken[1] = _currentCup.NextOrFirst().NextOrFirst().Value;
            _taken[2] = _currentCup.NextOrFirst().NextOrFirst().NextOrFirst().Value;
        }

        private void RemovePutAsideCupsFromCircle()
        {
            RemovePutAsideCup();
            RemovePutAsideCup();
            RemovePutAsideCup();

            RestoreFirstCupIfDeleted();
        }

        private void RemovePutAsideCupsFromIndex()
        {
            _index.Remove(_taken[0]);
            _index.Remove(_taken[1]);
            _index.Remove(_taken[2]);
        }

        private void RemovePutAsideCup() =>
            _cups.Remove(_currentCup.NextOrFirst());

        private void RestoreFirstCupIfDeleted()
        {
            if (_first.List == null)
            {
                _first = _currentCup.NextOrFirst();
            }
        }

        public void SelectDestinationCup()
        {
            var value = _currentCup.Value;
            do
            {
                value--;
                if (value < _minimum)
                {
                    value = _maximum;
                }
            }
            while (value == _taken[0] || value == _taken[1] || value == _taken[2]);

            _destinationCup = _index[value];
        }

        public void MoveSelectedCupsAfterDestinationCup()
        {
            _index.Add(_taken[2], _cups.AddAfter(_destinationCup, _taken[2]));
            _index.Add(_taken[1], _cups.AddAfter(_destinationCup, _taken[1]));
            _index.Add(_taken[0], _cups.AddAfter(_destinationCup, _taken[0]));
        }

        public void MoveCurrentCupToCupAfterIt() =>
            _currentCup = _currentCup.NextOrFirst();

        private void Move()
        {
            RemoveThreeCupsAfterCurrentCup();
            SelectDestinationCup();
            MoveSelectedCupsAfterDestinationCup();
            MoveCurrentCupToCupAfterIt();
        }

        public void Moves(int times)
        {
            for (var index = 0; index < times; index++)
            {
                Move();
            }

            CalculateValuesAfterOne();
        }

        private void CalculateValuesAfterOne()
        {
            FirstNumberAfterOne = _index[1].NextOrFirst().Value;
            SecondNumberAfterOne = _index[1].NextOrFirst().NextOrFirst().Value;
            MultiplyFirstAndSecondNumberAfterOne = (ulong)FirstNumberAfterOne * (ulong)SecondNumberAfterOne;
        }

        public string GetLabelsAfterCupOne()
        {
            var labels = string.Empty;
            var first = _index[1].NextOrFirst();

            while (first.Value != 1)
            {
                labels += first.Value.ToString();
                first = first.NextOrFirst();
            }

            return labels;
        }

        public List<int> GetCupsInOrder()
        {
            var list = new List<int>();

            for (var node = _first; node != null; node = node.Next)
            {
                list.Add(node.Value);
            }

            return list;
        }
    }
}