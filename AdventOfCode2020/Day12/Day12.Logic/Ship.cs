using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode.Day12.Logic
{
    public class Ship
    {
        private (int North, int East, int South, int West) _waypoint;
        private Action _facing;
        private readonly List<string> _instructions;

        public int ManhattanDistance { get; private set; } = 10;
        public (int, int, int, int) Waypoint => _waypoint;

        public Ship(string instructions, (int, int, int, int) waypoint)
        {
            _waypoint = waypoint;
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
                            case 90: _facing =(Action)(((int)_facing + 3) % 4); break;
                            case 180: _facing = (Action)(((int)_facing + 2) % 4); break;
                            case 270: _facing = (Action)(((int)_facing + 1) % 4); break;
                        }
                        break;

                    case Action.R:
                        switch (offset)
                        {
                            case 90: _facing =(Action)(((int)_facing + 1) % 4); break;
                            case 180: _facing = (Action)(((int)_facing + 2) % 4); break;
                            case 270: _facing = (Action)(((int)_facing + 3) % 4); break;
                        }
                        break;

                    case Action.F:
                        switch (_facing)
                        {
                            case Action.N: northOffset += offset; break;
                            case Action.S: northOffset -= offset; break;
                            case Action.E: eastOffset += offset; break;
                            case Action.W: eastOffset -= offset; break;
                        }
                        break;
                }
            }

            ManhattanDistance = Math.Abs(northOffset) + Math.Abs(eastOffset);
        }

        public void ExecuteInstructionsWithWaypoint()
        {
            var northOffset = 0;
            var eastOffset = 0;

            foreach (var instruction in _instructions)
            {
                var action = Enum.Parse(typeof(Action), instruction[0].ToString());
                var offset = int.Parse(instruction[1..]);
                int spare;

                switch (action)
                {
                    case Action.N: _waypoint.North += offset; break;
                    case Action.S: _waypoint.South += offset; break;
                    case Action.E: _waypoint.East += offset; break;
                    case Action.W: _waypoint.West += offset; break;
                    case Action.L:
                        switch (offset)
                        {
                            case 90:
                                _facing =(Action)(((int)_facing + 3) % 4);
                                spare = _waypoint.North;
                                _waypoint.North = _waypoint.East;
                                _waypoint.East = _waypoint.South;
                                _waypoint.South = _waypoint.West;
                                _waypoint.West = spare;
                                break;

                            case 180:
                                _facing = (Action)(((int)_facing + 2) % 4);
                                (_waypoint.North, _waypoint.South) = (_waypoint.South, _waypoint.North);
                                (_waypoint.East, _waypoint.West) = (_waypoint.West, _waypoint.East);
                                break;

                            case 270:
                                _facing = (Action)(((int)_facing + 1) % 4);
                                spare = _waypoint.North;
                                _waypoint.North = _waypoint.West;
                                _waypoint.West = _waypoint.South;
                                _waypoint.South = _waypoint.East;
                                _waypoint.East = spare;
                                break;
                        }
                        break;

                    case Action.R:
                        switch (offset)
                        {
                            case 90:
                                _facing =(Action)(((int)_facing + 1) % 4);
                                spare = _waypoint.North;
                                _waypoint.North = _waypoint.West;
                                _waypoint.West = _waypoint.South;
                                _waypoint.South = _waypoint.East;
                                _waypoint.East = spare;
                                break;

                            case 180:
                                _facing = (Action)(((int)_facing + 2) % 4);
                                (_waypoint.North, _waypoint.South) = (_waypoint.South, _waypoint.North);
                                (_waypoint.East, _waypoint.West) = (_waypoint.West, _waypoint.East);
                                break;

                            case 270:
                                _facing = (Action)(((int)_facing + 3) % 4);
                                spare = _waypoint.North;
                                _waypoint.North = _waypoint.East;
                                _waypoint.East = _waypoint.South;
                                _waypoint.South = _waypoint.West;
                                _waypoint.West = spare;
                                break;
                        }
                        break;

                    case Action.F:
                        northOffset += offset * _waypoint.North;
                        northOffset -= offset * _waypoint.South;
                        eastOffset += offset * _waypoint.East;
                        eastOffset -= offset * _waypoint.West;
                        break;
                }
            }

            ManhattanDistance = Math.Abs(northOffset) + Math.Abs(eastOffset);
        }
    }
}