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

        public int Id { get; private set; }
        public string Image { get; private set; }
        public CurrentPosition Position { get; private set; }
        public List<Tile> Transformations { get; }
        private readonly List<string> _borders;
        public string Top { get; private set; }
        public string Left { get; private set; }
        public string Right { get; private set; }
        public string Bottom { get; private set; }

        public Tile(string data)
        {
            _data = data;
            _borders = new List<string>();
            Position = CurrentPosition.Normal;
            Transformations = new List<Tile>();

            ParseTile();
            ComputeVariants();
        }

        private Tile(Tile tile)
        {
            _data = tile._data;
            Image = tile.Image;

            Top = tile.Top;
            Left = tile.Left;
            Right = tile.Right;
            Bottom = tile.Bottom;

            _borders = new List<string>(tile._borders);
        }

        private void ParseTile()
        {
            GetIdFromData();
            GetImageFromData();
            GetBordersFromImage();
        }

        private void ComputeVariants()
        {
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

            FlipVertically(); // ↑V
            RotateAQuarterToTheRight();
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

            FlipVertically();
            RotateAQuarterToTheRight();
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

        private void GetIdFromData() =>
            Id = int.Parse(_data.Replace("\n", string.Empty).Split(":")[0].Replace("Tile ", string.Empty));

        private void GetImageFromData() =>
            Image = _data.Replace("\n", string.Empty).Split(":")[1];

        private void GetBordersFromImage()
        {
            Top = Image[0..Size];
            Right = new string(Image.Where((_, i) => (i + 1) % Size == 0).ToArray());
            Bottom = Image[((Size * Size) - Size)..(Size*Size)];
            Left = new string(Image.Where((_, i) => i % Size == 0).ToArray());
        }

        private void RotateAQuarterToTheRight()
        {
            var newImage = new char[Size*Size];

            for (var y = 0; y < Size; y++)
            {
                for (var x = 0; x < Size; x++)
                {
                    newImage[((x + 1) * Size) - (y + 1)] = Image[(y * Size) + x];
                }
            }

            Image = new string(newImage);
            GetBordersFromImage();

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

        public void RotateLeft(int degrees)
        {
            switch (degrees)
            {
                case 90: RotateRight(270); break;
                case 180: RotateRight(180); break;
                case 270: RotateRight(90); break;
            }
        }

        public bool IsAdjacentOf(Tile adjacentTile)
        {
            var sameSides = GetBorders().Join(adjacentTile.GetBorders(),
                p => p,
                q => q,
                (r, s) => r == s).Count();

            return sameSides > 0;
        }

        private List<string> GetBorders() => new() { Top, Right, Bottom, Left };

        public void FlipHorizontally()
        {
            var newImage = new char[Size*Size];

            for (var y = 0; y < Size; y++)
            {
                for (var x = 0; x < Size; x++)
                {
                    newImage[((Size - 1 - y) * Size) + x] = Image[(y * Size) + x];
                }
            }

            Image = new string(newImage);
            GetBordersFromImage();

            Position ^= CurrentPosition.FlippedHorizontally;
        }

        public void FlipVertically()
        {
             var newImage = new char[Size*Size];

            for (var y = 0; y < Size; y++)
            {
                for (var x = 0; x < Size; x++)
                {
                    newImage[(y * Size) + (Size - 1 - x)] = Image[(y * Size) + x];
                }
            }

            Image = new string(newImage);
            GetBordersFromImage();

            Position ^= CurrentPosition.FlippedVertically;
        }

        public bool CouldBeAdjacentOf(Tile possibleAdjacentTile)
        {
            var sameSides = _borders.Join(possibleAdjacentTile._borders,
                p => p,
                q => q,
                (r, s) => r == s).Count();

            return sameSides > 0;
        }
    }
}
