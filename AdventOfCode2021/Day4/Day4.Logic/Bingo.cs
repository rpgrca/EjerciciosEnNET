using System.Linq;
using System;
using System.Collections.Generic;

namespace Day4.Logic
{
    public class Bingo
    {
        public List<int[,]> Boards { get; set; }
        public int FinalScore { get; private set; }

        public Bingo(string boards)
        {
            if (string.IsNullOrWhiteSpace(boards))
            {
                throw new ArgumentException("Invalid boards");
            }

            FinalScore = -1;
            Boards = new List<int[,]>();

            var board = CreateBoard();
            var y = 0;
            foreach (var line in boards.Split("\n"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    Boards.Add(board);
                    board = CreateBoard();
                    y = 0;
                }
                else
                {
                    var x = 0;
                    foreach (var number in line.Split(" ").Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => int.Parse(p)))
                    {
                        board[y, x++] = number;
                    }

                    y++;
                }
            }

            Boards.Add(board);
        }

        private static int[,] CreateBoard() =>
            new int[5,5]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };

        public void Play(string drawnNumbers)
        {
            foreach (var number in drawnNumbers.Split(",").Select(p => int.Parse(p)))
            {
               foreach (var board in Boards)
                {
                    MarkNumberInBoard(board, number);
                    if (FinalScore != -1)
                    {
                        return;
                    }
                }
            }
        }

        private void MarkNumberInBoard(int[,] board, int number)
        {
            for (var y = 0; y < 5; y++)
            {
                for (var x = 0; x < 5; x++)
                {
                    if (board[y, x] == number)
                    {
                        board[y, x] = -1;

                        if (CheckForWinningCombination(board, x, y))
                        {
                            var sum = GetSumOfUnmarkedNumbers(board);
                            FinalScore = sum * number;
                        }

                        return;
                    }
                }
            }
        }

        private static bool CheckForWinningCombination(int [,] board, int x, int y) =>
            (board[y, 0] < 0 && board[y, 1] < 0 && board[y, 2] < 0 && board[y, 3] < 0 && board[y, 4] < 0) ||
            (board[0, x] < 0 && board[1, x] < 0 && board[2, x] < 0 && board[3, x] < 0 && board[4, x] < 0);

        private static bool LineIsComplete(List<int> line) => line.All(p => p < 0);

        private bool HasAnyVerticalLineComplete(List<List<int>> board)
        {
            for (var index = 0; index < 5; index++)
            {
                var hasUnmarkedNumber = false;

                foreach (var line in board)
                {
                    if (line[index] >= 0)
                    {
                        hasUnmarkedNumber = true;
                        break;
                    }
                }

                if (! hasUnmarkedNumber)
                {
                    return true;
                }
            }

            return false;
        }

        private static int GetSumOfUnmarkedNumbers(int[,] board)
        {
            var sum = 0;
            foreach (var line in board)
            {
                if (line > -1)
                {
                    sum += line;
                }
            }

            return sum;
        }

        public void PlayForLosing(string drawnNumbers)
        {
            var winningBoards = new List<int[,]>();

            foreach (var number in drawnNumbers.Split(",").Select(p => int.Parse(p)))
            {
               foreach (var board in Boards)
                {
                    for (var y = 0; y < 5; y++)
                    {
                        for (var x = 0; x < 5; x++)
                        {
                            if (board[y, x] == number)
                            {
                                board[y, x] = -1;

                                if (CheckForWinningCombination(board, x, y))
                                {
                                    if (! winningBoards.Contains(board))
                                    {
                                        winningBoards.Add(board);
                                        if (winningBoards.Count == Boards.Count)
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
                }
            }
        }
    }
}