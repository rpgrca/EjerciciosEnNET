using System.Linq;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day23.UnitTests
{
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
        public int FirstNumberAfterOne { get; private set; }
        public int SecondNumberAfterOne { get; private set; }

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
                //Buffer.BlockCopy(temp, 0, Cups, 0, sizeof(int) * cups.Length);
                Array.Copy(temp, Cups, cups.Length);

                for (var index = temp.Length; index < Cups.Length; index++)
                {
                    Cups[index] = index + 1;
                    Indexes[Cups[index]] = index + 1;
                    _arrayEnd = index + 1;
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
            if (CurrentCupIndex + 3 >= Cups.Length)
            {
                for (index = (CurrentCupIndex + 1) % Cups.Length; toTake < 3; index = ++index % Cups.Length)
                {
                    Taken[toTake] = Cups[index];
                    TakenIndex[toTake++] = index;
                    Cups[index] = -1;
                }

                Array.Sort(TakenIndex);
            }
            else
            {
                for (index = CurrentCupIndex + 1; toTake < 3; ++index)
                {
                    Taken[toTake] = Cups[index];
                    TakenIndex[toTake++] = index;
                    Cups[index] = -1;
                }
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
            while (DestinationCup == Taken[0] || DestinationCup == Taken[1] || DestinationCup == Taken[2]); //  Taken.Contains(DestinationCup));
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
                        Cups[^1] = Cups[2];
                        Array.Copy(Cups, 3, Cups, 0, destinationCupIndex - 3);
                        destinationCupIndex -= 3;
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
                    Array.Copy(Cups, TakenIndex[2] + 1, Cups, TakenIndex[0], Cups.Length - (TakenIndex[2] + 1));
                    minChangedValue = TakenIndex[0];
                    destinationCupIndex -= 3;
                }
                else
                {
                    if (destinationCupIndex < TakenIndex[0])
                    {
                        var lengthToCopy = TakenIndex[0] - destinationCupIndex;
                        maxChangedValue = TakenIndex[2] - lengthToCopy + 1;
                        Array.Copy(Cups, destinationCupIndex, Cups, maxChangedValue, lengthToCopy);
                        maxChangedValue += lengthToCopy;
                        minChangedValue = destinationCupIndex;
                    }
                    else
                    {
                        if (CurrentCupIndex + 1 < Cups.Length)
                        {
                            Array.Copy(Cups, TakenIndex[2] + 1, Cups, CurrentCupIndex + 1, destinationCupIndex - TakenIndex[2] - 1);
                            minChangedValue = CurrentCupIndex + 1;
                            destinationCupIndex = CurrentCupIndex + 1 + (destinationCupIndex - TakenIndex[2] - 1);
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

            Array.Copy(Taken, 0, Cups, destinationCupIndex, 3);

            if (minChangedValue == 0 && maxChangedValue >= Cups.Length)
            {
                for (var i = minChangedValue; i < maxChangedValue; i++)
                {
                    Indexes[Cups[i]] = i;
                }

                System.Diagnostics.Debugger.Break();
            }
            else
            {
                for (var i = minChangedValue; i < maxChangedValue; i++)
                {
                    Indexes[Cups[i]] = i;
                }
            }

            CurrentCupIndex = Indexes[CurrentCup];
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

            var oneIndex = Indexes[1];
            FirstNumberAfterOne = Cups[(oneIndex + 1) % Cups.Length];
            SecondNumberAfterOne = Cups[(oneIndex + 2) % Cups.Length];
        }
    }
}