using System;

namespace Day23.Logic
{
    public class AmphipodSorter
    {
        private readonly string _data;

        private readonly char[][] _map;

        public AmphipodSorter(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
            _map = new char[5][]
            {
                new char[13],
                new char[13],
                new char[13],
                new char[13],
                new char[13]
            };

            Parse();
        }

        private void Parse()
        {
            var y = 0;
            var x = 0;

            foreach (var line in _data.Split("\n"))
            {
                foreach (var room in line)
                {
                    _map[y][x++] = room;
                }

                x = 0;
                y++;
            }
        }

        public override string ToString()
        {
            var map = string.Empty;

            for (var y = 0; y < _map.Length; y++)
            {
                foreach (var x in _map[y])
                {
                    if (x == '\0')
                    {
                        break;
                    }

                    map += x;
                }

                map += "\n";
            }

            return map.Trim();
        }
    }
}
