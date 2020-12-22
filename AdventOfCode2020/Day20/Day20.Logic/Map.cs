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
        private string[] _fullMap;

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
                    corner.RotateRight(90); // o flip horizontal
                }
                else
                if (corner.InnerSide.ContainsKey(corner.Left) && corner.InnerSide.ContainsKey(corner.Bottom))
                {
                    corner.RotateLeft(90); // o flip vertical
                }
                else
                if (corner.InnerSide.ContainsKey(corner.Left) && corner.InnerSide.ContainsKey(corner.Top))
                {
                    corner.RotateRight(180); // o flip + rotate / rotate + flip
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
            var fullMap1 = string.Empty;
            for (var y = 0; y < Height; y++)
            {
                for (var h = 0; h < 10; h++)
                {
                    for (var x = 0; x < Width; x++)
                    {
                        fullMap1 += _reassembledMap[y, x].Image[(h * 10)..((h * 10) + 10)];
                    }
                    fullMap1 += "\n";
                }
            }

            var map1 = new Tile($"Tile 9998:\n{fullMap1}", 120);
            map1.Display();

            foreach (var tile in _reassembledMap)
            {
                tile.Crop();
            }

            var fullMap = BuildGraphicalMap();
            _fullMap = fullMap.Split("\n");
            var map = new Tile($"Tile 9999:\n{fullMap}", 96);

            map.FlipVertically();
            map.FlipHorizontally();
            map.RotateRight(270);
            map.Display();
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
            static bool monsterVerifierNormal(string m, int x) =>
                m[x] == '#' && m[x + 78] == '#' && m[x + 83] == '#' && m[x + 84] == '#' &&
                m[x + 89] == '#' && m[x + 90] == '#' && m[x + 95] == '#' && m[x + 96] == '#' &&
                m[x + 97] == '#' && m[x + 175] == '#' && m[x + 178] == '#' && m[x + 181] == '#' &&
                m[x + 184] == '#' && m[x + 187] == '#' && m[x + 190] == '#';

            var fullMap = BuildGraphicalMap().Replace("\n", string.Empty);
            var size = _reassembledMap[0,0].GetSize();
            var lastPosition = (size * size) - 190;

            MonstersFoundInMap = 0;
            for (var y = 0; y < size; y++)
            {
                for (var x = 0; x <= size - 2; x++)
                {
                    var position = (y * size) + x;
                    if (position < lastPosition)
                    {
                       if (monsterVerifierNormal(fullMap, position))
                       {
                            MonstersFoundInMap++;
                       }
                    }
                }
            }

            WaterRoughness = fullMap.Count(p => p == '#') - (MonstersFoundInMap * 15);
        }
    }
}