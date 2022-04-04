using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day11.Logic
{
    public class WaitingArea
    {
        private List<string> _layout;
        public string Layout { get; private set; }
        public int OccupiedSeats => Layout.Count(p => p == '#');

        public WaitingArea(string layout) =>
            (_layout, Layout) = (new List<string>(layout.Split("\n")), string.Empty);

        public void AddPassengersWith(IBehaviour passenger)
        {
            var layout = new List<string>();

            for (var y = 0; y < _layout.Count; y++)
            {
                var value = string.Empty;

                for (var x = 0; x < _layout[y].Length; x++)
                {
                    value += _layout[y][x] == '.'
                        ? '.'
                        : passenger.VerifySurroundingsOf(_layout, y, x);
                }

                layout.Add(value);
            }

            _layout = layout;
            UpdateLayout();
        }

        private void UpdateLayout() =>
            Layout = string.Join("\n", _layout);

        public void UntilNothingChangesAddPassengersWith(IBehaviour behaviour)
        {
            string previousData;

            do
            {
                previousData = Layout;
                AddPassengersWith(behaviour);
            }
            while (Layout != previousData);
        }
    }
}