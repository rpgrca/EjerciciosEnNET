using System;

namespace MarsRover.UnitTests
{
    public class MarsRover
    {
        private char _direction;
        private int _x;
        private int _y;

        public MarsRover(char direction, int x, int y)
        {
            if (direction == 'N' || direction == 'S' || direction == 'E' || direction == 'W')
            {
                _direction = direction;
            }
            else
            {
                throw new Exception("Invalid command");
            }

            _x = x;
            _y = y;
        }

        public char GetDirection() => _direction;

        public int GetX() => _x;

        public int GetY() => _y;

        public void SendCommand(string commands)
        {
            foreach (var command in commands)
            {
                if (command == 'F')
                {
                    _y++;
                }

                if (command == 'B')
                {
                    _y--;
                }

                if (command == 'L')
                {
                    switch (_direction)
                    {
                        case 'N': _direction = 'W'; break;
                        case 'W': _direction = 'S'; break;
                        case 'S': _direction = 'E'; break;
                        default: _direction = 'N'; break;
                    }
                }

                if (command == 'R')
                {
                    switch (_direction)
                    {
                        case 'N': _direction = 'E'; break;
                        case 'E': _direction = 'S'; break;
                        case 'S': _direction = 'W'; break;
                        default: _direction = 'N'; break;
                    }
                }
            }
        }
    }
}