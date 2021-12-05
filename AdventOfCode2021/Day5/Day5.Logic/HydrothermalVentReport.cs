using System.Linq;
using System.Collections.Generic;
using System;

namespace Day5.Logic
{
    public class HydrothermalVentReport
    {
        private readonly string _report;

        public int TotalPoints { get; private set; }

        public HydrothermalVentReport(string report)
        {
            if (string.IsNullOrWhiteSpace(report))
            {
                throw new ArgumentException("Invalid input");
            }

            _report = report;

            Parse();
        }

        private void Parse()
        {
            foreach (var line in _report.Split("\n"))
            {
                var initialPoint = line.Split("->")[0].Trim().Split(",").Select(p => int.Parse(p)).ToList();
                var endingPoint = line.Split("->")[1].Trim().Split(",").Select(p => int.Parse(p)).ToList();

                MakeLine(initialPoint, endingPoint);
            }
        }

        private void MakeLine(List<int> initialPoint, List<int> endingPoint)
        {
            if (initialPoint[0] == endingPoint[0])
            {
                TotalPoints += Math.Abs(endingPoint[1] - initialPoint[1]) + 1;
            }
            else
            {
                TotalPoints += Math.Abs(endingPoint[0] - initialPoint[0]) + 1;
            }
        }
    }
}
