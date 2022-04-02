using System;

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

        public void OnePlayerTurn()
        {
            var currentThrow = ThrowDice();

            AdvanceCurrentPlayerPawnBy(currentThrow);
            UpdateCurrentPlayerScore();
            NextPlayer();
        }

        private void AdvanceCurrentPlayerPawnBy(int steps)
        {
            var step = _players[_currentPlayer] + (steps % 10);
            _players[_currentPlayer] = (step >= 11) ? step % 10 : step;
        }

        private void UpdateCurrentPlayerScore() =>
            _scores[_currentPlayer] += _players[_currentPlayer];

        private int ThrowDice()
        {
            var sum = 0;

            for (var index = 0; index < 3; index++)
            {
                _dice = (_dice + 1 > 100) ? 1 : _dice + 1;
                _diceThrows++;
                sum += _dice;
            }

            return sum;
        }

        private void NextPlayer() => _currentPlayer = (_currentPlayer + 1) % 2;

        public int GetScoreFor(int player) => _scores[player];

        public void PlayGame()
        {
            while (! GameHasEnded())
            {
                OnePlayerTurn();
            }

            NumberOfDiceThrowsTimesLoserScore = _diceThrows * ((_scores[0] >= 1000) ? _scores[1] : _scores[0]);
        }

        private bool GameHasEnded() =>
            _scores[0] >= 1000 || _scores[1] >= 1000;
    }
}