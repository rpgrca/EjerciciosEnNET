using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode.Day12.Logic
{
    public class Ship
    {
        private Action _facing;
        private readonly List<string> _instructions;

        public int ManhattanDistance { get; private set; } = 10;

        public Ship(string instructions)
        {
            _facing = Action.E;
            _instructions = instructions.Split("\n").ToList();
        }

        public bool IsFacing(Action action)
        {
            return action == _facing;
        }

        public void ExecuteInstructions()
        {
            var northOffset = 0;
            var eastOffset = 0;

            foreach (var instruction in _instructions)
            {
                var action = Enum.Parse(typeof(Action), instruction[0].ToString());
                var offset = int.Parse(instruction[1..]);

                switch (action)
                {
                    case Action.N: northOffset += offset; break;
                    case Action.S: northOffset -= offset; break;
                    case Action.E: eastOffset += offset; break;
                    case Action.W: eastOffset -= offset; break;
                    case Action.L:
                        switch (offset)
                        {
                            case 0: break;
                            case 90: _facing =(Action)(((int)_facing + 3) % 4); break;
                            case 180: _facing = (Action)(((int)_facing + 2) % 4); break;
                            case 270: _facing = (Action)(((int)_facing + 1) % 4); break;
                            default: throw new ArgumentOutOfRangeException();
                        }
                        break;

                    case Action.R:
                        switch (offset)
                        {
                            case 0: break;
                            case 90: _facing =(Action)(((int)_facing + 1) % 4); break;
                            case 180: _facing = (Action)(((int)_facing + 2) % 4); break;
                            case 270: _facing = (Action)(((int)_facing + 3) % 4); break;
                            default: throw new ArgumentOutOfRangeException();
                        }
                        break;

                    case Action.F:
                        switch (_facing)
                        {
                            case Action.N: northOffset += offset; break;
                            case Action.S: northOffset -= offset; break;
                            case Action.E: eastOffset += offset; break;
                            case Action.W: eastOffset -= offset; break;
                            default: throw new ArgumentOutOfRangeException();
                        }
                        break;
                }
            }

            ManhattanDistance = Math.Abs(northOffset) + Math.Abs(eastOffset);
        }
    }
}