using System.Collections.Generic;
using System.Linq;

namespace Day21.Logic
{
    public class DiracDiceRealGame
    {
        public long TotalUniverses { get; private set; }
        private int _currentPlayer;
        private Dictionary<int, long> _xyz;
        private readonly long[] _universesWonByPlayer = { 0, 0 };

        public DiracDiceRealGame(int player1position, int player2position)
        {
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

        public long UniversesWithPlayersAtPositionWithScore(int position1, int position2, int score1, int score2) =>
            _xyz[GetKey(position1, position2, score1, score2)];

        public void OnePlayerTurn()
        {
            var currentThrow = ThrowDice();

            AdvanceCurrentPlayerPawnBy(currentThrow);
            NextPlayer();
        }

        private void AdvanceCurrentPlayerPawnBy(List<(int Roll, long Universes)> currentThrow)
        {
            var xyz = new Dictionary<int, long>();
            foreach (var (key, value) in _xyz.Where(p => p.Value > 0))
            {
                var (position1, position2, score1, score2) = SplitKey(key);

                if (_currentPlayer == 0)
                {
                    foreach (var diceThrow in currentThrow)
                    {
                        var newPosition = CalculateNewPosition(position1, diceThrow);
                        var newScore1 = score1 + newPosition;
                        var universes = value * diceThrow.Universes;
                        if (newScore1 < 21)
                        {
                            AddToUniverses(newPosition, position2, newScore1, score2, xyz, universes);
                        }
                        else
                        {
                            AddToUniversesWhereThisPlayerWon(universes);
                        }
                    }
                }
                else
                {
                    foreach (var diceThrow in currentThrow)
                    {
                        var newPosition = CalculateNewPosition(position2, diceThrow);
                        var newScore2 = score2 + newPosition;
                        var universes = value * diceThrow.Universes;
                        if (newScore2 < 21)
                        {
                            AddToUniverses(position1, newPosition, score1, newScore2, xyz, universes);
                        }
                        else
                        {
                            AddToUniversesWhereThisPlayerWon(universes);
                        }
                    }
                }
            }

            _xyz = xyz;
            TotalUniverses = _xyz.Sum(p => p.Value);
        }

        private static int CalculateNewPosition(int position1, (int Roll, long _) diceThrow)
        {
            var x = position1 + diceThrow.Roll;
            if (x >= 1 && x <= 10) return x;
            return x % 10;
        }

        private void AddToUniversesWhereThisPlayerWon(long universes) =>
            _universesWonByPlayer[_currentPlayer] += universes;

        private static void AddToUniverses(int position1, int position2, int score1, int score2, Dictionary<int, long> xyz, long universes)
        {
            xyz.TryAdd(GetKey(position1, position2, score1, score2), 0);
            xyz[GetKey(position1, position2, score1, score2)] += universes;
        }

        private static (int, int, int, int) SplitKey(int key) =>
            (key >> 24, (key >> 16) & 0xff, (key >> 8) & 0xff, key & 0xff);

        private static List<(int Roll, long Universes)> ThrowDice() =>
            new() { (3, 1), (4, 3), (5, 6), (6, 7), (7, 6), (8, 3), (9, 1) };

        private void NextPlayer() => _currentPlayer = (_currentPlayer + 1) % 2;

        public void PlayGame()
        {
            while (! GameHasEnded())
            {
                OnePlayerTurn();
            }
        }

        private bool GameHasEnded() => _xyz.Count < 1;

        public long UniversesWonByPlayer(int player) => _universesWonByPlayer[player];
    }
}