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
                if (_direction == 'N')
                {
                    if (command == 'F')
                    {
                        _y++;
                    }

                    if (command == 'B')
                    {
                        _y--;
                    }
                }
                else if (_direction == 'W')
                {
                    if (command == 'F')
                    {
                        _x--;
                    }

                    if (command == 'B')
                    {
                        _x++;
                    }
                }
                else if (_direction == 'S')
                {
                    if (command == 'F')
                    {
                        _y--;
                    }

                    if (command == 'B')
                    {
                        _y++;
                    }
                }
                else
                {
                    if (command == 'F')
                    {
                        _x++;
                    }

                    if (command == 'B')
                    {
                        _x--;
                    }
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