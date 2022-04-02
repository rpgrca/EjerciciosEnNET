using System;

namespace Day23.Logic
{
    public class Walker
    {
        private readonly Func<AmphipodSorter2> _callback;

        public static Walker CreateWithLongMapSupport(string map) => new(() => AmphipodSorter2.CreateLongMapSorter(map));

        public static Walker CreateWithShortMapSupport(string map) => new(() => AmphipodSorter2.CreateShortMapSorter(map));

        private Walker(Func<AmphipodSorter2> callback) =>
            _callback = callback;

        public int LowestTotalCost { get; internal set; } = int.MaxValue;

        public void Run()
        {
            var amphipodSorter = _callback();
            amphipodSorter.OnFinalPositionReached((s, i) =>
            {
                if (s.TotalCost < LowestTotalCost)
                {
                    LowestTotalCost = s.TotalCost;
                    Console.WriteLine($"Path found on {i}: {LowestTotalCost}");
                    //System.IO.File.AppendAllText("shortmap.txt", $"\n\nShortest path found at {LowestTotalCost}\n\n");
                }
            });

            var amphipodes = amphipodSorter.GetAmphipods();
            amphipodSorter.WalkWith(amphipodes, new System.Collections.Generic.List<(int From, int To)>());

            if (LowestTotalCost == int.MaxValue)
            {
                LowestTotalCost = 0;
            }
        }
    }
}