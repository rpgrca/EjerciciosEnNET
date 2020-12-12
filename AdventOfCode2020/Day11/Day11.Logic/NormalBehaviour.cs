using System.Collections.Generic;

namespace AdventOfCode2020.Day11.Logic
{
    public class NormalBehaviour : IBehaviour
    {
        public int MaximumSurroundingOccupied { get; protected set; }

        public NormalBehaviour() =>
            MaximumSurroundingOccupied = 4;

        public char VerifySurroundingsOf(List<string> layout, int y, int x) =>
            layout[y][x] == 'L'
                ? ShouldSitDownHere(layout, y, x)? '#' : 'L'
                : ShouldLeaveSeat(layout, y, x)? 'L' : '#';

        private bool ShouldLeaveSeat(List<string> layout, int y, int x) =>
            CountSurroundingPlaces(layout, y, x, '#') >= MaximumSurroundingOccupied;

        private bool ShouldSitDownHere(List<string> layout, int y, int x) =>
            CountSurroundingPlaces(layout, y, x, '#') == 0;

        protected virtual int CountSurroundingPlaces(List<string> layout, int i, int j, char v)
        {
            var count = 0;

            if (i > 0 && j > 0 && layout[i-1][j-1] == v) // up left
            {
                count++;
            }
            if (i > 0 && layout[i-1][j] == v) // up
            {
                count++;
            }
            if (i > 0 && j < layout[i].Length - 1 && layout[i-1][j+1] == v) // up right
            {
                count++;
            }
            if (j > 0 && layout[i][j-1] == v) // left
            {
                count++;
            }
            if (j < layout[i].Length - 1 && layout[i][j+1] == v) // right
            {
                count++;
            }
            if (i < layout.Count - 1 && j > 0 && layout[i+1][j-1] == v) // down left
            {
                count++;
            }
            if (SouthFromHereIs(layout, i, j, v))
            {
                count++;
            }
            if (i < layout.Count - 1 && j < layout[i].Length - 1 && layout[i+1][j+1] == v) // down right
            {
                count++;
            }

            return count;
        }

        private static bool SouthFromHereIs(List<string> layout, int i, int j, char v) =>
            i < layout.Count - 1 && layout[i + 1][j] == v;
    }
}