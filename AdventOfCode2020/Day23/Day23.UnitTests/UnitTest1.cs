using System.Xml.Schema;
using System.ComponentModel;
using System.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2020.Day23.UnitTests
{
    public class UnitTest1
    {
        private const string SAMPLE_DATA = "32415";
        private const string SAMPLE_DATA_2 = "389125467";
        private const string PUZZLE_DATA = "853192647";

        [Fact]
        public void Test1()
        {
            var sut = new CupGame(SAMPLE_DATA);
            Assert.Equal(0, sut.CurrentCupIndex);
            Assert.Equal(3, sut.CurrentCup);
            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(4, c3),
                c4 => Assert.Equal(1, c4),
                c5 => Assert.Equal(5, c5));
        }

        [Fact]
        public void Test2()
        {
            var sut = new CupGame(SAMPLE_DATA);

            sut.Step1();
            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(5, c2));

            Assert.Collection(sut.Taken,
                t1 => Assert.Equal(2, t1),
                t2 => Assert.Equal(4, t2),
                t3 => Assert.Equal(1, t3));
        }

        [Fact]
        public void Test3()
        {
            var sut = new CupGame(SAMPLE_DATA);
            sut.Step1();

            sut.Step2();
            Assert.Equal(5, sut.DestinationCup);
        }

        [Fact]
        public void Test4()
        {
            var sut = new CupGame(SAMPLE_DATA);
            sut.Step1();
            sut.Step2();

            sut.Step3();
            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(5, c2),
                c3 => Assert.Equal(2, c3),
                c4 => Assert.Equal(4, c4),
                c5 => Assert.Equal(1, c5));
        }

        [Fact]
        public void Test5()
        {
            var sut = new CupGame(SAMPLE_DATA);
            sut.Step1();
            sut.Step2();
            sut.Step3();

            sut.Step4();
            Assert.Equal(5, sut.CurrentCup);
            Assert.Equal(1, sut.CurrentCupIndex);
        }

        [Fact]
        public void Test6()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.Step1();

            Assert.Equal(0, sut.CurrentCupIndex);
            Assert.Equal(3, sut.CurrentCup);
            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(5, c3),
                c4 => Assert.Equal(4, c4),
                c5 => Assert.Equal(6, c5),
                c6 => Assert.Equal(7, c6));
            Assert.Collection(sut.Taken,
                t1 => Assert.Equal(8, t1),
                t2 => Assert.Equal(9, t2),
                t3 => Assert.Equal(1, t3));
        }

        [Fact]
        public void Test7()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.Moves(1);

            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(8, c3),
                c4 => Assert.Equal(9, c4),
                c5 => Assert.Equal(1, c5),
                c6 => Assert.Equal(5, c6),
                c7 => Assert.Equal(4, c7),
                c8 => Assert.Equal(6, c8),
                c9 => Assert.Equal(7, c9));
        }

        [Fact]
        public void Test8()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.Moves(2);

            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(5, c3),
                c4 => Assert.Equal(4, c4),
                c5 => Assert.Equal(6, c5),
                c6 => Assert.Equal(7, c6),
                c7 => Assert.Equal(8, c7),
                c8 => Assert.Equal(9, c8),
                c9 => Assert.Equal(1, c9));
        }

        [Fact]
        public void Test9()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.Moves(3);

            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(7, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(5, c3),
                c4 => Assert.Equal(8, c4),
                c5 => Assert.Equal(9, c5),
                c6 => Assert.Equal(1, c6),
                c7 => Assert.Equal(3, c7),
                c8 => Assert.Equal(4, c8),
                c9 => Assert.Equal(6, c9));
        }

        [Fact]
        public void Test10()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.Moves(4);

            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(5, c3),
                c4 => Assert.Equal(8, c4),
                c5 => Assert.Equal(4, c5),
                c6 => Assert.Equal(6, c6),
                c7 => Assert.Equal(7, c7),
                c8 => Assert.Equal(9, c8),
                c9 => Assert.Equal(1, c9));
        }

        [Fact]
        public void Test11()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.Moves(5);

            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(9, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(5, c3),
                c4 => Assert.Equal(8, c4),
                c5 => Assert.Equal(4, c5),
                c6 => Assert.Equal(1, c6),
                c7 => Assert.Equal(3, c7),
                c8 => Assert.Equal(6, c8),
                c9 => Assert.Equal(7, c9));
        }

        [Fact]
        public void Test12()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.Moves(6);

            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(7, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(5, c3),
                c4 => Assert.Equal(8, c4),
                c5 => Assert.Equal(4, c5),
                c6 => Assert.Equal(1, c6),
                c7 => Assert.Equal(9, c7),
                c8 => Assert.Equal(3, c8),
                c9 => Assert.Equal(6, c9));
        }

        [Fact]
        public void Test13()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.Moves(7);

            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(8, c1),
                c2 => Assert.Equal(3, c2),
                c3 => Assert.Equal(6, c3),
                c4 => Assert.Equal(7, c4),
                c5 => Assert.Equal(4, c5),
                c6 => Assert.Equal(1, c6),
                c7 => Assert.Equal(9, c7),
                c8 => Assert.Equal(2, c8),
                c9 => Assert.Equal(5, c9));
        }

        [Fact]
        public void Test14()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.Moves(8);

            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(7, c1),
                c2 => Assert.Equal(4, c2),
                c3 => Assert.Equal(1, c3),
                c4 => Assert.Equal(5, c4),
                c5 => Assert.Equal(8, c5),
                c6 => Assert.Equal(3, c6),
                c7 => Assert.Equal(9, c7),
                c8 => Assert.Equal(2, c8),
                c9 => Assert.Equal(6, c9));
        }

        [Fact]
        public void Test15()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.Moves(9);

            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(5, c1),
                c2 => Assert.Equal(7, c2),
                c3 => Assert.Equal(4, c3),
                c4 => Assert.Equal(1, c4),
                c5 => Assert.Equal(8, c5),
                c6 => Assert.Equal(3, c6),
                c7 => Assert.Equal(9, c7),
                c8 => Assert.Equal(2, c8),
                c9 => Assert.Equal(6, c9));
        }

        [Fact]
        public void Test16()
        {
            var sut = new CupGame(SAMPLE_DATA_2);

            sut.Moves(10);
            Assert.Collection(sut.Cups,
                c1 => Assert.Equal(5, c1),
                c2 => Assert.Equal(8, c2),
                c3 => Assert.Equal(3, c3),
                c4 => Assert.Equal(7, c4),
                c5 => Assert.Equal(4, c5),
                c6 => Assert.Equal(1, c6),
                c7 => Assert.Equal(9, c7),
                c8 => Assert.Equal(2, c8),
                c9 => Assert.Equal(6, c9));
        }

        [Fact]
        public void Test17()
        {
            var sut = new CupGame(SAMPLE_DATA_2);

            sut.Moves(10);
            Assert.Equal("92658374", sut.GetLabelsAfterCupOne());
        }

        [Fact]
        public void Test18()
        {
            var sut = new CupGame(SAMPLE_DATA_2);

            sut.Moves(100);
            Assert.Equal("67384529", sut.GetLabelsAfterCupOne());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new CupGame(PUZZLE_DATA);

            sut.Moves(100);
            Assert.Equal("97624853", sut.GetLabelsAfterCupOne());
        }

        [Fact]
        public void Test19()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.FillUpToAMillionCups();
            Assert.Equal(1000000, sut.Cups.Count);
        }

        /*[Fact]
        public void Test20()
        {
            var sut = new CupGame(SAMPLE_DATA_2);
            sut.FillUpToAMillionCups();

            sut.Moves(10000000);
        }*/
    }

    public class CupGame
    {
        private readonly string _cups;
        private List<int> _allCups;

        public int CurrentCup { get; private set; }
        public int CurrentCupIndex { get; private set; }
        public int DestinationCup { get; private set; }
        public List<int> Cups { get; private set; }
        public List<int> Taken { get; }
        public string GetLabelsAfterCupOne()
        {
            var values = string.Concat(Cups.Select(p => $"{p}")).Split("1");
            return values[1] + values[0];
        }

        public CupGame(string cups)
        {
            _cups = cups;
            CurrentCup = 0;
            CurrentCupIndex = 0;
            Taken = new List<int>();

            ParseCups();
        }

        private void ParseCups()
        {
            Cups = _cups.Select(c => int.Parse($"{c}")).ToList();
            _allCups = Cups.OrderBy(p => p).ToList();

            CurrentCup = Cups[CurrentCupIndex];
        }

        public void Step1()
        {
            for (var index = (CurrentCupIndex + 1) % Cups.Count; Taken.Count < 3; index = ++index % Cups.Count)
            {
                Taken.Add(Cups[index]);
            }

            Cups.RemoveAll(p => Taken.Contains(p));
        }

        public void Step2()
        {
            DestinationCup = CurrentCup;

            do
            {
                DestinationCup--;

                if (DestinationCup < _allCups[0])
                {
                    DestinationCup = _allCups[^1];
                }
            }
            while (Taken.Contains(DestinationCup));
        }

        public void Step3()
        {
            Cups.InsertRange(Cups.IndexOf(DestinationCup) + 1, Taken);
            Taken.Clear();

            var newCurrentCupIndex = Cups.IndexOf(CurrentCup);
            if (newCurrentCupIndex > CurrentCupIndex)
            {
                for (var index = 0; index < newCurrentCupIndex - CurrentCupIndex; index++)
                {
                    Cups.Add(Cups[0]);
                    Cups.RemoveAt(0);
                }
            }
            else
            {
                for (var index = 0; index < CurrentCupIndex - newCurrentCupIndex; index++)
                {
                    Cups.Insert(0, Cups[^1]);
                    Cups.RemoveAt(Cups.Count - 1);
                }
            }
        }

        public void Step4()
        {
            CurrentCupIndex = CurrentCupIndex + 1 >= Cups.Count? 0 : CurrentCupIndex + 1;
            CurrentCup = Cups[CurrentCupIndex];
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
        }

        public void FillUpToAMillionCups()
        {
            Cups.AddRange(Enumerable.Range(10, 999991));
        }
    }
}
