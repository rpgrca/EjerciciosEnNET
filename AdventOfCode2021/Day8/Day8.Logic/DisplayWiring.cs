using System;
using System.Linq;
using System.Collections.Generic;

namespace Day8.Logic
{
    public class DisplayWiring
    {
        private readonly string _data;
        private List<(List<string> Signals, List<string> Display)> _scannings;

        public int TotalScannings => _scannings.Count;
        public int DigitsWithUniqueNumberOfSegments { get; private set; }

        public DisplayWiring(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid wiring");
            }

            _data = data;
            Parse();
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
    }
}
