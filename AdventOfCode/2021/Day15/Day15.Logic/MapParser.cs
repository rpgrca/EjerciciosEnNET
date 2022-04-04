using System.Linq;

namespace Day15.Logic
{
    public interface IMapParser
    {
        void Parse(string input);
        (int RiskLevel, int TotalRiskSoFar, bool Visited)[][] Map { get; }
    }

    public class StandardParser : IMapParser
    {
        private (int RiskLevel, int TotalRiskSoFar, bool Visited)[][] _map;

        public (int RiskLevel, int TotalRiskSoFar, bool Visited)[][] Map => _map;

        public StandardParser()
        {
            _map = Array.Empty<(int, int, bool)[]>();
        }

        public void Parse(string input)
        {
            var lines = input.Split("\n");
            var index = 0;

            _map = new (int, int, bool)[lines.Length][];
            foreach (var line in lines)
            {
                _map[index++] = line.Select(p => (p - '0', int.MaxValue, false)).ToArray();
            }
        }
    }

    public class BigMapParser : IMapParser
    {
        public (int RiskLevel, int TotalRiskSoFar, bool Visited)[][] Map { get; private set; }

        public BigMapParser() => Map = Array.Empty<(int, int, bool)[]>();

        public void Parse(string input)
        {
            var lines = input.Split("\n");
            var index = 0;

            Map = new (int, int, bool)[lines.Length * 5][];
            foreach (var line in lines)
            {
                var convertedLine = line.Select(p => (p - '0', int.MaxValue, false)).ToList();
                convertedLine.AddRange(line.Select(p => (p - '0' + 1, int.MaxValue, false)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 2, int.MaxValue, false)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 3, int.MaxValue, false)));
                convertedLine.AddRange(line.Select(p => (p - '0' + 4, int.MaxValue, false)));

                Map[index++] = convertedLine.ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                Map[index++] = Map[y].Select(p => (p.RiskLevel + 1, p.TotalRiskSoFar, false)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                Map[index++] = Map[y].Select(p => (p.RiskLevel + 2, p.TotalRiskSoFar, false)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                Map[index++] = Map[y].Select(p => (p.RiskLevel + 3, p.TotalRiskSoFar, false)).ToArray();
            }

            for (var y = 0; y < lines.Length; y++)
            {
                Map[index++] = Map[y].Select(p => (p.RiskLevel + 4, p.TotalRiskSoFar, false)).ToArray();
            }

            for (var y = 0; y < Map.Length; y++)
            {
                for (var x = 0; x < Map[0].Length; x++)
                {
                    if (Map[y][x].RiskLevel > 9)
                    {
                        Map[y][x].RiskLevel -= 9;
                    }
                }
            }
        }

        public string GetHorizontalLine(int index) =>
            Map[index].Aggregate(string.Empty, (t, i) => t += i.RiskLevel);

        public string GetVerticalLine(int index)
        {
            var result = string.Empty;
            for (var y = 0; y < Map.Length; y++)
            {
                result += Map[y][index].RiskLevel;
            }

            return result;
        }
    }
}