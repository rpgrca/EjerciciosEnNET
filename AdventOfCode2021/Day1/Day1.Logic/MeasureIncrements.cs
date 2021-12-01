using System.Linq;

namespace Day1.Logic
{
    public class MeasureIncrements
    {
        private readonly int[] _depths;

        public int Increments { get; }

        public MeasureIncrements(string depths, int windowSize)
        {
            _depths = depths.Split("\n").Select(p => int.Parse(p)).ToArray();
            Increments = CountSlidingWindowIncrements(windowSize);
        }

        private int CountSlidingWindowIncrements(int measure)
        {
            var previousValue = int.MaxValue;
            var counter = 0;

            for (var index = 0; index < _depths.Length - (measure - 1); index++)
            {
                var currentValue = _depths[index..(index+measure)].Sum();
                if (currentValue > previousValue)
                {
                    counter++;
                }

                previousValue = currentValue;
            }

            return counter;
        }
    }
}