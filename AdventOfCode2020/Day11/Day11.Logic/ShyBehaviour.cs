using System.Collections.Generic;

namespace AdventOfCode2020.Day11.Logic
{
    public class ShyBehaviour : NormalBehaviour
    {
        public ShyBehaviour() =>
            MaximumSurroundingOccupied = 5;

        protected override int CountSurroundingPlaces(List<string> layout, int i, int j, char v)
        {
             var count = 0;

            // up left
            var horizontal = i;
            var vertical = j;
            while (horizontal > 0 && vertical > 0 && layout[horizontal-1][vertical-1] == '.')
            {
                horizontal--; vertical--;
            }
            if (horizontal > 0 && vertical > 0 && layout[horizontal-1][vertical-1] == v)
            {
                count++;
            }

            // up
            horizontal = i;
            vertical = j;
            while (horizontal > 0 && layout[horizontal-1][vertical] == '.')
            {
                horizontal--;
            }
            if (horizontal > 0 && layout[horizontal-1][vertical] == v)
            {
                count++;
            }

            // up right
            horizontal = i;
            vertical = j;
            while (horizontal > 0 && vertical < layout[horizontal].Length - 1 && layout[horizontal-1][vertical+1] == '.')
            {
                horizontal--;
                vertical++;
            }
            if (horizontal > 0 && vertical < layout[horizontal].Length - 1 && layout[horizontal-1][vertical+1] == v)
            {
                count++;
            }

            // left
            horizontal = i;
            vertical = j;
            while (vertical > 0 && layout[horizontal][vertical-1] == '.')
            {
                vertical--;
            }
            if (vertical > 0 && layout[horizontal][vertical-1] == v)
            {
                count++;
            }

            // right
            horizontal = i;
            vertical = j;
            while (vertical < layout[horizontal].Length - 1 && layout[horizontal][vertical+1] == '.')
            {
                vertical++;
            }
            if (vertical < layout[horizontal].Length - 1 && layout[horizontal][vertical+1] == v)
            {
                count++;
            }

            // down left
            horizontal = i;
            vertical = j;
            while (horizontal < layout.Count - 1 && vertical > 0 && layout[horizontal+1][vertical-1] == '.')
            {
                horizontal++;
                vertical--;
            }
            if (horizontal < layout.Count - 1 && vertical > 0 && layout[horizontal+1][vertical-1] == v)
            {
                count++;
            }

            // down
            horizontal = i;
            vertical = j;
            while(horizontal < layout.Count - 1 && layout[horizontal+1][vertical] == '.')
            {
                horizontal++;
            }
            if (horizontal < layout.Count - 1 && layout[horizontal+1][vertical] == v)
            {
                count++;
            }

            // down right
            horizontal = i;
            vertical = j;
            while (horizontal < layout.Count - 1 && vertical < layout[horizontal].Length - 1 && layout[horizontal+1][vertical+1] == '.')
            {
                horizontal++;
                vertical++;
            }
            if (horizontal < layout.Count - 1 && vertical < layout[horizontal].Length - 1 && layout[horizontal+1][vertical+1] == v)
            {
                count++;
            }

            return count;
        }
    }
}