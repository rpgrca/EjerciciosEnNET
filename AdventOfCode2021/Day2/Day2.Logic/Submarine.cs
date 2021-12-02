using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2.Logic
{
    public class Submarine
    {
        private List<(string, int)> _course;
        private readonly Dictionary<string, Action<Submarine, int>> _interpreter;

        public int HorizontalPosition { get; private set; }
        public int Depth { get; private set; }
        public int Multiplier { get; }
        public int Aim { get; private set; }

        public static Submarine CreateSimpleSubmarineFor(string course) => new(course, CreateSimpleMovementInterpreter());

        public static Submarine CreateComplexSubmarineFor(string course) => new(course, CreateComplexMovementInterpreter());

        private Submarine(string course, Dictionary<string, Action<Submarine, int>> interpreter)
        {
            if (string.IsNullOrWhiteSpace(course))
            {
                throw new ArgumentException("Invalid course");
            }

            _interpreter = interpreter;

            ParseInformationFrom(course);
            RunInstructions();

            Multiplier = HorizontalPosition * Depth;
        }

        private void ParseInformationFrom(string course)
        {
            _course = course.Split("\n")
                .Select(l => l.Split(" "))
                .Select(a => (a[0], int.Parse(a[1])))
                .ToList();
        }

        private static Dictionary<string, Action<Submarine, int>> CreateSimpleMovementInterpreter() =>
            new()
            {
                { "up", (s, v) => s.Depth -= v },
                { "down", (s, v) => s.Depth += v },
                { "forward", (s, v) => s.HorizontalPosition += v }
            };

        private static Dictionary<string, Action<Submarine, int>> CreateComplexMovementInterpreter() =>
            new()
            {
                { "up", (s, v) => s.Aim -= v },
                { "down", (s, v) => s.Aim += v },
                { "forward", (s, v) => {
                    s.HorizontalPosition += v;
                    s.Depth += v * s.Aim;
                }}
            };

        private void RunInstructions()
        {
            foreach (var (command, value) in _course)
            {
                _interpreter[command](this, value);
            }
        }
    }
}