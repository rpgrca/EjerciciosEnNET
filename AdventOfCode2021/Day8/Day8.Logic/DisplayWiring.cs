using System.Linq;
using System.Collections.Generic;

namespace Day8.Logic
{
    public class DisplayWiring
    {
        private readonly List<string> _signals;
        private readonly List<string> _display;
        private readonly List<IEnumerable<char>> _numbers;
        private readonly Dictionary<char, char> _segments;

        public int Value { get; private set; }
        public List<char> Wiring => _segments.Values.ToList();

        public DisplayWiring(List<string> signals, List<string> display)
        {
            _signals = signals;
            _display = display;

            _numbers = new List<IEnumerable<char>>();
            _segments = new Dictionary<char, char>
            {
                { 'a', '\0' },
                { 'b', '\0' },
                { 'c', '\0' },
                { 'd', '\0' },
                { 'e', '\0' },
                { 'f', '\0' },
                { 'g', '\0' }
            };

            ClassifyNumbers();
            CalculateWirings();
        }

        private void ClassifyNumbers() =>
            _numbers.AddRange(new List<IEnumerable<char>>
            {
                { null },
                { _signals.Single(p => p.Length == 2).Select(p => p).OrderBy(p => p) },
                { null },
                { null },
                { _signals.Single(p => p.Length == 4).Select(p => p).OrderBy(p => p) },
                { null },
                { null },
                { _signals.Single(p => p.Length == 3).Select(p => p).OrderBy(p => p) },
                { _signals.Single(p => p.Length == 7).Select(p => p).OrderBy(p => p) },
                { null }
            });

        private void CalculateWirings()
        {
            DeduceSegmentA();
            DeduceNumbersTwoThreeAndFive();
            DeduceSegmentG();
            DeduceSegmentE();
            DeduceSegmentB();
            DeduceSegmentC();
            DeduceSegmentD();
            DeduceSegmentF();
            DeduceNumber0();
            DeduceNumber6();
            DeduceNumber9();

            var fixedNumbers = new Dictionary<string, string>
            {
                { string.Join("", _numbers[0]), "0" },
                { string.Join("", _numbers[1]), "1" },
                { string.Join("", _numbers[2]), "2" },
                { string.Join("", _numbers[3]), "3" },
                { string.Join("", _numbers[4]), "4" },
                { string.Join("", _numbers[5]), "5" },
                { string.Join("", _numbers[6]), "6" },
                { string.Join("", _numbers[7]), "7" },
                { string.Join("", _numbers[8]), "8" },
                { string.Join("", _numbers[9]), "9" }
            };

            Value = int.Parse(string.Concat(_display.Select(p => fixedNumbers[p])));
        }

        private void DeduceSegmentA() =>
            // 2) Si comparo el 7 con el 1, el segmento en el 7 que no está en el 1 es el segmento AA
            _segments['a'] = _numbers[7].Except(_numbers[1]).Single();

        private void DeduceNumbersTwoThreeAndFive()
        {
            // 4) Tomo los numeros con 5 segmentos (2, 3, 5), a cada uno le quito los segmentos existentes en los
            // otros y el que queda vacío es el 3
            var possibleTwoThreeFive = _signals.Where(p => p.Length == 5).Select(p => p.ToCharArray().ToList()).ToList();
            var a1 = possibleTwoThreeFive[0].Except(possibleTwoThreeFive[1]).Except(possibleTwoThreeFive[2]);
            if (!a1.Any())
            {
                _numbers[3] = possibleTwoThreeFive[0];
                if (! possibleTwoThreeFive[1].Except(_numbers[3]).Except(_numbers[4]).Any())
                {
                    _numbers[5] = possibleTwoThreeFive[1].OrderBy(p => p);
                    _numbers[2] = possibleTwoThreeFive[2].OrderBy(p => p);
                }
                else
                {
                    _numbers[5] = possibleTwoThreeFive[2].OrderBy(p => p);
                    _numbers[2] = possibleTwoThreeFive[1].OrderBy(p => p);
                }
            }
            else
            {
                var a2 = possibleTwoThreeFive[1].Except(possibleTwoThreeFive[0]).Except(possibleTwoThreeFive[2]);
                if (!a2.Any())
                {
                    _numbers[3] = possibleTwoThreeFive[1];
                    if (! possibleTwoThreeFive[0].Except(_numbers[3]).Except(_numbers[4]).Any())
                    {
                        _numbers[5] = possibleTwoThreeFive[0].OrderBy(p => p);
                        _numbers[2] = possibleTwoThreeFive[2].OrderBy(p => p);
                    }
                    else
                    {
                        _numbers[5] = possibleTwoThreeFive[2].OrderBy(p => p);
                        _numbers[2] = possibleTwoThreeFive[0].OrderBy(p => p);
                    }
                }
                else
                {
                    _numbers[3] = possibleTwoThreeFive[2].OrderBy(p => p);
                    if (! possibleTwoThreeFive[0].Except(_numbers[3]).Except(_numbers[4]).Any())
                    {
                        _numbers[5] = possibleTwoThreeFive[0].OrderBy(p => p);
                        _numbers[2] = possibleTwoThreeFive[1].OrderBy(p => p);
                    }
                    else
                    {
                        _numbers[5] = possibleTwoThreeFive[1].OrderBy(p => p);
                        _numbers[2] = possibleTwoThreeFive[0].OrderBy(p => p);
                    }
                }
            }
        }

        private void DeduceSegmentG() =>
            // 4.1) Tomo al 3 y le saco los segmentos del 7 y del 4, me queda el segmento GG
            _segments['g'] = _numbers[3].Except(_numbers[7]).Except(_numbers[4]).Single();

        private void DeduceSegmentE() =>
            // 4.2) Tomo al 2, le resto el 3 y obtengo el segmento EE
            _segments['e'] = _numbers[2].Except(_numbers[3]).Single();

        private void DeduceSegmentB() =>
            _segments['b'] = _numbers[5].Except(_numbers[3]).Single();

        private void DeduceSegmentC() =>
            _segments['c'] = _numbers[4].Except(_numbers[5]).Single();

        private void DeduceSegmentD() =>
            _segments['d'] = _numbers[4].Except(_numbers[1]).Except(new List<char>() { _segments['b'] }).Single();

        private void DeduceSegmentF() =>
            _segments['f'] = _numbers[1].Except(new List<char>() { _segments['c']}).Single();

        private void DeduceNumber0() =>
            _numbers[0] = new List<char> { _segments['a'], _segments['b'], _segments['c'], _segments['e'], _segments['f'], _segments['g'] }.OrderBy(p => p);

        private void DeduceNumber6() =>
            _numbers[6] = new List<char> { _segments['a'], _segments['b'], _segments['d'], _segments['e'], _segments['f'], _segments['g'] }.OrderBy(p => p);

        private void DeduceNumber9() =>
            _numbers[9] = new List<char> { _segments['a'], _segments['b'], _segments['c'], _segments['d'], _segments['f'], _segments['g'] }.OrderBy(p => p);
    }
}