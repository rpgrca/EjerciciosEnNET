using System;

namespace Day15.Logic
{
    public sealed class CaveMap
    {
        private readonly string _input;
        private readonly (int RiskLevel, int TotalRiskSoFar, bool Visited)[][] _map;
        private readonly ISearch _search;
        private int _minimumRisk;

        public int Width { get; }
        public int Height { get; }

        public static CaveMap CreateWithStandardMapperAndOptimizedSearch(string input) => new(input, new StandardParser(), new OptimizedSearch());

        public static CaveMap CreateWithBigMapperAndOptimizedSearch(string input) => new(input, new BigMapParser(), new OptimizedSearch());

        private CaveMap(string input, IMapParser parser, ISearch search)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid map");
            }

            _input = input;
            _search = search;

            parser.Parse(_input);
            _map = parser.Map;
            Height = _map.Length;
            Width = _map[0].Length;

            CalculatePath();
        }

        private void CalculatePath()
        {
            _map[0][0].TotalRiskSoFar = 0;
            _search.CalculateLowestRiskPathFor(_map);
            _minimumRisk = _search.MinimumRisk;
        }

        public int GetPathLevel() => _minimumRisk;
    }
}