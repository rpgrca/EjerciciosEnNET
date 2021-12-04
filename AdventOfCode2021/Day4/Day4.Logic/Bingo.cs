using System.Linq;
using System;
using System.Collections.Generic;
namespace Day4.Logic
{
    public class Bingo
    {
        public List<List<List<int>>> Boards { get; set; }
        public int FinalScore { get; private set; }

        public Bingo(string boards)
        {
            if (string.IsNullOrWhiteSpace(boards))
            {
                throw new ArgumentException("Invalid boards");
            }

            FinalScore = -1;
            Boards = new List<List<List<int>>>();
            var board = new List<List<int>>();
            foreach (var line in boards.Split("\n"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    Boards.Add(board);
                    board = new List<List<int>>();
                }
                else
                {
                    board.Add(new List<int>(line.Split(" ").Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => int.Parse(p))));
                }
            }

            Boards.Add(board);
        }

        public void Play(string drawnNumbers)
        {
            foreach (var number in drawnNumbers.Split(",").Select(p => int.Parse(p)))
            {
               foreach (var board in Boards)
                {
                    foreach (var line in board)
                    {
                        if (line.Contains(number))
                        {
                            line[line.IndexOf(number)] = -number;

                            if (line.All(p => p < 0))
                            {
                                var sum = GetSumOfUnmarkedNumbers(board);
                                FinalScore = sum * number;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private int GetSumOfUnmarkedNumbers(List<List<int>> board)
        {
            var sum = 0;
            foreach (var line in board)
            {
                sum += line.Where(p => p > 0).Sum();
            }

            return sum;
        }
    }
}