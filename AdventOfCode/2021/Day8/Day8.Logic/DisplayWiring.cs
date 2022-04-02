using System.Linq;
using System.Collections.Generic;

namespace Day8.Logic
{
    public class DisplayWiring
    {
        private readonly List<string> _signals;
        private readonly List<string> _display;
        private readonly List<uint> _numbers;
        private readonly Dictionary<char, uint> _segments;

        public int Value { get; private set; }

        public DisplayWiring(List<string> signals, List<string> display)
        {
            _signals = signals;
            _display = display;

            _numbers = new List<uint>();
            _segments = new Dictionary<char, uint>
            {
                { 'a', 0 },
                { 'b', 0 },
                { 'c', 0 },
                { 'd', 0 },
                { 'e', 0 },
                { 'f', 0 },
                { 'g', 0 }
            };

            ClassifyNumbers();
            CalculateWirings();
        }

        private void ClassifyNumbers() =>
            _numbers.AddRange(new List<uint>
            {
                { 0 },
                { StringToByte(_signals.Single(p => p.Length == 2)) },
                { 0 },
                { 0 },
                { StringToByte(_signals.Single(p => p.Length == 4)) },
                { 0 },
                { 0 },
                { StringToByte(_signals.Single(p => p.Length == 3)) },
                { StringToByte(_signals.Single(p => p.Length == 7)) },
                { 0 }
            });

        private uint StringToByte(string value) => value.Aggregate(0U, (t, i) => t |= 1U << (i - 'a'));

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

            var fixedNumbers = new Dictionary<uint, string>
            {
                { _numbers[0], "0" },
                { _numbers[1], "1" },
                { _numbers[2], "2" },
                { _numbers[3], "3" },
                { _numbers[4], "4" },
                { _numbers[5], "5" },
                { _numbers[6], "6" },
                { _numbers[7], "7" },
                { _numbers[8], "8" },
                { _numbers[9], "9" }
            };

            Value = int.Parse(string.Concat(_display.Select(p => fixedNumbers[StringToByte(p)])));
        }

        private void DeduceSegmentA() =>
            // 2) Si comparo el 7 con el 1, el segmento en el 7 que no está en el 1 es el segmento AA
            _segments['a'] = _numbers[7] ^ _numbers[1];

        private void DeduceNumbersTwoThreeAndFive()
        {
            // 4) Tomo los numeros con 5 segmentos (2, 3, 5), a cada uno le quito los segmentos existentes en los
            // otros y el que queda vacío es el 3
            var possibleTwoThreeFive = _signals.Where(p => p.Length == 5).Select(p => StringToByte(p)).ToList();
            var a1 = possibleTwoThreeFive[0] & ~possibleTwoThreeFive[1] & ~possibleTwoThreeFive[2];
            if (a1 == 0)
            {
                _numbers[3] = possibleTwoThreeFive[0];
                if ((possibleTwoThreeFive[1] & ~_numbers[3] & ~_numbers[4]) == 0)
                {
                    _numbers[5] = possibleTwoThreeFive[1];
                    _numbers[2] = possibleTwoThreeFive[2];
                }
                else
                {
                    _numbers[5] = possibleTwoThreeFive[2];
                    _numbers[2] = possibleTwoThreeFive[1];
                }
            }
            else
            {
                var a2 = possibleTwoThreeFive[1] & ~possibleTwoThreeFive[0] & ~possibleTwoThreeFive[2];
                if (a2 == 0)
                {
                    _numbers[3] = possibleTwoThreeFive[1];
                    if ((possibleTwoThreeFive[0] & ~_numbers[3] & ~_numbers[4]) == 0)
                    {
                        _numbers[5] = possibleTwoThreeFive[0];
                        _numbers[2] = possibleTwoThreeFive[2];
                    }
                    else
                    {
                        _numbers[5] = possibleTwoThreeFive[2];
                        _numbers[2] = possibleTwoThreeFive[0];
                    }
                }
                else
                {
                    _numbers[3] = possibleTwoThreeFive[2];
                    if ((possibleTwoThreeFive[0] & ~_numbers[3] & ~_numbers[4]) == 0)
                    {
                        _numbers[5] = possibleTwoThreeFive[0];
                        _numbers[2] = possibleTwoThreeFive[1];
                    }
                    else
                    {
                        _numbers[5] = possibleTwoThreeFive[1];
                        _numbers[2] = possibleTwoThreeFive[0];
                    }
                }
            }
        }

        private void DeduceSegmentG() =>
            // 4.1) Tomo al 3 y le saco los segmentos del 7 y del 4, me queda el segmento GG
            _segments['g'] = _numbers[3] & ~_numbers[7] & ~_numbers[4];

        private void DeduceSegmentE() =>
            // 4.2) Tomo al 2, le resto el 3 y obtengo el segmento EE
            _segments['e'] = _numbers[2] & ~_numbers[3];

        private void DeduceSegmentB() =>
            _segments['b'] = _numbers[5] & ~_numbers[3];

        private void DeduceSegmentC() =>
            _segments['c'] = _numbers[4] & ~_numbers[5];

        private void DeduceSegmentD() =>
            _segments['d'] = _numbers[4] & ~_numbers[1] & ~_segments['b'];

        private void DeduceSegmentF() =>
            _segments['f'] = _numbers[1] & ~_segments['c'];

        private void DeduceNumber0() =>
            _numbers[0] = _segments['a'] | _segments['b'] | _segments['c'] | _segments['e'] | _segments['f'] | _segments['g'];

        private void DeduceNumber6() =>
            _numbers[6] = _segments['a'] | _segments['b'] | _segments['d'] | _segments['e'] | _segments['f'] | _segments['g'];

        private void DeduceNumber9() =>
            _numbers[9] = _segments['a'] | _segments['b'] | _segments['c'] | _segments['d'] | _segments['f'] | _segments['g'];

        public List<char> Wiring =>
            _segments.Select(p => (char)('a' + System.Numerics.BitOperations.Log2((uint)p.Value))).ToList();
    }
}