using System;

namespace Day21.Logic
{
    public class DiracDiceGame
    {
        private readonly int _player1initialPosition;
        private readonly int _player2initialPosition;

        public DiracDiceGame(int player1initialPosition, int player2initialPosition)
        {
            if (player1initialPosition < 1 || player1initialPosition > 10 || player2initialPosition < 1 || player2initialPosition > 10)
            {
                throw new ArgumentException("Invalid data");
            }

            _player1initialPosition = player1initialPosition;
            _player2initialPosition = player2initialPosition;
        }
    }
}
