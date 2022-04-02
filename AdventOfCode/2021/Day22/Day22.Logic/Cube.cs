using System;
using System.Collections.Generic;
using System.Linq;

namespace Day22.Logic
{
    public class Cube
    {
        private readonly string _vertexes;
        private Func<(int X, int Y, int Z), bool> _intersector;
        private int _minimumX;
        private int _minimumY;
        private int _minimumZ;
        private int _maximumX;
        private int _maximumY;
        private int _maximumZ;

        public List<(int X, int Y, int Z)> Vertexes { get; }
        public List<Edge> Edges { get; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Depth { get; private set; }
        public Dictionary<int, (int MinimumX, int MaximumX, int MinimumY, int MaximumY)> Slices { get; }

        public Cube(string vertexes)
        {
            _vertexes = vertexes;
            Edges = new List<Edge>();
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

            _minimumX = int.Parse(axis[0][0]);
            _maximumX = int.Parse(axis[0][1]);
            _minimumY = int.Parse(axis[1][0]);
            _maximumY = int.Parse(axis[1][1]);
            _minimumZ = int.Parse(axis[2][0]);
            _maximumZ = int.Parse(axis[2][1]);

            _intersector = v =>
                v.X >= _minimumX && v.X <= _maximumX &&
                v.Y >= _minimumY && v.Y <= _maximumY &&
                v.Z >= _minimumZ && v.Z <= _maximumZ;

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

            Edges.Add(new Edge((_minimumX, _maximumY, _minimumZ), (_maximumX, _maximumY, _minimumZ))); // front bottom
            Edges.Add(new Edge((_minimumX, _maximumY, _maximumZ), (_maximumX, _maximumY, _maximumZ))); // front top
            Edges.Add(new Edge((_minimumX, _maximumY, _minimumZ), (_minimumX, _maximumY, _maximumZ))); // front left
            Edges.Add(new Edge((_maximumX, _maximumY, _minimumZ), (_maximumX, _maximumY, _maximumZ))); // front right
            Edges.Add(new Edge((_minimumX, _minimumY, _minimumZ), (_maximumX, _minimumY, _minimumZ))); // back bottom
            Edges.Add(new Edge((_minimumX, _minimumY, _maximumZ), (_maximumX, _minimumY, _maximumZ))); // back top
            Edges.Add(new Edge((_minimumX, _minimumY, _minimumZ), (_minimumX, _minimumY, _maximumZ))); // back left
            Edges.Add(new Edge((_maximumX, _minimumY, _minimumZ), (_maximumX, _minimumY, _maximumZ))); // back right
            Edges.Add(new Edge((_minimumX, _maximumY, _minimumZ), (_minimumX, _minimumY, _minimumZ))); // right bottom
            Edges.Add(new Edge((_minimumX, _maximumY, _maximumZ), (_minimumX, _minimumY, _maximumZ))); // right top
            Edges.Add(new Edge((_maximumX, _maximumY, _minimumZ), (_maximumX, _minimumY, _minimumZ))); // left bottom
            Edges.Add(new Edge((_maximumX, _maximumY, _maximumZ), (_maximumX, _minimumY, _maximumZ))); // left top 

            Width = _maximumX - _minimumX + 1;
            Depth = _maximumY - _minimumY + 1;
            Height = _maximumZ - _minimumZ + 1;
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

            if (other.FullyContains(this))
            {
                return cubes;
            }

            if (! IntersectsWith(other))
            {
                cubes.Add(this);
                return cubes;
            }

            foreach (var edge in Edges)
            {
            }
            return cubes;
        }

        public List<Edge> Clip(Edge edge)
        {
            var edges = new List<Edge>();

            if (! _intersector(edge.From) && ! _intersector(edge.To))
            {
                edges.Add(edge);
                return edges;
            }

            if (! FullyContains(edge))
            {
                if (_intersector(edge.From))
                {
                }
                else
                {
                }
            }

            return edges;
        }

        public bool FullyContains(Cube other) =>
            other.Vertexes.All(p => _intersector(p));

        public bool FullyContains(Edge other) =>
            other.From.X >= _minimumX && other.To.X <= _maximumX &&
            other.From.Y >= _minimumY && other.To.Y <= _maximumY &&
            other.From.Z >= _minimumZ && other.To.Z <= _maximumZ;
    }
}