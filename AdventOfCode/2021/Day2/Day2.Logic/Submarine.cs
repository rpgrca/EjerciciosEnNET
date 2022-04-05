using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2.Logic
{
    public sealed class Submarine
    {
        private List<(string Command, int Value)> _course;
        private readonly Dictionary<string, Action<Submarine, int>> _interpreter;

        private int HorizontalPosition { get; set; }
        private int Depth { get; set; }
        private int Aim { get; set; }
        public int Multiplier { get; private set; }

        public static Submarine CreateSimpleSubmarineFor(string course) => new(course, new()
        {
            { "up", (s, v) => s.Depth -= v },
            { "down", (s, v) => s.Depth += v },
            { "forward", (s, v) => s.HorizontalPosition += v }
        });

        public static Submarine CreateComplexSubmarineFor(string course) => new(course, new()
        {
            { "up", (s, v) => s.Aim -= v },
            { "down", (s, v) => s.Aim += v },
            { "forward", (s, v) =>
                {
                    s.HorizontalPosition += v;
                    s.Depth += v * s.Aim;
                }
            }
        });

        private Submarine(string course, Dictionary<string, Action<Submarine, int>> interpreter)
        {
            if (string.IsNullOrWhiteSpace(course))
            {
                throw new ArgumentException("Invalid course");
            }

            _interpreter = interpreter;
            _course = new();

            ParseInformationFrom(course);
            RunInstructions();
            CalculateMultiplier();
        }

        private void ParseInformationFrom(string course) =>
            _course = course.Split("\n")
                .Select(l => l.Split(" "))
                .Select(a => (Command: a[0], Value: int.Parse(a[1])))
                .ToList();

        private void RunInstructions() =>
            _course.ForEach(i => _interpreter[i.Command](this, i.Value));

        private void CalculateMultiplier() =>
            Multiplier = HorizontalPosition * Depth;
    }
}