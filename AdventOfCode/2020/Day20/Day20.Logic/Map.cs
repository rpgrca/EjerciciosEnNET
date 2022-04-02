using System.Linq;
using System.Collections.Generic;
using System;

namespace AdventOfCode2020.Day20.Logic
{
    public class Map
    {
        private readonly string _data;
        private List<Tile> _tiles;
        private readonly Tile[,] _reassembledMap;
        public int Width { get; }
        public int Height { get; }
        public List<Tile> Corners { get; }
        public List<Tile> Borders { get; }
        public ulong CornersMultiplied => Corners.Select(t => (ulong)t.Id).Aggregate((r, i) => r *= i);
        public int MonstersFoundInMap { get; private set; }
        public int WaterRoughness { get; private set; }

        public Map(string data, int width, int height)
        {
            _data = data;
            _tiles = new List<Tile>();
            Width = width;
            Height = height;
            Corners = new List<Tile>();
            Borders = new List<Tile>();
            MonstersFoundInMap = 0;
            _reassembledMap = new Tile[Height,Width];

            ParseMap();
        }

        private void ParseMap() =>
            _tiles = _data.Split("\n\n").Select(t => new Tile(t)).ToList();

        public void ClassifyEdge()
        {
            var compatiblity = new List<int>();
            foreach (var tile in _tiles)
            {
                var tilesThatCanBeAdjacent = _tiles.Where(t => t.Id != tile.Id && tile.CouldBeAdjacentOf(t)).ToList();
                var emptyBorder = 4 - tilesThatCanBeAdjacent.Count;
                if (Width == 1 || Height == 1)
                {
                    if (emptyBorder == 3)
                    {
                        Corners.Add(tile);
                    }
                    else
                    {
                        if (emptyBorder == 2)
                        {
                            Borders.Add(tile);
                        }
                        else
                        {
                            if (Width == 1 && Height == 1)
                            {
                                Corners.Add(tile);
                            }
                        }
                    }
                }
                else
                {
                    if (emptyBorder == 2)
                    {
                        Corners.Add(tile);
                        tile.MarkAsCorner(tilesThatCanBeAdjacent);
                    }
                    else
                    {
                        if (emptyBorder == 1)
                        {
                            Borders.Add(tile);
                            tile.MarkAsBorder(tilesThatCanBeAdjacent);
                        }
                        else
                        {
                            tile.MarkAsInsidePiece(tilesThatCanBeAdjacent);
                        }
                    }
                }
            }
        }

        public void ReformEdge()
        {
            foreach (var corner in Corners)
            {
                _reassembledMap[0, 0] = corner;

                if (corner.InnerSide is null || (corner.InnerSide.ContainsKey(corner.Right) && corner.InnerSide.ContainsKey(corner.Bottom)))
                {
                    // acomodado
                }
                else
                if (corner.InnerSide.ContainsKey(corner.Right) && corner.InnerSide.ContainsKey(corner.Top))
                {
                    corner.RotateRight(90);
                }
                else
                if (corner.InnerSide.ContainsKey(corner.Left) && corner.InnerSide.ContainsKey(corner.Bottom))
                {
                    corner.RotateRight(270);
                }
                else
                if (corner.InnerSide.ContainsKey(corner.Left) && corner.InnerSide.ContainsKey(corner.Top))
                {
                    corner.RotateRight(180);
                }

                for (var y = 0; y < Height; y++)
                {
                    for (var x = 0; x < Width; x++)
                    {
                        if (x != 0 || y != 0)
                        {
                            if (x > 0)
                            {
                                var previousTile = _reassembledMap[y, x - 1];
                                var nextTile = previousTile.InnerSide[previousTile.Right];
                                if (nextTile.MakeLeftSideBe(previousTile.Right))
                                {
                                    _reassembledMap[y, x] = nextTile;
                                }
                            }
                            else
                            {
                                if (y > 0)
                                {
                                    var previousTile = _reassembledMap[y - 1, x];
                                    var nextTile = previousTile.InnerSide[previousTile.Bottom];
                                    if (nextTile.MakeTopSideBe(previousTile.Bottom))
                                    {
                                        _reassembledMap[y, x] = nextTile;
                                    }
                                }
                            }
                        }
                    }
                }

                break;
            }
        }

