using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2.Logic
{
    public class Submarine
    {
        private List<(string, int)> _course;

        public int HorizontalPosition { get; private set; }
        public int Depth { get; private set; }
        public int Multiplier { get; }
        public int Aim { get; set; }

        public Submarine(string course)
        {
            if (string.IsNullOrWhiteSpace(course))
            {
                throw new ArgumentException("Invalid course");
            }

            ParseInformationFrom(course);
            RunInstructionsUsing(new Dictionary<string, Action<int>>()
            {
                { "up", v => Depth -= v },
                { "down", v => Depth += v },
                { "forward", v => HorizontalPosition += v }
            });

            Multiplier = HorizontalPosition * Depth;
        }

        private void ParseInformationFrom(string course)
        {
            _course = course.Split("\n")
                .Select(l => l.Split(" "))
                .Select(a => (a[0], int.Parse(a[1])))
                .ToList();
        }

        private void RunInstructionsUsing(Dictionary<string, Action<int>> interpreter)
        {
            foreach (var (command, value) in _course)
            {
                interpreter[command](value);
            }
        }

        public Submarine(string course, bool useAim)
        {
            ParseInformationFrom(course);
            RunInstructionsUsing(new Dictionary<string, Action<int>>()
            {
                { "up", v => Aim -= v },
                { "down", v => Aim += v },
                { "forward", v => {
                    HorizontalPosition += v;
                    Depth += v * Aim;
                }}
            });

            Multiplier = HorizontalPosition * Depth;
        }
    }
}