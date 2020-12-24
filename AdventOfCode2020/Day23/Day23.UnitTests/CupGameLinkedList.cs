using System.ComponentModel;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day23.UnitTests
{
    public static class CircularLinkedList
    {
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current)
        {
            return current.Next ?? current.List.First;
        }

        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current)
        {
            return current.Previous ?? current.List.Last;
        }
    }

    public class CupGameWithLinkedLists
    {
        private readonly Dictionary<int, LinkedListNode<int>> _index;
        private readonly LinkedList<int> _cups;
        private readonly string _data;
        private int _minimum = int.MaxValue;
        private int _maximum = int.MinValue;
        private LinkedListNode<int> CurrentCup;
        private int[] Taken;
        private LinkedListNode<int> DestinationCup;
        private LinkedListNode<int> First;

        public int FirstNumberAfterOne { get; private set; }
        public int SecondNumberAfterOne { get; private set; }
        public ulong MultiplyFirstAndSecondNumberAfterOne { get; private set; }

        public CupGameWithLinkedLists(string data)
        {
            _data = data;
            _cups = new LinkedList<int>();
            _index = new Dictionary<int, LinkedListNode<int>>();
            Taken = new int[] { 0, 0, 0 };

            ParseCups();
        }

        public CupGameWithLinkedLists(string data, int until)
            : this(data)
        {
            for (var index = _maximum + 1; index <= until; index++)
            {
                var lastNode = _cups.AddLast(index);
                _index.Add(index, lastNode);

                _maximum = index;
            }
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

            First = _cups.First;
            CurrentCup = First;
        }

        public void Step1()
        {
            Taken[0] = CurrentCup.NextOrFirst().Value;
            Taken[1] = CurrentCup.NextOrFirst().NextOrFirst().Value;
            Taken[2] = CurrentCup.NextOrFirst().NextOrFirst().NextOrFirst().Value;

            var node = CurrentCup.NextOrFirst();
            if (node == First)
            {
                First = node.NextOrFirst();
            }
            if (node == DestinationCup)
            {
                System.Diagnostics.Debugger.Break();
            }

            _cups.Remove(node);

            node = CurrentCup.NextOrFirst();
            if (node == First)
            {
                First = node.NextOrFirst();
            }
            if (node == DestinationCup)
            {
                System.Diagnostics.Debugger.Break();
            }

            _cups.Remove(node);

            node = CurrentCup.NextOrFirst();
            if (node == First)
            {
                First = node.NextOrFirst();
            }
            if (node == DestinationCup)
            {
                System.Diagnostics.Debugger.Break();
            }
            _cups.Remove(node);

            _index.Remove(Taken[0]);
            _index.Remove(Taken[1]);
            _index.Remove(Taken[2]);
        }

        public void Step2()
        {
            var value = CurrentCup.Value;
            do
            {
                value--;
                if (value < _minimum)
                {
                    value = _maximum;
                }
            }
            while(value == Taken[0] || value == Taken[1] || value == Taken[2]);

            DestinationCup = _index[value];
        }

        public void Step3()
        {
            var node = _cups.AddAfter(DestinationCup, Taken[2]);
            _index.Add(Taken[2], node);

            node = _cups.AddAfter(DestinationCup, Taken[1]);
            _index.Add(Taken[1], node);

            node = _cups.AddAfter(DestinationCup, Taken[0]);
            _index.Add(Taken[0], node);
        }

        public void Step4()
        {
            CurrentCup = CurrentCup.NextOrFirst();
        }

        private void Move()
        {
            Step1();
            Step2();
            Step3();
            Step4();
        }

        public void Moves(int times)
        {
            for (var index = 0; index < times; index++)
            {
                Move();
            }

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
            var node = First;

            do
            {
                list.Add(node.Value);
                node = node.Next;
            }
            while (node != null);

            return list;
        }
    }
}