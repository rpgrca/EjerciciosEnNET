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
                c2 => Assert.Equal(-1, c2),
                c3 => Assert.Equal(-1, c3),
                c4 => Assert.Equal(-1, c4),
                c5 => Assert.Equal(5, c5));

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
                c2 => Assert.Equal(-1, c2),
                c3 => Assert.Equal(-1, c3),
                c4 => Assert.Equal(-1, c4),
                c5 => Assert.Equal(2, c5),
                c6 => Assert.Equal(5, c6),
                c7 => Assert.Equal(4, c7),
                c8 => Assert.Equal(6, c8),
                c9 => Assert.Equal(7, c9));
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
            var sut = new CupGame(SAMPLE_DATA_2, 1000000);
            Assert.Equal(1000000, sut.Cups.Length);
        }

        [Fact]
        public void Test20()
        {
            var sut = new CupGame(SAMPLE_DATA_2, 1000000);
            sut.Moves(500);
        }
    }

    public class CupGame
    {
        private readonly string _cups;
        private int _minimum;
        private int _maximum;

        private int _arrayStart;
        private int _arrayEnd;


        public int CurrentCup { get; private set; }
        public int CurrentCupIndex { get; private set; }
        public int DestinationCup { get; private set; }
        public int[] Cups { get; private set; }
        public int[] Taken { get; }
        public int[] TakenIndex { get; }
        public Dictionary<int, int> Indexes { get; private set; }
        public string GetLabelsAfterCupOne()
        {
            var values = string.Concat(Cups.Select(p => $"{p}")).Split("1");
            return values[1] + values[0];
        }

        public CupGame(string cups, int until = default)
        {
            _cups = cups;
            CurrentCup = 0;
            CurrentCupIndex = 0;
            Taken = new int[3] { 0, 0, 0 };
            TakenIndex = new int[3] { -1, -1, -1 };
            Indexes = new Dictionary<int, int>();
            _arrayStart = 0;

            ParseCups();

            for (var index = 0; index < Cups.Length; index++)
            {
                Indexes[Cups[index]] = index;
                _arrayEnd = index;
            }

            if (until > Cups.Length)
            {
                if (until == default)
                {
                    until = Cups.Length;
                }

                var temp = Cups;
                Cups = new int[until];
                Array.Copy(temp, Cups, cups.Length);

                for (var index = temp.Length; index < Cups.Length; index++)
                {
                    Cups[index] = index;
                    Indexes[Cups[index]] = index;
                    _arrayEnd = index;
                }
            }
        }

        private void ParseCups()
        {
            Cups = _cups.Select(c => int.Parse($"{c}")).ToArray();
            _minimum = Cups.Min();
            _maximum = Cups.Max();
            _arrayEnd = _maximum - 1;

            CurrentCup = Cups[CurrentCupIndex];
        }

        public void Step1()
        {
            var index = 0;
            var toTake = 0;
            for (index = (CurrentCupIndex + 1) % Cups.Length; toTake < 3; index = ++index % Cups.Length)
            {
                Taken[toTake] = Cups[index];
                TakenIndex[toTake++] = index;
                //Indexes[Cups[index]] = -1;
                Cups[index] = -1;
            }
        }

        public void Step2()
        {
            DestinationCup = CurrentCup;

            do
            {
                DestinationCup--;

                if (DestinationCup < _minimum)
                {
                    DestinationCup = _maximum;
                }
            }
            while (Taken.Contains(DestinationCup));
        }

        public void Step3()
        {
            var destinationCupIndex = Indexes[DestinationCup] + 1;
            var minChangedValue = 0;
            var maxChangedValue = Cups.Length;

            if (Cups[0] == -1 && Cups[^1] == -1)
            {
                if (Cups[1] == -1)
                {
                    if (destinationCupIndex == Cups.Length)
                    {
                        Cups[^1] = Cups[2];
                        destinationCupIndex = 0;
                        Indexes[Cups[^1]] = Cups.Length - 1;
                        minChangedValue = 0;
                        maxChangedValue = 3;
                    }
                    else
                    {
                        Array.Copy(Cups, destinationCupIndex, Cups, destinationCupIndex + 1, Cups.Length - (destinationCupIndex + 1));
                        Array.Copy(Cups, 2, Cups, 0, destinationCupIndex - 2);
                        destinationCupIndex -= 2;
                        minChangedValue = 0;
                        maxChangedValue = Cups.Length;
                    }
                }
                else
                {
                    Cups[0] = Cups[^3];
                    Array.Copy(Cups, destinationCupIndex, Cups, Cups.Length - (Cups.Length - destinationCupIndex - 3), Cups.Length - destinationCupIndex - 3);
                    Indexes[Cups[0]] = 0;
                    minChangedValue = destinationCupIndex;
                    maxChangedValue = Cups.Length;
                }
            }
            else
            {
                if (destinationCupIndex > Cups.Length - 3)
                {
                    Array.Copy(Cups, TakenIndex.Max() + 1, Cups, TakenIndex.Min(), Cups.Length - (TakenIndex.Max() + 1));
                    minChangedValue = TakenIndex.Min();
                    destinationCupIndex -= 3;
                }
                else
                {
                    if (destinationCupIndex < TakenIndex.Min() )
                    {
                        var lengthToCopy = TakenIndex.Min() - destinationCupIndex;
                        maxChangedValue = TakenIndex.Max() - lengthToCopy + 1;
                        Array.Copy(Cups, destinationCupIndex, Cups, maxChangedValue, lengthToCopy);
                        maxChangedValue += lengthToCopy;
                        minChangedValue = destinationCupIndex;
                    }
                    else
                    {
                        if (CurrentCupIndex + 1 < Cups.Length)
                        {
                            //Array.Copy(Cups, TakenIndex.Min(), Cups, CurrentCupIndex + 1, destinationCupIndex - TakenIndex.Max() - 1);
                            Array.Copy(Cups, TakenIndex.Max() + 1, Cups, CurrentCupIndex + 1, destinationCupIndex - TakenIndex.Max() - 1);
                            minChangedValue = CurrentCupIndex + 1;
                            destinationCupIndex = CurrentCupIndex + 1 + (destinationCupIndex - TakenIndex.Max() - 1);
                        }
                        else
                        {
                            if (Cups[0] == -1)
                            {
                                Array.Copy(Cups, 3, Cups, 0, destinationCupIndex - 3);
                                minChangedValue = 0;
                                maxChangedValue = destinationCupIndex;
                                destinationCupIndex -= 3;
                            }
                            else
                            {
                                System.Diagnostics.Debugger.Break();
                            }
                        }
                    }
                }
            }

            /*minChangedValue = destinationCupIndex;
            if (destinationCupIndex > TakenIndex.Min())
            {
                destinationCupIndex -= 4;
                minChangedValue -= 4;
            }*/

/*            minChangedValue = destinationCupIndex + 1;
            if (TakenIndex.Min() < minChangedValue)
            {
                minChangedValue = TakenIndex.Min();
            }*/
            Array.Copy(Taken, 0, Cups, destinationCupIndex, 3);

            for (var i = minChangedValue; i < maxChangedValue; i++)
            {
                Indexes[Cups[i]] = i;
            }

            if (CurrentCupIndex < Indexes[CurrentCup])
            {
                var mov = new int[Indexes[CurrentCup] - CurrentCupIndex];
                Array.Copy(Cups, 0, mov, 0, Indexes[CurrentCup] - CurrentCupIndex);
                Array.Copy(Cups, Indexes[CurrentCup] - CurrentCupIndex, Cups, 0, Cups.Length - (Indexes[CurrentCup] - CurrentCupIndex));
                Array.Copy(mov, 0, Cups, Cups.Length - (Indexes[CurrentCup] - CurrentCupIndex), Indexes[CurrentCup] - CurrentCupIndex);

                for (var i = 0; i < Cups.Length; i++)
                {
                    Indexes[Cups[i]] = i;
                }
            }
            else
            {
                if (CurrentCupIndex > Indexes[CurrentCup])
                {
                    var mov = new int[CurrentCupIndex];
                    Array.Copy(Cups, Cups.Length - CurrentCupIndex, mov, 0, CurrentCupIndex);
                    Array.Copy(Cups, 0, Cups, Cups.Length - (Cups.Length - CurrentCupIndex), Cups.Length - CurrentCupIndex);
                    Array.Copy(mov, 0, Cups, 0, CurrentCupIndex);

                    for (var i = 0; i < Cups.Length; i++)
                    {
                        Indexes[Cups[i]] = i;
                    }
                }
            }

/*
            Cups.InsertRange(Cups.IndexOf(DestinationCup) + 1, Taken);

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
            }*/
        }

        public void Step4()
        {
            CurrentCupIndex = CurrentCupIndex + 1 >= Cups.Length? 0 : CurrentCupIndex + 1;
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

    }
}
