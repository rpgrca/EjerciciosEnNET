using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode.Day12.Logic
{
    public class Ship
    {
        private readonly string _instructions;
        private Action _facing;
        private List<(Action, int)> _parsedInstructions;

        protected (int North, int East, int South, int West) _waypoint;

        protected (Action Action, int Offset) CurrentInstruction { get; private set; }
        protected int NorthOffset { get; private set; }
        protected int EastOffset { get; private set; }

        public int ManhattanDistance { get; private set; }

        public Ship(string instructions)
            : this(instructions, (0, 1, 0, 0))
        {
        }

        protected Ship(string instructions, (int, int, int, int) waypoint)
        {
            _waypoint = waypoint;
            _facing = Action.E;
            _instructions = instructions;
            _parsedInstructions = new List<(Action, int)>();

            ParseInstructions();
        }

        private void ParseInstructions() =>
            _parsedInstructions = _instructions
                .Split("\n")
                .Select(p => (
                    (Action)Enum.Parse(typeof(Action), p[0].ToString()),
                    int.Parse(p[1..])))
                .ToList();

        public void ExecuteInstructions()
        {
            InitializeOffsets();
            ProcessInstructions();
            UpdateManhattanDistance();
        }

        private void InitializeOffsets()
        {
            NorthOffset = 0;
            EastOffset = 0;
        }

        private void ProcessInstructions()
        {
            _parsedInstructions.ForEach(c =>
            {
                CurrentInstruction = c;
                ProcessInstruction();
            });
        }

        private void UpdateManhattanDistance() =>
            ManhattanDistance = Math.Abs(NorthOffset) + Math.Abs(EastOffset);

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

        protected virtual void MoveNorth() => NorthOffset += CurrentInstruction.Offset;
        protected virtual void MoveSouth() => NorthOffset -= CurrentInstruction.Offset;
        protected virtual void MoveEast() => EastOffset += CurrentInstruction.Offset;
        protected virtual void MoveWest() => EastOffset -= CurrentInstruction.Offset;

        private void RotateLeft()
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

        private void RotateRight()
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

        private void MoveForward()
        {
            NorthOffset += CurrentInstruction.Offset * _waypoint.North;
            NorthOffset -= CurrentInstruction.Offset * _waypoint.South;
            EastOffset += CurrentInstruction.Offset * _waypoint.East;
            EastOffset -= CurrentInstruction.Offset * _waypoint.West;
        }
    }
}