using System.Linq;
using System.Collections.Generic;
using System;

namespace Day5.Logic
{
    public class HydrothermalVentReport
    {
        private readonly string _report;
        private readonly Dictionary<(int X, int Y), int> _points;

        public HydrothermalVentReport(string report, bool withDiagonals = false)
        {
            if (string.IsNullOrWhiteSpace(report))
            {
                throw new ArgumentException("Invalid input");
            }

            _report = report;
            _points = new Dictionary<(int X, int Y), int>();

            Parse(withDiagonals);
        }

        private void Parse(bool withDiagonals)
        {
            foreach (var line in _report.Split("\n"))
            {
                var initialPoint = line.Split("->")[0].Trim().Split(",").Select(p => int.Parse(p)).ToList();
                var endingPoint = line.Split("->")[1].Trim().Split(",").Select(p => int.Parse(p)).ToList();

                if (initialPoint[0] == endingPoint[0])
                {
                    MakeVerticalLine(initialPoint, endingPoint);
                }
                else if (initialPoint[1] == endingPoint[1])
                {
                    MakeHorizontalLine(initialPoint, endingPoint);
                }
                else if (withDiagonals)
                {
                    if (Math.Abs(endingPoint[0] - initialPoint[0]) == Math.Abs(endingPoint[1] - initialPoint[1]))
                    {
                        MakeDiagonalLine(initialPoint, endingPoint);
                    }
                }
            }
        }

        private void MakeVerticalLine(List<int> initialPoint, List<int> endingPoint)
        {
            if (initialPoint[1] <= endingPoint[1])
            {
                for (var y = initialPoint[1]; y <= endingPoint[1]; y++)
                {
                    if (!_points.ContainsKey((initialPoint[0], y)))
                    {
                        _points.Add((initialPoint[0], y), 0);
                    }

                    _points[(initialPoint[0], y)]++;
                }
            }
            else
            {
                for (var y = endingPoint[1]; y <= initialPoint[1]; y++)
                {
                    if (!_points.ContainsKey((initialPoint[0], y)))
                    {
                        _points.Add((initialPoint[0], y), 0);
                    }

                    _points[(initialPoint[0], y)]++;
                }
            }
        }

        private void MakeHorizontalLine(List<int> initialPoint, List<int> endingPoint)
        {
            if (initialPoint[0] <= endingPoint[0])
            {
                for (var x = initialPoint[0]; x <= endingPoint[0]; x++)
                {
                    if (!_points.ContainsKey((x, initialPoint[1])))
                    {
                        _points.Add((x, initialPoint[1]), 0);
                    }

                    _points[(x, initialPoint[1])]++;
                }
            }
            else
            {
                for (var x = endingPoint[0]; x <= initialPoint[0]; x++)
                {
                    if (!_points.ContainsKey((x, initialPoint[1])))
                    {
                        _points.Add((x, initialPoint[1]), 0);
                    }

                    _points[(x, initialPoint[1])]++;
                }
            }
        }

        private void MakeDiagonalLine(List<int> initialPoint, List<int> endingPoint)
        {
            int x;
            int y;
            if (initialPoint[0] <= endingPoint[0])
            {
                if (initialPoint[1] <= endingPoint[1])
                {
                    // 0,0 -> 8,8
                    for (x = initialPoint[0], y = initialPoint[1]; x <= endingPoint[0] && y <= endingPoint[1]; x++, y++)
                    {
                        if (!_points.ContainsKey((x, y)))
                        {
                            _points.Add((x, y), 0);
                        }

                        _points[(x, y)]++;
                    }
                }
                else
                {
                    // 5,5 -> 8,2
                    for (x = initialPoint[0], y = initialPoint[1]; x <= endingPoint[0] && y >= endingPoint[1]; x++, y--)
                    {
                        if (!_points.ContainsKey((x, y)))
                        {
                            _points.Add((x, y), 0);
                        }

                        _points[(x, y)]++;
                    }
                }
            }
            else
            {
                if (initialPoint[1] <= endingPoint[1])
                {
                    // 8,0 -> 0,8
                    for (x = initialPoint[0], y = initialPoint[1]; x >= endingPoint[0] && y <= endingPoint[1]; x--, y++)
                    {
                        if (!_points.ContainsKey((x, y)))
                        {
                            _points.Add((x, y), 0);
                        }

                        _points[(x, y)]++;
                    }
                }
                else
                {
                    for (x = initialPoint[0], y = initialPoint[1]; x >= endingPoint[0] && y >= endingPoint[1]; x--, y--)
                    {
                        if (!_points.ContainsKey((x, y)))
                        {
                            _points.Add((x, y), 0);
                        }

                        _points[(x, y)]++;
                    }
                }
            }
        }

        public int CalculateOverlappingPoints() => _points.Where(p => p.Value > 1).Select(p => p.Value).Count();
    }
}