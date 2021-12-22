using System;
using System.Collections.Generic;
using System.Linq;

namespace Day22.Logic
{
    internal class Edge
    {
    }

    public class Cube
    {
        private readonly string _vertexes;
        private Func<(int X, int Y, int Z), bool> _intersector;

        public List<(int X, int Y, int Z)> Vertexes { get; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Depth { get; private set; }

        public Cube(string vertexes)
        {
            _vertexes = vertexes;
            Vertexes = new List<(int X, int Y, int Z)>();

            Parse();
        }

        private void Parse()
        {
            var axis = _vertexes.Split(",")
                .Select(p => p.Split("="))
                .Select(p => p[1])
                .Select(p => p.Split(".."))
                .ToArray();

            _intersector = v =>
                v.X >= int.Parse(axis[0][0]) && v.X <= int.Parse(axis[0][1]) &&
                v.Y >= int.Parse(axis[1][0]) && v.Y <= int.Parse(axis[1][1]) &&
                v.Z >= int.Parse(axis[2][0]) && v.Z <= int.Parse(axis[2][1]);

            foreach (var x in axis[0])
            {
                foreach (var y in axis[1])
                {
                    foreach (var z in axis[2])
                    {
                        Vertexes.Add((int.Parse(x), int.Parse(y), int.Parse(z)));
                    }
                }
            }

            Width = int.Parse(axis[0][1]) - int.Parse(axis[0][0]) + 1; // x
            Depth = int.Parse(axis[1][1]) - int.Parse(axis[1][0]) + 1; // y
            Height = int.Parse(axis[2][1]) - int.Parse(axis[2][0]) + 1; // z
        }

        public long GetArea() => Width * Height * Depth;

        public bool IntersectsWith(Cube other)
        {
            foreach (var vertex in other.Vertexes)
            {
                if (_intersector(vertex))
                {
                    return true;
                }
            }

            foreach (var vertex in Vertexes)
            {
                if (other._intersector(vertex))
                {
                    return true;
                }
            }

            return false;
        }

        public List<Cube> Subtract(Cube other)
        {
            var cubes = new List<Cube>();

            if (! IntersectsWith(other))
            {
                cubes.Add(this);
                return cubes;
            }

            return cubes;
        }
    }
}