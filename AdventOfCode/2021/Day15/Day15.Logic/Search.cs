namespace Day15.Logic
{
    public interface ISearch
    {
        void CalculateLowestRiskPathFor((int RiskLevel, int TotalRiskSoFar, bool Visited)[][] map);
        int MinimumRisk { get; }
    }

    public class OptimizedSearch : ISearch
    {
        private readonly IPriorityQueue _queue;
        private (int RiskLevel, int TotalRiskSoFar, bool Visited)[][] _map;
        private int _height;
        private int _width;
        private int _x;
        private int _y;

        public int MinimumRisk { get; private set; }

        public OptimizedSearch()
        {
             _queue = new DummyPriorityQueue();
             _map = Array.Empty<(int, int, bool)[]>();
        }

        public void CalculateLowestRiskPathFor((int RiskLevel, int TotalRiskSoFar, bool Visited)[][] map)
        {
            SetupInternalMapWith(map);

            while (GoalHasntBeenVisitedYet())
            {
                UpdateSouthNeighbour();
                UpdateEastNeighbour();
                UpdateNorthNeighbour();
                UpdateWestNeighbour();

                MarkCurrentLocationAsVisited();
                ChooseHighestPriorityLocation();
            }

            UpdateMinimumRisk();
        }

        private void SetupInternalMapWith((int RiskLevel, int TotalRiskSoFar, bool Visited)[][] map)
        {
            _map = map;
            _height = _map.Length;
            _width = _map[0].Length;
        }

        private void UpdateSouthNeighbour()
        {
            if (_y + 1 < _height) UpdateNeighbour(_x, _y + 1);
        }

        private void UpdateEastNeighbour()
        {
            if (_x + 1 < _width) UpdateNeighbour(_x + 1, _y);
        }

        private void UpdateNorthNeighbour()
        {
            if (_y - 1 > 0) UpdateNeighbour(_x, _y - 1);
        }

        private void UpdateWestNeighbour()
        {
            if (_x - 1 > 0) UpdateNeighbour(_x - 1, _y);
        }

        private void UpdateNeighbour(int neighbourX, int neighbourY)
        {
            if (!_map[neighbourY][neighbourX].Visited)
            {
                var totalRisk = _map[neighbourY][neighbourX].RiskLevel + _map[_y][_x].TotalRiskSoFar;
                if (_map[neighbourY][neighbourX].TotalRiskSoFar > totalRisk)
                {
                    _map[neighbourY][neighbourX].TotalRiskSoFar = totalRisk;
                    _queue.Insert(_map[neighbourY][neighbourX].TotalRiskSoFar, neighbourX, neighbourY);
                }
            }
        }

        private bool GoalHasntBeenVisitedYet() => !_map[_height - 1][_width - 1].Visited;

        private void MarkCurrentLocationAsVisited() => _map[_y][_x].Visited = true;

        private void ChooseHighestPriorityLocation()
        {
            if (_queue.Count > 0)
            {
                do
                {
                    (_, _x, _y) = _queue.Pull();
                }
                while (_map[_y][_x].Visited);
            }
        }

        private void UpdateMinimumRisk() => MinimumRisk = _map[_height - 1][_width - 1].TotalRiskSoFar;
    }
}