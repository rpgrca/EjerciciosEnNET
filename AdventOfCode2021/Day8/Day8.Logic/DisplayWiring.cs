using System;
using System.Linq;
using System.Collections.Generic;

namespace Day8.Logic
{
    public class DisplayWiring
    {
        private readonly string _data;
        private List<(List<string> Signals, List<string> Display)> _scannings;

        public DisplayWiring(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid wiring");
            }

            _data = data;
            Parse();
        }

        private void Parse()
        {
            _scannings = _data.Split("\n").Select(p => p.Split("|")).Select(p => (p[0].Split(" ").ToList(), p[1].Split(" ").ToList())).ToList();
        }

        public int TotalScannings => _scannings.Count;
    }
}
