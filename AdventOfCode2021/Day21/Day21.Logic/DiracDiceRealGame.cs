using System;
using System.Collections.Generic;
using System.Linq;

namespace Day21.Logic
{
    public class DiracDiceRealGame
    {
        public long TotalUniverses { get; private set; }
        private int _currentPlayer;
        private Dictionary<int, long> _xyz;
        private readonly List<int> _positionsWithUniverses;

        public DiracDiceRealGame(int player1position, int player2position)
        {
            ValidatePlayerPosition(player1position);
            ValidatePlayerPosition(player2position);

            _positionsWithUniverses = new List<int>();

            _xyz = new Dictionary<int, long>();
            for (var position1 = 1; position1 <= 10; position1++)
            {
                for (var position2 = 1; position2 <= 10; position2++)
                {
                    for (var score1 = 0; score1 <= 21; score1++)
                    {
                        for (var score2 = 0; score2 <= 21; score2++)
                        {
                            _xyz.Add(GetKey(position1, position2, score1, score2), 0);
                        }
                    }
                }
            }

            TotalUniverses = 0;
            _xyz[GetKey(player1position, player2position, 0, 0)]++;
        }

        private static int GetKey(int player1, int player2, int score1, int score2) =>
            player1 << 24 | player2 << 16 | score1 << 8 | score2;

        private static void ValidatePlayerPosition(int position)
        {
            if (position < 1 || position > 10)
            {
                throw new ArgumentException("Invalid player position");
            }
        }

        private static void ValidatePlayer(int player)
        {
            if (player < 0 || player > 1)
            {
                throw new ArgumentException("Invalid player");
            }
        }

        public long UniversesWithPlayersAtPositionWithScore(int position1, int position2, int score1, int score2)
        {
            ValidatePlayerPosition(position1);
            ValidatePlayerPosition(position2);

            return _xyz[GetKey(position1, position2, score1, score2)];
        }

        public void ThrowDice()
        {
            var throws = TripleThrow();

            var xyz = new Dictionary<int, long>();
            foreach (var (key, value) in _xyz.Where(p => p.Value > 0))
            {
                var (position1, position2, score1, score2) = SplitKey(key);
                ValidatePlayerPosition(position1);
                ValidatePlayerPosition(position2);

                if (_currentPlayer == 0)
                {
                    foreach (var diceThrow in throws)
                    {
                        var newPosition = (position1 + diceThrow.Roll) switch
                        {
                            var x when x >= 0 && x <= 10 => x,
                            11 => 1,
                            12 => 2,
                            13 => 3
                        };

                        var newPosition1 = position1 + newPosition;
                        var newScore1 = score1 + newPosition1;
                        xyz.TryAdd(GetKey(newPosition1, position2, newScore1, score2), 0);
                        xyz[GetKey(newPosition1, position2, newScore1, score2)] += value + diceThrow.Universes;

                        TotalUniverses += diceThrow.Universes;
                    }
                }
            }

            _xyz = xyz;

            NextPlayer();
        }

        private static (int, int, int, int) SplitKey(int key) =>
            (key >> 24, (key >> 16) & 0xff, (key >> 8) & 0xff, key & 0xff);

        private static List<(int Roll, long Universes)> TripleThrow() =>
            new() { (3, 1), (4, 3), (5, 6), (6, 7), (7, 6), (8, 3), (9, 1) };

        private void NextPlayer() => _currentPlayer = (_currentPlayer + 1) % 2;

        /*

                        1                                  2                                       3
                       /|\                                /|\                                     /|\
                      / | \                              / | \                                   / | \
                     /  |  \                            /  |  \                                 /  |  \
                    /   |   \                          /   |   \                               /   |   \
                   /    |    \                        /    |    \                             /    |    \ 
                  /     |     \                      /     |     \                           /     |     \
                 /      |      \                    /      |      \                         /      |      \  
                1       2       3                  1       2       3                       1       2       3 
               /|\     /|\     /|\                /|\     /|\     /|\                     /|\     /|\     /|\
              / | \   / | \   / | \              / | \   / | \   / | \                   / | \   / | \   / | \ 
             1  2  3 1  2  3 1  2  3            1  2  3 1  2  3 1  2  3                 1  2  3 1  2  3 1  2  3

             3  4  5 4  5  6 5  6  7            4  5  6 5  6  7 6  7  8                 5  6  7 6  7  8 7  8  9


             3 = 1 
             4 = 3
             5 = 6
             6 = 7
             7 = 6
             8 = 3
             9 = 1
*/
    }
}