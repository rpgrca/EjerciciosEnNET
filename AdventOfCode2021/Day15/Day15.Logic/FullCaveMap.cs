using System.Linq;

namespace Day15.Logic
{
    public class FullCaveMap : CaveMap
    {
        public FullCaveMap(string input) : base(input, new OptimizedSearch())
        {
        }

        protected override void Parse()
        {
            var lines = _input.Split("\n");
            var index = 0;

            _map = new (int, int, bool)[lines.Length * 5][];
            foreach (var line in lines)
            {
                var convertedLine = line.Select(p => (p - '0', int.MaxValue, false)).ToList();
                convertedLine.AddRange(line.Select(p => (p - '0' + 1, int.MaxValue, false)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 2, int.MaxValue, false)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 3, int.MaxValue, false)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 4, int.MaxValue, false)));

                _map[index++] = convertedLine.ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 1, p.TotalRiskSoFar, false)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 2, p.TotalRiskSoFar, false)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 3, p.TotalRiskSoFar, false)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                _map[index++] = _map[y].Select(p => (p.RiskLevel + 4, p.TotalRiskSoFar, false)).ToArray();
            }

            Height = _map.Length;
            Width = _map[0].Length;

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    if (_map[y][x].RiskLevel > 9)
                    {
                        _map[y][x].RiskLevel -= 9;
                    }
                }
            }
        }

        public string GetHorizontalLine(int index) =>
            _map[index].Aggregate(string.Empty, (t, i) => t += i.RiskLevel);

        public string GetVerticalLine(int index)
        {
            var result = string.Empty;
            for (var y = 0; y < Height; y++)
            {
                result += _map[y][index].RiskLevel;
            }

            return result;
        }
    }
}