        public Tile[,] GetReassembledMap() => _reassembledMap;

        public void Crop()
        {
            foreach (var tile in _reassembledMap)
            {
                tile.Crop();
            }
        }

        private string BuildGraphicalMap()
        {
            var fullMap = string.Empty;
            var size = _reassembledMap[0,0].GetSize();

            for (var y = 0; y < Height; y++)
            {
                for (var h = 0; h < size; h++)
                {
                    for (var x = 0; x < Width; x++)
                    {
                        fullMap += _reassembledMap[y, x].Image[(h * size)..((h * size) + size)];
                    }
                    fullMap += "\n";
                }
            }

            return fullMap;
        }

        public void FindMonsters()
        {
            static bool monsterVerifierNormal(string m, int spacer, int x) =>
                m[x] == '#' && m[x + spacer] == '#' && m[x + spacer + 5] == '#' && m[x + spacer + 6] == '#' &&
                m[x + spacer + 11] == '#' && m[x + spacer + 12] == '#' && m[x + spacer + 17] == '#' &&
                m[x + spacer + 18] == '#' && m[x + spacer + 19] == '#' && m[x + (spacer * 2) + 19] == '#' &&
                m[x + (spacer * 2) + 22] == '#' && m[x + (spacer * 2) + 25] == '#' && m[x + (spacer * 2) + 28] == '#' &&
                m[x + (spacer * 2) + 31] == '#' && m[x + (spacer * 2) + 34] == '#';

            var fullMap = string.Empty;
            var squareSize = _reassembledMap[0,0].GetSize();
            var size = squareSize * Width;
            var spacer = 6 + (size - 24);
            var lastPosition = (size * size) - ((spacer * 2) + 37);
            var actions = new List<Action>
            {
                () => {},                           // ↑
                () => RotateAQuarterToTheRight(),   // →
                () => RotateAQuarterToTheRight(),   // ↓
                () => RotateAQuarterToTheRight(),   // ←
                () => FlipVertically(),             // ←V
                () => RotateAQuarterToTheRight(),   // ↑V
                () => RotateAQuarterToTheRight(),   // →V
                () => RotateAQuarterToTheRight(),   // ↓V

                // Not needed, horizontally flipping is rotating right 180
                //() => FlipHorizontally(),           // ↓VH
                //() => RotateAQuarterToTheRight(),   // ←VH
                //() => RotateAQuarterToTheRight(),   // ↑VH
                //() => RotateAQuarterToTheRight(),   // →VH
                //() => FlipVertically(),             // →H
                //() => RotateAQuarterToTheRight(),   // ↓H
                //() => RotateAQuarterToTheRight(),   // ←H
                //() => RotateAQuarterToTheRight(),   // ↑H
                //() => FlipHorizontally()          // ↑
            };

            MonstersFoundInMap = 0;
            foreach (var action in actions)
            {
                action.Invoke();

                fullMap = BuildGraphicalMap().Replace("\n", string.Empty);

                for (var y = 0; y < size; y++)
                {
                    for (var x = 0; x <= size - 2; x++)
                    {
                        var position = (y * size) + x;

                        if (position < lastPosition)
                        {
                            if (monsterVerifierNormal(fullMap, spacer, position))
                            {
                                MonstersFoundInMap++;
                            }
                        }
                    }
                }

                if (MonstersFoundInMap > 0)
                {
                    break;
                }
            }

            WaterRoughness = fullMap.Count(p => p == '#') - (MonstersFoundInMap * 15);
        }

        public void FlipVertically()
        {
            var newMap = new Tile[Height, Width];

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    newMap[y, Width - x - 1] = _reassembledMap[y, x];
                    newMap[y, Width - x - 1].FlipVertically();
                }
            }

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    _reassembledMap[y, x] = newMap[y, x];
                }
            }
        }

        public void RotateAQuarterToTheRight()
        {
            var newMap = new Tile[Height,Width];

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    newMap[x, Width-1-y] = _reassembledMap[y, x];
                    newMap[x, Width-1-y].RotateRight(90);
                }
            }

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    _reassembledMap[y, x] = newMap[y, x];
                }
            }
        }
    }
}