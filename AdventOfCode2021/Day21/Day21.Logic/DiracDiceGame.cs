using System;

namespace Day21.Logic
{
    public class DiracDiceGame
    {
        private readonly int[] _players = { 0, 0 };
        private readonly int[] _scores = { 0, 0 };
        private int _currentPlayer;
        private int _dice;

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
            var newPosition = _players[_currentPlayer] + currentThrow;
            _players[_currentPlayer] = newPosition > 10 ? newPosition % 10 : newPosition;
            _scores[_currentPlayer] += _players[_currentPlayer];

            NextPlayer();
        }

        private int ThrowDiceWith(int faces)
        {
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
    }
}
