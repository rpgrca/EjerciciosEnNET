using System;

namespace Day21.Logic
{
    public class DiracDiceGame
    {
        private readonly int _player1position;
        private readonly int _player2position;

        public DiracDiceGame(int player1position, int player2position)
        {
            if (player1position < 1 || player1position > 10 || player2position < 1 || player2position > 10)
            {
                throw new ArgumentException("Invalid data");
            }

            _player1position = player1position;
            _player2position = player2position;
        }

        public bool IsPlayer1At(int position) => _player1position == position;

        public bool IsPlayer2At(int position) => _player2position == position;
    }
}
