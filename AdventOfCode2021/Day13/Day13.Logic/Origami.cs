using System.Linq;
using System;
using System.Collections.Generic;

namespace Day13.Logic
{
    public class Origami
    {
        private readonly string _instructions;
        private readonly List<(int X, int Y)> _points;
        private readonly List<string> _folds;

        public Origami(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
            {
                throw new ArgumentException("Invalid instructions");
            }

            _instructions = instructions;
            _points = new List<(int X, int Y)>();
            _folds = new List<string>();

            Parse();
        }

        private void Parse()
        {
            _points.AddRange(_instructions
                .Split("\n")
                .TakeWhile(p => !string.IsNullOrWhiteSpace(p))
                .Select(p => p.Split(","))
                .Select(p => (int.Parse(p[0]), int.Parse(p[1]))));

            _folds.AddRange(_instructions
                .Split("\n")
                .Skip(_points.Count + 1)
                .Select(p => p.Replace("fold along ", string.Empty)));
        }

        public int GetPoints() => _points.Count;

        public int GetFolds() => _folds.Count;
    }
}
