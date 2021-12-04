using System.Linq;
using System;
using System.Collections.Generic;

namespace Day4.Logic
{
    public class Bingo
    {
        private readonly string _boardInformation;
        private readonly List<int[]> _winningBoards;
        private readonly List<int[]> _boards;
        private int[] _currentBoard;

        public int FinalScore { get; private set; }

        public Bingo(string boards)
        {
            if (string.IsNullOrWhiteSpace(boards))
            {
                throw new ArgumentException("Invalid boards");
            }

            _boardInformation = boards;
            _winningBoards = new List<int[]>();
            _boards = new List<int[]>();

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
            foreach (var number in drawnNumbers.Split(",").Select(p => int.Parse(p)))
            {
                if (MarkNumberInEveryBoardUntilWinnerIsFound(number))
                {
                    break;
                }
            }
        }

        private bool MarkNumberInEveryBoardUntilWinnerIsFound(int number)
        {
            foreach (var board in _boards)
            {
                SetCurrentBoardTo(board);
                MarkNumberInCurrentBoard(number);
                if (FinalScore != -1)
                {
                    return true;
                }
            }

            return false;
        }

        private void SetCurrentBoardTo(int[] board) => _currentBoard = board;

        private void MarkNumberInCurrentBoard(int number)
        {
            var index = Array.IndexOf(_currentBoard, number);
            if (index != -1)
            {
                _currentBoard[index] = -1;

                if (CheckIfCurrentBoardWins(index))
                {
                    var sum = GetSumOfUnmarkedNumbers(_currentBoard);
                    FinalScore = sum * number;
                }
            }
        }

        private bool CheckIfCurrentBoardWins(int x)
        {
            var h = Math.DivRem(x, 5, out var w);
            return (_currentBoard[(h * 5) + 0] < 0 && _currentBoard[(h * 5) + 1] < 0 && _currentBoard[(h * 5) + 2] < 0 && _currentBoard[(h * 5) + 3] < 0 && _currentBoard[(h * 5) + 4] < 0) ||
                   (_currentBoard[w] < 0 && _currentBoard[5 + w] < 0 && _currentBoard[10 + w] < 0 && _currentBoard[15 + w] < 0 && _currentBoard[20 + w] < 0);
        }

        private static int GetSumOfUnmarkedNumbers(int[] board) => board.Where(p => p > 0).Sum();

        public void PlayForLosing(string drawnNumbers)
        {
            foreach (var number in drawnNumbers.Split(",").Select(p => int.Parse(p)))
            {
               foreach (var board in _boards.Except(_winningBoards))
                {
                    _currentBoard = board;
                    var index = Array.IndexOf(board, number);
                    if (index != -1)
                    {
                        board[index] = -1;

                        if (CheckIfCurrentBoardWins(index))
                        {
                            _winningBoards.Add(board);
                            if (_winningBoards.Count == _boards.Count)
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

        public bool DoesBoardContainAtPosition(int boardId, int x, int value) => _boards[boardId][x] == value;
    }
}