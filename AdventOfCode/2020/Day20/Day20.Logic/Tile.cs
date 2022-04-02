using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day20.Logic
{
    public class Tile
    {
        public enum CurrentPosition
        {
            Normal = 0,
            Rotated90 = 1,
            Rotated180 = 2,
            Rotated270 = 3,
            FlippedVertically = 4,
            FlippedVerticallyRotated90 = 5,
            FlippedVerticallyRotated180 = 6,
            FlippedVerticallyRotated270 = 7,
            FlippedHorizontally = 8,
            FlippedHorizontallyRotated90 = 9,
            FlippedHorizontallyRotated180 = 10,
            FlippedHorizontallyRotated270 = 11,
            FlippedVerticallyAndHorizontally = 12,
            FlippedVerticallyAndHorizontallyRotated90 = 13,
            FlippedVerticallyAndHorizontallyRotated180 = 14,
            FlippedVerticallyAndHorizontallyRotated270 = 15
        }

        private const int Size = 10;
        private readonly string _data;
        private int _size = Size;

        public Dictionary<string, Tile> InnerSide { get; private set; }
        public int Id { get; private set; }
        public string Image { get; private set; }
        public CurrentPosition Position { get; private set; }
        public List<Tile> Transformations { get; }
        private readonly List<string> _borders;
        public string Top { get; private set; }
        public string Left { get; private set; }
        public string Right { get; private set; }
        public string Bottom { get; private set; }

        private Tile(Tile tile)
        {
            _data = tile._data;
            Image = tile.Image;

            Top = tile.Top;
            Left = tile.Left;
            Right = tile.Right;
            Bottom = tile.Bottom;
            Position = tile.Position;

            _borders = new List<string>(tile._borders);
        }

        public Tile(string data)
        {
            _data = data;
            _borders = new List<string>();
            Position = CurrentPosition.Normal;
            Transformations = new List<Tile>();

            ParseTile();
        }

        private void ParseTile()
        {
            GetIdFromData();

            GetImageFromData();
            CalculateSizeFromData();
            GetBordersFromImage();
            ComputeVariants();
        }

        private void GetIdFromData() =>
            Id = int.Parse(_data.Replace("\n", string.Empty).Split(":")[0].Replace("Tile ", string.Empty));

        private void GetImageFromData() =>
            Image = _data.Replace("\n", string.Empty).Split(":")[1];

        private void CalculateSizeFromData() =>
            _size = (int)Math.Sqrt(Image.Length);

        private void GetBordersFromImage() =>
            (Top, Right, Bottom, Left) =
                (Image[0.._size],
                 new string(Image.Where((_, i) => (i + 1) % _size == 0).ToArray()),
                 Image[((_size * _size) - _size)..(_size * _size)],
                 new string(Image.Where((_, i) => i % _size == 0).ToArray()));

        private void ComputeVariants()
        {
            _borders.Clear();
            Transformations.Clear();

            // TODO: Optimization: Borders have repeated values (Normal.Top == FlippedHorizontally.Bottom)
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // →
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ↓
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ←
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight();
            FlipVertically(); // ↑V
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // →V
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ↓V
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ←V
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight();
            FlipVertically();
            FlipHorizontally(); // ↑H
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // →H
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ↓H
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ←H
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight();
            FlipVertically(); // ↑ VH
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // →VH
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ↓VH
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ←VH
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            // Restore
            RotateAQuarterToTheRight();
            FlipVertically();
            FlipHorizontally();
        }

        private void RotateAQuarterToTheRight()
        {
            var newImage = new char[_size * _size];

            for (var y = 0; y < _size; y++)
            {
                for (var x = 0; x < _size; x++)
                {
                    newImage[((x + 1) * _size) - (y + 1)] = Image[(y * _size) + x];
                }
            }

            Image = new string(newImage);
            GetBordersFromImage();
            ReadjustInnerSide();

            var currentRotation = (int)Position & 3;
            currentRotation = (currentRotation + 1) & 3;
            Position = (CurrentPosition)(((int)Position & 1100) | currentRotation);
        }

        public void RotateRight(int degrees)
        {
            switch (degrees)
            {
                case 90:
                    RotateAQuarterToTheRight();
                    break;

                case 180:
                    RotateAQuarterToTheRight();
                    RotateAQuarterToTheRight();
                    break;

                case 270:
                    RotateAQuarterToTheRight();
                    RotateAQuarterToTheRight();
                    RotateAQuarterToTheRight();
                    break;
            }
        }

        public bool IsAdjacentOf(Tile adjacentTile) =>
            GetBorders().Join(adjacentTile.GetBorders(),
                p => p,
                q => q,
               (r, s) => r == s).Any();

        private List<string> GetBorders() => new() { Top, Right, Bottom, Left };

        public void FlipHorizontally()
        {
            var newImage = new char[_size * _size];

            for (var y = 0; y < _size; y++)
            {
                for (var x = 0; x < _size; x++)
                {
                    newImage[((_size - 1 - y) * _size) + x] = Image[(y * _size) + x];
                }
            }

            Image = new string(newImage);
            GetBordersFromImage();
            ReadjustInnerSide();

            Position ^= CurrentPosition.FlippedHorizontally;
        }

        public void FlipVertically()
        {
             var newImage = new char[_size * _size];

            for (var y = 0; y < _size; y++)
            {
                for (var x = 0; x < _size; x++)
                {
                    newImage[(y * _size) + (_size - 1 - x)] = Image[(y * _size) + x];
                }
            }

            Image = new string(newImage);
            GetBordersFromImage();
            ReadjustInnerSide();

            Position ^= CurrentPosition.FlippedVertically;
        }

        public bool CouldBeAdjacentOf(Tile possibleAdjacentTile) =>
            _borders.Join(possibleAdjacentTile._borders,
                p => p,
                q => q,
                (r, s) => r == s).Any();

        public void MarkAsCorner(List<Tile> adjacentTiles)
        {
            InnerSide = new Dictionary<string, Tile>();

            var adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Top));
            if (adjacentTile != null)
            {
                InnerSide.Add(Top, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Right));
            if (adjacentTile != null)
            {
                InnerSide.Add(Right, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Bottom));
            if (adjacentTile != null)
            {
                InnerSide.Add(Bottom, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Left));
            if (adjacentTile != null)
            {
                InnerSide.Add(Left, adjacentTile);
            }
        }

        public void MarkAsBorder(List<Tile> adjacentTiles)
        {
            InnerSide = new Dictionary<string, Tile>();

            var adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Top));
            if (adjacentTile != null)
            {
                InnerSide.Add(Top, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Right));
            if (adjacentTile != null)
            {
                InnerSide.Add(Right, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Bottom));
            if (adjacentTile != null)
            {
                InnerSide.Add(Bottom, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Left));
            if (adjacentTile != null)
            {
                InnerSide.Add(Left, adjacentTile);
            }
        }

        public void MarkAsInsidePiece(List<Tile> adjacentTiles)
        {
            InnerSide = new Dictionary<string, Tile>
            {
                { Top, adjacentTiles.Single(t => t._borders.Contains(Top)) },
                { Right, adjacentTiles.Single(t => t._borders.Contains(Right)) },
                { Bottom, adjacentTiles.Single(t => t._borders.Contains(Bottom)) },
                { Left, adjacentTiles.Single(t => t._borders.Contains(Left)) }
            };
        }

        private void ReadjustInnerSide()
        {
            if (InnerSide != null)
            {
                var oldInnerSide = new Dictionary<string, Tile>(InnerSide);
                Tile temp = null;
                InnerSide.Clear();

                if (oldInnerSide.ContainsKey(Top))
                {
                    InnerSide.Add(Top, oldInnerSide[Top]);
                }
                else
                {
                    temp = oldInnerSide.Values.SingleOrDefault(q => q._borders.Contains(Top));
                    if (temp != null)
                    {
                        InnerSide.Add(Top, temp);
                    }
                }

                if (oldInnerSide.ContainsKey(Right))
                {
                    InnerSide.Add(Right, oldInnerSide[Right]);
                }
                else
                {
                    temp = oldInnerSide.Values.SingleOrDefault(q => q._borders.Contains(Right));
                    if (temp != null)
                    {
                        InnerSide.Add(Right, temp);
                    }
                }

                if (oldInnerSide.ContainsKey(Bottom))
                {
                    InnerSide.Add(Bottom, oldInnerSide[Bottom]);
                }
                else
                {
                    temp = oldInnerSide.Values.SingleOrDefault(q => q._borders.Contains(Bottom));
                    if (temp != null)
                    {
                        InnerSide.Add(Bottom, temp);
                    }
                }

                if (oldInnerSide.ContainsKey(Left))
                {
                    InnerSide.Add(Left, oldInnerSide[Left]);
                }
                else
                {
                    temp = oldInnerSide.Values.SingleOrDefault(q => q._borders.Contains(Left));
                    if (temp != null)
                    {
                        InnerSide.Add(Left, temp);
                    }
                }
            }
        }

        public bool MakeLeftSideBe(string side) =>
            MakeASideBe(t => t.Left == side);

        private bool MakeASideBe(Func<Tile, bool> checkIfSideIsAsExpected)
        {
            var transformation = Transformations.First(t => checkIfSideIsAsExpected(t));

            FlipHorizontallyIfNeeded(transformation);
            FlipVerticallyIfNeeded(transformation);
            RotateIfNeeded(transformation);

            return checkIfSideIsAsExpected(this);
        }

        private void FlipHorizontallyIfNeeded(Tile transformation)
        {
            if (IsFlippedHorizontally(transformation))
            {
                FlipHorizontally();
            }
        }

        private void FlipVerticallyIfNeeded(Tile transformation)
        {
            if (IsFlippedVertically(transformation))
            {
                FlipVertically();
            }
        }

        private static bool IsFlippedHorizontally(Tile transformation) =>
            (transformation.Position & CurrentPosition.FlippedHorizontally) == CurrentPosition.FlippedHorizontally;

        private static bool IsFlippedVertically(Tile transformation) =>
            (transformation.Position & CurrentPosition.FlippedVertically) == CurrentPosition.FlippedVertically;

        private void RotateIfNeeded(Tile transformation)
        {
            switch ((CurrentPosition)((int)transformation.Position & 3))
            {
                case CurrentPosition.Normal:
                    // ok
                    break;

                case CurrentPosition.Rotated90:
                    RotateRight(90);
                    break;

                case CurrentPosition.Rotated180:
                    RotateRight(180);
                    break;

                case CurrentPosition.Rotated270:
                    RotateRight(270);
                    break;
            }
        }

        public bool MakeTopSideBe(string side) =>
            MakeASideBe(t => t.Top == side);

        public void Crop()
        {
            Image = string.Concat(Enumerable
                .Range(0, 10)
                .Select(i => Image.Substring(i * 10, 10))
                .Skip(1)
                .Take(8)
                .Select(p => p[1..9]));
            _size = 8;
        }

        public int GetSize() => _size;

        //public void Display()
        //{
        //    for (var y = 0; y < _size; y++)
        //    {
        //        Console.WriteLine($"{Image[(y * _size)..((y * _size) + _size)]}");
        //    }
        //}
    }
}