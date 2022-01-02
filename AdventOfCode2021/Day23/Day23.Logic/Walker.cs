using System;

namespace Day23.Logic
{
    public class Walker
    {
        private readonly string _map;

        public Walker(string map) =>
            _map = map;

        public int LowestTotalCost { get; internal set; } = int.MaxValue;

        public void Run()
        {
            var amphipodSorter = new AmphipodSorter2(_map);
            amphipodSorter.OnFinalPositionReached((s, c) =>
            {
                if (s.TotalCost < LowestTotalCost)
                {
                    LowestTotalCost = s.TotalCost;
                    Console.WriteLine($"Found new lowest cost of {LowestTotalCost} on step {c}");
                }
            });

            var amphipodes = amphipodSorter.GetAmphipods();
            amphipodSorter.WalkWith(amphipodes, new System.Collections.Generic.List<(int From, int To)>());
        }
    }
}