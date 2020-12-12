using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode.Day12.Logic
{
    public class Ship
    {
        private readonly string _instructions;
        private Action _facing;

        protected (int North, int East, int South, int West) _waypoint;
        protected (Action Action, int Offset) CurrentInstruction { get; private set; }
        protected List<(Action, int)> ParsedInstructions { get; private set; }

        public int ManhattanDistance { get; protected set; }

        protected int _northOffset;
        protected int _eastOffset;

        public Ship(string instructions, (int, int, int, int) waypoint)
        {
            _waypoint = waypoint;
            _facing = Action.E;
            _instructions = instructions;

            ParseInstructions();
        }

        private void ParseInstructions() =>
            ParsedInstructions = _instructions
                .Split("\n")
                .Select(p => (
                    (Action)Enum.Parse(typeof(Action), p[0].ToString()),
                    int.Parse(p[1..])))
                .ToList();

        public bool IsFacing(Action action) =>
            action == _facing;

        public void ExecuteInstructions()
        {
            InitializeOffsets();
            ProcessInstructions();
            UpdateManhattanDistance();
        }

        private void InitializeOffsets()
        {
            _northOffset = 0;
            _eastOffset = 0;
        }

        private void ProcessInstructions()
        {
            ParsedInstructions.ForEach(c =>
            {
                CurrentInstruction = c;
                ProcessInstruction();
            });
        }

        private void UpdateManhattanDistance() =>
            ManhattanDistance = Math.Abs(_northOffset) + Math.Abs(_eastOffset);

        private void ProcessInstruction()
        {
            switch (CurrentInstruction.Action)
            {
                case Action.N: MoveNorth(); break;
                case Action.S: MoveSouth(); break;
                case Action.E: MoveEast(); break;
                case Action.W: MoveWest(); break;
                case Action.L: RotateLeft(); break;
                case Action.R: RotateRight(); break;
                case Action.F: MoveForward(); break;
            }
        }

        protected virtual void MoveNorth() => _northOffset += CurrentInstruction.Offset;
        protected virtual void MoveSouth() => _northOffset -= CurrentInstruction.Offset;
        protected virtual void MoveEast() => _eastOffset += CurrentInstruction.Offset;
        protected virtual void MoveWest() => _eastOffset -= CurrentInstruction.Offset;

        protected virtual void RotateLeft()
        {
            int spare;

            switch (CurrentInstruction.Offset)
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
        }

        protected virtual void RotateRight()
        {
            int spare;

            switch (CurrentInstruction.Offset)
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
        }

        protected virtual void MoveForward()
        {
            _northOffset += CurrentInstruction.Offset * _waypoint.North;
            _northOffset -= CurrentInstruction.Offset * _waypoint.South;
            _eastOffset += CurrentInstruction.Offset * _waypoint.East;
            _eastOffset -= CurrentInstruction.Offset * _waypoint.West;
        }
    }
}