using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day11.Logic
{
    public class WaitingArea
    {
        private List<string> _layout;

        public WaitingArea(string layout)
        {
            _layout = new List<string>(layout.Replace("\r", string.Empty).Split("\n"));
        }

        public string Layout { get; private set; }
        public int OccupiedSeats { get { return Layout.Count(p => p == '#'); } }

        public void AddPassengers()
        {
            var layout = new List<string>();

            for (var i = 0; i < _layout.Count; i++)
            {
                var value = "";

                for (var j = 0; j < _layout[i].Length; j++)
                {
                    switch (_layout[i][j])
                    {
                        case '.':
                            value += '.';
                            break;

                        case 'L':
                            if (CountSurroundingPlaces(i, j, '#') == 0)
                            {
                                value += '#';
                            }
                            else
                            {
                                value += 'L';
                            }
                            break;

                        case '#':
                            if (CountSurroundingPlaces(i, j, '#') >= 4)
                            {
                                value += 'L';
                            }
                            else
                            {
                                value += '#';
                            }
                            break;
                    }
                }

                layout.Add(value);
            }

            _layout = layout;
            Layout = string.Join("\n", layout);
        }

        public int CountSurroundingPlaces(int i, int j, char v)
        {
            var count = 0;

            if (i > 0 && j > 0 && _layout[i-1][j-1] == v) // up left
            {
                count++;
            }
            if (i > 0 && _layout[i-1][j] == v) // up
            {
                count++;
            }
            if (i > 0 && j < _layout[i].Length - 1 && _layout[i-1][j+1] == v) // up right
            {
                count++;
            }
            if (j > 0 && _layout[i][j-1] == v) // left
            {
                count++;
            }
            if (j < _layout[i].Length - 1 && _layout[i][j+1] == v) // right
            {
                count++;
            }
            if (i < _layout.Count - 1 && j > 0 && _layout[i+1][j-1] == v) // down left
            {
                count++;
            }
            if (i < _layout.Count - 1 && _layout[i+1][j] == v) // down
            {
                count++;
            }
            if (i < _layout.Count - 1 && j < _layout[i].Length - 1 && _layout[i+1][j+1] == v) // down right
            {
                count++;
            }

            return count;
        }

        public void AddPassengersWithLongDistanceRange()
        {
            var layout = new List<string>();

            for (var i = 0; i < _layout.Count; i++)
            {
                var value = "";

                for (var j = 0; j < _layout[i].Length; j++)
                {
                    switch (_layout[i][j])
                    {
                        case '.':
                            value += '.';
                            break;

                        case 'L':
                            if (CountSurroundingPlacesAtLongDistance(i, j, '#') == 0)
                            {
                                value += '#';
                            }
                            else
                            {
                                value += 'L';
                            }
                            break;

                        case '#':
                            if (CountSurroundingPlacesAtLongDistance(i, j, '#') >= 5)
                            {
                                value += 'L';
                            }
                            else
                            {
                                value += '#';
                            }
                            break;
                    }
                }

                layout.Add(value);
            }

            _layout = layout;
            Layout = string.Join("\n", layout);
        }

        public int CountSurroundingPlacesAtLongDistance(int i1, int j1, char v)
        {
             var count = 0;

            // up left
            var i = i1;
            var j = j1;
            while (i > 0 && j > 0 && _layout[i-1][j-1] == '.')
            {
                i--; j--;
            }
            if (i > 0 && j > 0 && _layout[i-1][j-1] == v)
            {
                count++;
            }

            // up
            i = i1;
            j = j1;
            while (i > 0 && _layout[i-1][j] == '.')
            {
                i--;
            }
            if (i > 0 && _layout[i-1][j] == v)
            {
                count++;
            }

            // up right
            i = i1;
            j = j1;
            while (i > 0 && j < _layout[i].Length - 1 && _layout[i-1][j+1] == '.')
            {
                i--;
                j++;
            }
            if (i > 0 && j < _layout[i].Length - 1 && _layout[i-1][j+1] == v)
            {
                count++;
            }

            // left
            i = i1;
            j = j1;
            while (j > 0 && _layout[i][j-1] == '.')
            {
                j--;
            }
            if (j > 0 && _layout[i][j-1] == v)
            {
                count++;
            }

            // right
            i = i1;
            j = j1;
            while (j < _layout[i].Length - 1 && _layout[i][j+1] == '.')
            {
                j++;
            }
            if (j < _layout[i].Length - 1 && _layout[i][j+1] == v)
            {
                count++;
            }

            // down left
            i = i1;
            j = j1;
            while (i < _layout.Count - 1 && j > 0 && _layout[i+1][j-1] == '.')
            {
                i++;
                j--;
            }
            if (i < _layout.Count - 1 && j > 0 && _layout[i+1][j-1] == v)
            {
                count++;
            }

            // down
            i = i1;
            j = j1;
            while(i < _layout.Count - 1 && _layout[i+1][j] == '.')
            {
                i++;
            }
            if (i < _layout.Count - 1 && _layout[i+1][j] == v)
            {
                count++;
            }

            // down right
            i = i1;
            j = j1;
            while (i < _layout.Count - 1 && j < _layout[i].Length - 1 && _layout[i+1][j+1] == '.')
            {
                i++;
                j++;
            }
            if (i < _layout.Count - 1 && j < _layout[i].Length - 1 && _layout[i+1][j+1] == v)
            {
                count++;
            }

            return count;
        }
    }
}