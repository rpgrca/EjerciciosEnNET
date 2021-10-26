using System;

namespace MarsRover.Logic
{
    public class MarsRover
    {
        private char _direction;
        private int _x;
        private int _y;
        private readonly int [,] _map;

        public MarsRover(char direction, int x, int y, int [,] map)
        {
            if (direction == 'N' || direction == 'S' || direction == 'E' || direction == 'W')
            {
                _direction = direction;
            }
            else
            {
                throw new Exception("Invalid command");
            }

            if (map is null || map.GetLength(0) != 10 || map.GetLength(1) != 10)
            {
                throw new Exception("Invalid map");
            }
            _map = map;

            if (x < 0 || x >= _map.GetLength(0) || y < 0 || y >= _map.GetLength(1)) throw new Exception("Invalid coordinate");
            _x = x;
            _y = y;
        }

        public char GetDirection() => _direction;

        public int GetX() => _x;

        public int GetY() => _y;

        public void SendCommand(string commands)
        {
            int newX = GetX(), newY = GetY();

            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'F':
                        switch (_direction)
                        {
                            case 'N': newY = _y == _map.GetLength(1) - 1? 0 : _y + 1; break;
                            case 'W': newX = _x == 0? _map.GetLength(0) - 1 : _x - 1; break;
                            case 'S': newY = _y == 0? _map.GetLength(1) - 1 : _y - 1; break;
                            case 'E': newX = _x == _map.GetLength(0) - 1? 0 : _x + 1; break;
                        }
                       break;

                    case 'B':
                        switch (_direction)
                        {
                            case 'N': newY = _y == 0? _map.GetLength(1) - 1 : _y - 1; break;
                            case 'W': newX = _x == _map.GetLength(0) - 1? 0 : _x + 1; break;
                            case 'S': newY = _y == _map.GetLength(1) - 1? 0 : _y + 1; break;
                            case 'E': newX = _x == 0? _map.GetLength(0) - 1 : _x - 1; break;
                        }

                       break;

                    case 'L':
                        _direction = _direction switch
                        {
                            'N' => 'W',
                            'W' => 'S',
                            'S' => 'E',
                            _ => 'N',
                        };
                        break;

                    case 'R':
                        _direction = _direction switch
                        {
                            'N' => 'E',
                            'E' => 'S',
                            'S' => 'W',
                            _ => 'N',
                        };
                        break;
                }

                if (_map[newY, newX] == 1)
                {
                    throw new Exception("Obstacle found");
                }

                _x = newX;
                _y = newY;
            }
        }
    }
}