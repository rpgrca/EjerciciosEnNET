using System;
using System.Linq;
using System.Collections.Generic;

namespace Day8.Logic
{
    public class SubmarineDisplays
    {
        private readonly string _data;
        private List<(List<string> Signals, List<string> Display)> _scannings;
        private readonly List<DisplayWiring> _displays;

        public int TotalScannings => _scannings.Count;
        public int DigitsWithUniqueNumberOfSegments { get; private set; }

        public SubmarineDisplays(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid wiring");
            }

            _data = data;
            _displays = new List<DisplayWiring>();

            Parse();
            BuildDisplays();
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

        private void BuildDisplays() =>
            _displays.AddRange(_scannings.Select(p => new DisplayWiring(p.Signals, p.Display)));

        private void CountDigitsWithUniqueNumberOfSegments() =>
            DigitsWithUniqueNumberOfSegments = _scannings
                .Select(p => p.Display)
                .Select(p => p.Count(x => x.Length == 2 || x.Length == 4 || x.Length == 3 || x.Length == 7))
                .Sum();

        public List<string> GetDisplayFor(int index)
        {
            return _scannings[index].Display;
        }

        public int GetFixedDisplayFor(int index)
        {
            return _displays[index].Value;
        }

        public int GetSumOfDisplays()
        {
            return _displays.Sum(p => p.Value);
        }

        public List<char> GetWiringForDisplay(int index)
        {
            return _displays[index].Wiring;
        }
    }
}