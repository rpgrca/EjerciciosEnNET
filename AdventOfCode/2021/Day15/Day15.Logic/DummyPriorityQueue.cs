using System.Collections.Generic;
using System.Linq;

namespace Day15.Logic
{
    public interface IPriorityQueue
    {
        void Insert(int totalRisk, int x, int y);
        int Count { get; }
        (int TotalRiskSoFar, int X, int Y) Pull();
    }

    public class DummyPriorityQueue : IPriorityQueue
    {
        private readonly List<(int TotalRiskSoFar, int X, int Y)> _list = new();

        public void Insert(int totalRisk, int x, int y)
        {
            int index;
            for (index = 0; index < _list.Count; index++)
            {
                if (totalRisk > _list[index].TotalRiskSoFar)
                {
                    break;
                }
            }

            _list.Insert(index, (totalRisk, x, y));
        }

        public int Count => _list.Count;

        public (int TotalRiskSoFar, int X, int Y) Pull()
        {
            var item = _list.Last();
            _list.Remove(item);
            return item;
        }
    }
}