using System.Linq;
using System.Collections.Generic;
using System;

namespace Day5.Logic
{
    public sealed class HydrothermalVentReport
    {
        private readonly string _report;
        private readonly Dictionary<(int X, int Y), int> _points;
        private readonly Func<(int X, int Y), (int X, int Y), Action<(int X, int Y)>, TwoDimensionalSegment> _segmentBuilder;

        public static HydrothermalVentReport CreateReportNotSupportingDiagonals(string report) =>
            new(report, (s, e, c) =>
                TwoDimensionalSegment
                    .Director
                    .ConfigureForHorizontalAndVerticalTracing(new TwoDimensionalSegment.Builder())
                    .StartingFrom(s)
                    .Until(e)
                    .CallingInEveryStep(c)
                    .Build()
            );

        public static HydrothermalVentReport CreateReportSupportingDiagonals(string report) =>
            new(report, (s, e, c) =>
                TwoDimensionalSegment
                    .Director
                    .ConfigureForHorizontalVerticalAndDiagonalTracing(new TwoDimensionalSegment.Builder())
                    .StartingFrom(s)
                    .Until(e)
                    .CallingInEveryStep(c)
                    .Build()
            );

        private HydrothermalVentReport(string report, Func<(int X, int Y), (int X, int Y), Action<(int X, int Y)>, TwoDimensionalSegment> segmentBuilder)
        {
            if (string.IsNullOrWhiteSpace(report))
            {
                throw new ArgumentException("Invalid input");
            }

            _report = report;
            _segmentBuilder = segmentBuilder;
            _points = new Dictionary<(int X, int Y), int>();

            Parse();
        }

        private void Parse()
        {
            foreach (var line in _report.Split("\n"))
            {
                var points = line.Split("->").Select(p => p.Split(",")).Select(p => (int.Parse(p[0]), int.Parse(p[1]))).ToList();
                _segmentBuilder(points[0], points[1], p =>
                {
                    _points.TryAdd(p, 0);
                    _points[p]++;
                }).Trace();
            }
        }

        public int CalculateAmountOfOverlappingPoints() => _points.Where(p => p.Value > 1).Select(p => p.Value).Count();
    }
}