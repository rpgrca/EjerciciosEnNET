using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day24.Logic
{
    public class Floor
    {
        private readonly string _data;
        private readonly Dictionary<(double, double), Tile> _uniqueTiles;

        public Floor(string data)
        {
            _data = data;
            _uniqueTiles = new Dictionary<(double, double), Tile>();

            ParseFloor();
        }

        public void ParseFloor()
        {
            foreach (var line in _data.Split("\n"))
            {
                var tile = new Tile(line);
                if (! _uniqueTiles.ContainsKey(tile.Position))
                {
                    _uniqueTiles.Add(tile.Position, tile);
                }
                else
                {
                    _uniqueTiles[tile.Position].Flip();
                }
            }
        }

        public int CountBlackTiles() =>
            _uniqueTiles.Values.Count(p => p.IsBlack == 1);

        public void Flip()
        {
            CreateSurroundingTilesAroundBlackTiles();

            var actions = new List<Action>();
            foreach (var tile in _uniqueTiles.Values)
            {
                var count = CountBlackTilesAround(tile);

                if (tile.IsBlack == 1)
                {
                    if (count == 0 || count > 2)
                    {
                        actions.Add(() => tile.SetToWhite());
                    }
                }
                else
                {
                    if (count == 2)
                    {
                        actions.Add(() => tile.SetToBlack());
                    }
                }
            }

            actions.ForEach(a => a());
        }

        private void CreateSurroundingTilesAroundBlackTiles()
        {
            var actions = new List<Action>();
            var existingTiles = new HashSet<(double, double)>();
            var offsets = new(double X, double Y)[]
            {
                (-1, 0),   // w
                (-0.5, 1), // nw
                (0.5, 1),  // ne
                (1, 0),    // e
                (0.5, -1), // se
                (-0.5, -1) // sw
            };

            foreach (var tile in _uniqueTiles.Values.Where(t => t.IsBlack == 1))
            {
                foreach (var (x, y) in offsets)
                {
                    var position = (tile.Position.X + x, tile.Position.Y + y);

                    if (!_uniqueTiles.ContainsKey(position) && !existingTiles.Contains(position))
                    {
                        existingTiles.Add(position);
                        actions.Add(() => _uniqueTiles.Add(position, new Tile(position.Item1, position.Item2)));
                    }
                }
            }
            actions.ForEach(a => a());
        }

        private int CountBlackTilesAround(Tile tile) =>
            (_uniqueTiles.ContainsKey((tile.Position.X - 1, tile.Position.Y)) ? _uniqueTiles[(tile.Position.X - 1, tile.Position.Y)].IsBlack : 0) +
            (_uniqueTiles.ContainsKey((tile.Position.X - 0.5, tile.Position.Y + 1)) ? _uniqueTiles[(tile.Position.X - 0.5, tile.Position.Y + 1)].IsBlack : 0) +
            (_uniqueTiles.ContainsKey((tile.Position.X + 0.5, tile.Position.Y + 1)) ? _uniqueTiles[(tile.Position.X + 0.5, tile.Position.Y + 1)].IsBlack : 0) +
            (_uniqueTiles.ContainsKey((tile.Position.X + 1, tile.Position.Y)) ? _uniqueTiles[(tile.Position.X + 1, tile.Position.Y)].IsBlack : 0) +
            (_uniqueTiles.ContainsKey((tile.Position.X + 0.5, tile.Position.Y - 1)) ? _uniqueTiles[(tile.Position.X + 0.5, tile.Position.Y - 1)].IsBlack : 0) +
            (_uniqueTiles.ContainsKey((tile.Position.X - 0.5, tile.Position.Y - 1)) ? _uniqueTiles[(tile.Position.X - 0.5, tile.Position.Y - 1)].IsBlack : 0);

        public void Flips(int flips)
        {
            for (var index = 0; index < flips; index++)
            {
                Flip();
            }
        }
    }
}