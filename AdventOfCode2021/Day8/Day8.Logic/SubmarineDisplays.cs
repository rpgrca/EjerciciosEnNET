using System;
using System.Linq;
using System.Collections.Generic;

namespace Day8.Logic
{
    public class SubmarineDisplays
    {
        private readonly string _data;
        private readonly int[] _fixedDisplays;
        private List<(List<string> Signals, List<string> Display)> _scannings;

        public int TotalScannings => _scannings.Count;
        public int DigitsWithUniqueNumberOfSegments { get; private set; }

        public SubmarineDisplays(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid wiring");
            }

            _data = data;
            Parse();
            _fixedDisplays = new int[_scannings.Count];
            CountDigitsWithUniqueNumberOfSegments();
        }

        private void Parse() =>
            _scannings = _data
                .Split("\n")
                .Select(p => p.Split("|"))
                .Select(p => (
                    p[0].Trim().Split(" ").Select(p => string.Join(string.Empty, p.OrderBy(p => p))).ToList(),
                    p[1].Trim().Split(" ").Select(p => string.Join(string.Empty, p.OrderBy(p => p))).ToList()))
                .ToList();

        private void CountDigitsWithUniqueNumberOfSegments()
        {
            DigitsWithUniqueNumberOfSegments = _scannings
                .Select(p => p.Display)
                .Select(p => p.Count(x => x.Length == 2 || x.Length == 4 || x.Length == 3 || x.Length == 7))
                .Sum();
        }

        public List<string> GetDisplayFor(int index)
        {
            return _scannings[index].Display;
        }

        public List<char> GetWiringForDisplay(int index)
        {
            var signals = _scannings[index].Signals;
            var numbers = new List<List<char>>
            {
                { new() },
                { signals.Single(p => p.Length == 2).Select(p => p).ToList() },
                { new() },
                { new() },
                { signals.Single(p => p.Length == 4).Select(p => p).ToList() },
                { new() },
                { new() },
                { signals.Single(p => p.Length == 3).Select(p => p).ToList() },
                { signals.Single(p => p.Length == 7).Select(p => p).ToList() },
                { new() }
            };

            var segments = new Dictionary<char, char>
            {
                { 'a', '\0' },
                { 'b', '\0' },
                { 'c', '\0' },
                { 'd', '\0' },
                { 'e', '\0' },
                { 'f', '\0' },
                { 'g', '\0' }
            };

            // 2) Si comparo el 7 con el 1, el segmento en el 7 que no está en el 1 es el segmento AA
            segments['a'] = numbers[7].Except(numbers[1]).Single();

            // 4) Tomo los numeros con 5 segmentos (2, 3, 5), a cada uno le quito los segmentos existentes en los
            // otros y el que queda vacío es el 3
            var possibleTwoThreeFive = signals.Where(p => p.Length == 5).Select(p => p.ToCharArray().ToList()).ToList();
            var a1 = possibleTwoThreeFive[0].Except(possibleTwoThreeFive[1]).Except(possibleTwoThreeFive[2]);
            if (!a1.Any())
            {
                numbers[3] = possibleTwoThreeFive[0];
                if (! possibleTwoThreeFive[1].Except(numbers[3]).Except(numbers[4]).Any())
                {
                    numbers[5] = possibleTwoThreeFive[1];
                    numbers[2] = possibleTwoThreeFive[2];
                }
                else
                {
                    numbers[5] = possibleTwoThreeFive[2];
                    numbers[2] = possibleTwoThreeFive[1];
                }
            }
            else
            {
                var a2 = possibleTwoThreeFive[1].Except(possibleTwoThreeFive[0]).Except(possibleTwoThreeFive[2]);
                if (!a2.Any())
                {
                    numbers[3] = possibleTwoThreeFive[1];
                    if (! possibleTwoThreeFive[0].Except(numbers[3]).Except(numbers[4]).Any())
                    {
                        numbers[5] = possibleTwoThreeFive[0];
                        numbers[2] = possibleTwoThreeFive[2];
                    }
                    else
                    {
                        numbers[5] = possibleTwoThreeFive[2];
                        numbers[2] = possibleTwoThreeFive[0];
                    }
                }
                else
                {
                    numbers[3] = possibleTwoThreeFive[2];
                    if (! possibleTwoThreeFive[0].Except(numbers[3]).Except(numbers[4]).Any())
                    {
                        numbers[5] = possibleTwoThreeFive[0];
                        numbers[2] = possibleTwoThreeFive[1];
                    }
                    else
                    {
                        numbers[5] = possibleTwoThreeFive[1];
                        numbers[2] = possibleTwoThreeFive[0];
                    }
                }
            }

            // 4.1) Tomo al 3 y le saco los segmentos del 7 y del 4, me queda el segmento GG
            segments['g'] = numbers[3].Except(numbers[7]).Except(numbers[4]).Single();

            // 4.2) Tomo al 2, le resto el 3 y obtengo el segmento EE
            segments['e'] = numbers[2].Except(numbers[3]).Single();
            segments['b'] = numbers[5].Except(numbers[3]).Single();
            segments['c'] = numbers[4].Except(numbers[5]).Single();
            segments['d'] = numbers[4].Except(numbers[1]).Except(new List<char>() { segments['b'] }).Single();
            segments['f'] = numbers[1].Except(new List<char>() { segments['c']}).Single();

            numbers[0] = new List<char> { segments['a'], segments['b'], segments['c'], segments['e'], segments['f'], segments['g'] };
            numbers[6] = new List<char> { segments['a'], segments['b'], segments['d'], segments['e'], segments['f'], segments['g'] };
            numbers[9] = new List<char> { segments['a'], segments['b'], segments['c'], segments['d'], segments['f'], segments['g'] };

            var fixedNumbers = new Dictionary<string, string>
            {
                { string.Join("", numbers[0].OrderBy(p => p)), "0" },
                { string.Join("", numbers[1].OrderBy(p => p)), "1" },
                { string.Join("", numbers[2].OrderBy(p => p)), "2" },
                { string.Join("", numbers[3].OrderBy(p => p)), "3" },
                { string.Join("", numbers[4].OrderBy(p => p)), "4" },
                { string.Join("", numbers[5].OrderBy(p => p)), "5" },
                { string.Join("", numbers[6].OrderBy(p => p)), "6" },
                { string.Join("", numbers[7].OrderBy(p => p)), "7" },
                { string.Join("", numbers[8].OrderBy(p => p)), "8" },
                { string.Join("", numbers[9].OrderBy(p => p)), "9" }
            };

            _fixedDisplays[index] = int.Parse(string.Concat(_scannings[index].Display.Select(p => fixedNumbers[p])));

            return new List<char>(segments.Values);
        }

        public int GetFixedDisplayFor(int index)
        {
            return _fixedDisplays[index];
        }

        public int GetSumOfDisplays()
        {
            var sum = 0;

            for (var index = 0; index < _scannings.Count; index++)
            {
                GetWiringForDisplay(index);
                sum += GetFixedDisplayFor(index);
            }

            return sum;
        }
    }
}