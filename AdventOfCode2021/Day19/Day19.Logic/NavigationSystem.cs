using System.Linq;
using System;
using System.Collections.Generic;

namespace Day19.Logic
{
    public class NavigationSystem
    {
        private readonly string _data;

        public List<Scanner> Scanners { get; set; }

        public NavigationSystem(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            Scanners = new List<Scanner>();

            Parse();
        }

        private void Parse()
        {
            var scannerData = string.Empty;

            foreach (var line in _data.Split("\n"))
            {
                if (! string.IsNullOrEmpty(line))
                {
                    scannerData += line + "\n";
                }
                else
                {
                    Scanners.Add(new Scanner(scannerData.Trim()));
                    scannerData = string.Empty;
                }
            }
        }
    }
}