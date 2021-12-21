using System;
using System.Collections.Generic;
using System.Linq;

namespace Day21.Logic
{
    public class DiracDiceRealGame
    {
        public long TotalUniverses { get; private set; }
        private int _currentPlayer;
        private readonly Dictionary<int, Dictionary<int, long>> _xyz;

        public DiracDiceRealGame(int player1position, int player2position)
        {
            ValidatePlayerPosition(player1position);
            ValidatePlayerPosition(player2position);

            TotalUniverses = 1;

            _xyz = new Dictionary<int, Dictionary<int, long>>();

            for (var position1 = 1; position1 <= 10; position1++)
            {
                for (var position2 = 1; position2 <= 10; position2++)
                {
                    _xyz.Add(GetKey(position1, position2), new Dictionary<int, long>());

                    for (var score1 = 0; score1 <= 21; score1++)
                    {
                        for (var score2 = 0; score2 <= 21; score2++)
                        {
                            _xyz[GetKey(position1, position2)].Add(GetKey(score1, score2), 0);
                        }
                    }
                }
            }

            _xyz[GetKey(player1position, player2position)][GetKey(0, 0)]++;
        }

        private static int GetKey(int player1, int player2) => player1 << 8 | player2;

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

        public long UniversesWithPlayersAtPosition(int position1, int position2)
        {
            ValidatePlayerPosition(position1);
            ValidatePlayerPosition(position2);

            var sum = 0L;
            foreach (var score in _xyz[GetKey(position1, position2)])
            {
                sum += score.Value;
            }

            return sum;
        }

        private static int ExtractPositionFromKeyForPlayer(int key, int player)
        {
            ValidatePlayer(player);
            return (player == 0) ? key & 0xff : key >> 8;
        }

        public long UniversesWithPlayersWithScores(int scorePlayer1, int scorePlayer2) => _xyz
                .Select(p => p.Value)
                .Select(p => p[GetKey(scorePlayer1, scorePlayer2)])
                .Sum(p => p);

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