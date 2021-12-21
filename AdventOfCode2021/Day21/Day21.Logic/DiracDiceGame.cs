using System;
using System.Collections.Generic;

namespace Day21.Logic
{
    public class DiracDiceGame
    {
        private readonly int[] _players = { 0, 0 };
        private readonly int[] _scores = { 0, 0 };
        private int _currentPlayer;
        private int _dice;
        private int _diceThrows;

        public int NumberOfDiceThrowsTimesLoserScore { get; private set; }

        public DiracDiceGame(int player1position, int player2position)
        {
            if (player1position < 1 || player1position > 10 || player2position < 1 || player2position > 10)
            {
                throw new ArgumentException("Invalid data");
            }

            _players[0] = player1position;
            _players[1] = player2position;
            _currentPlayer = 0;
            _dice = 0;
        }

        public bool IsPlayerAt(int player, int position) => _players[player] == position;

        public void ThrowDice()
        {
            var currentThrow = ThrowDiceWith(100) + ThrowDiceWith(100) + ThrowDiceWith(100);
            var advance = currentThrow % 10;
            var newPosition = (_players[_currentPlayer] + advance) switch
            {
                2 => 2,
                3 => 3,
                4 => 4,
                5 => 5,
                6 => 6,
                7 => 7,
                8 => 8,
                9 => 9,
                10 => 10,
                11 => 1,
                12 => 2,
                13 => 3,
                14 => 4,
                15 => 5,
                16 => 6,
                17 => 7,
                18 => 8,
                19 => 9,
                _ => throw new ArgumentException("Invalid dice value")
            };
            _players[_currentPlayer] = newPosition;

            if (_players[_currentPlayer] < 1 || _players[_currentPlayer] > 10)
            {
                System.Diagnostics.Debugger.Break();
            }
            _scores[_currentPlayer] += _players[_currentPlayer];

            NextPlayer();
        }

        private int ThrowDiceWith(int faces)
        {
            _diceThrows++;

            if (_dice + 1 > faces)
            {
                _dice = 1;
            }
            else
            {
                _dice++;
            }

            return _dice;
        }

        private void NextPlayer() => _currentPlayer = (_currentPlayer + 1) % 2;

        public int GetScoreFor(int player) => _scores[player];

        public void PlayGame()
        {
            while (_scores[0] < 1000 && _scores[1] < 1000)
            {
                ThrowDice();
            }

            var loserScore = (_scores[0] >= 1000) ? _scores[1] : _scores[0];
            NumberOfDiceThrowsTimesLoserScore = _diceThrows * loserScore;
        }
    }

    public class DiracDiceRealGame
    {
        public long TotalUniverses { get; private set; }
        private readonly int[][] _positions;

        public DiracDiceRealGame(int player1position, int player2position)
        {
            TotalUniverses = 1;

            _positions = new int[2][]
            {
                new int[10],
                new int[10]
            };
            _positions[0][player1position - 1]++;
            _positions[1][player2position - 1]++;
        }

        public long UniversesWithPlayerAtPosition(int player, int position)
        {
            return _positions[player][position - 1];
        }
    }
}