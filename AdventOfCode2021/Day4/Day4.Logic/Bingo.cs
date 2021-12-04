using System;
using System.Collections.Generic;
namespace Day4.Logic
{
    public class Bingo
    {
        private readonly string _boards;

        public List<List<int>> Boards { get; set; }

        public Bingo(string boards)
        {
            if (string.IsNullOrWhiteSpace(boards))
            {
                throw new ArgumentException("Invalid boards");
            }

            _boards = boards;

            Boards = new List<List<int>>()
            {
                new() { 22, 13, 17, 11, 0 },
                new() { 8, 2, 23, 4, 24 },
                new() { 21, 9, 14, 16, 7 },
                new() { 6, 10, 3, 18, 5 },
                new() { 1, 12, 20, 15, 19 }
            };
        }
    }
}