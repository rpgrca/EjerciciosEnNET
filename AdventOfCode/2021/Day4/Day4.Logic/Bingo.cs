using System.Linq;
using System;
using System.Collections.Generic;

namespace Day4.Logic
{
    public sealed class Bingo
    {
        private readonly string _boardInformation;
        private readonly List<int[]> _winningBoards;
        private readonly List<int[]> _boards;
        private int[] _currentBoard;

        private Func<List<int[]>, List<int[]>, bool> BoardFound { get; }
        public int FinalScore { get; private set; }

        public static Bingo CreateForBestSolution(string boards) => new(boards, (_, _) => true);

        public static Bingo CreateForWorstSolution(string boards) => new(boards, (b, w) => b.Count == w.Count);

        private Bingo(string boards, Func<List<int[]>, List<int[]>, bool> callback)
        {
            if (string.IsNullOrWhiteSpace(boards))
            {
                throw new ArgumentException("Invalid boards");
            }

            BoardFound = callback;
            _boardInformation = boards;
            _winningBoards = new List<int[]>();
            _boards = new List<int[]>();
            _currentBoard = Array.Empty<int>();

            FinalScore = -1;

            LoadBoards();
        }

        private void LoadBoards()
        {
            var numbers = new List<int>();
            foreach (var line in _boardInformation.Split("\n"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    _boards.Add(numbers.ToArray());
                    numbers.Clear();
                }
                else
                {
                    numbers.AddRange(line.Split(" ").Where(p => !string.IsNullOrWhiteSpace(p)).Select(int.Parse));
                }
            }

            _boards.Add(numbers.ToArray());
        }

        public void Play(string drawnNumbers)
        {
            if (string.IsNullOrWhiteSpace(drawnNumbers))
            {
                throw new ArgumentException("Invalid drawn numbers");
            }

            foreach (var number in drawnNumbers.Split(",").Select(p => int.Parse(p)))
            {
                foreach (var board in _boards.Except(_winningBoards))
                {
                    SetCurrentBoardTo(board);
                    var index = Array.IndexOf(_currentBoard, number);
                    if (index != -1)
                    {
                        _currentBoard[index] = -1;

                        if (CheckIfCurrentBoardWins(index))
                        {
                            _winningBoards.Add(_currentBoard);
                            if (BoardFound(_boards, _winningBoards))
                            {
                                CalculateFinalScoreWith(number);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void SetCurrentBoardTo(int[] board) => _currentBoard = board;

        private bool CheckIfCurrentBoardWins(int x)
        {
            var h = Math.DivRem(x, 5, out var w);
            return (_currentBoard[(h * 5) + 0] < 0 && _currentBoard[(h * 5) + 1] < 0 && _currentBoard[(h * 5) + 2] < 0 && _currentBoard[(h * 5) + 3] < 0 && _currentBoard[(h * 5) + 4] < 0) ||
                   (_currentBoard[w] < 0 && _currentBoard[5 + w] < 0 && _currentBoard[10 + w] < 0 && _currentBoard[15 + w] < 0 && _currentBoard[20 + w] < 0);
        }

        private void CalculateFinalScoreWith(int number) =>
            FinalScore = GetSumOfUnmarkedNumbersForCurrentBoard() * number;

        private int GetSumOfUnmarkedNumbersForCurrentBoard() =>
            _currentBoard.Where(p => p > 0).Sum();

        public bool DoesBoardContainAtPosition(int boardId, int x, int value) =>
            _boards[boardId][x] == value;
    }
}