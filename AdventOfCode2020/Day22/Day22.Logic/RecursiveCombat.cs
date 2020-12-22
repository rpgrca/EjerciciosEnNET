using System.Collections.Generic;

namespace AdventOfCode2020.Day22.Logic
{
    public class RecursiveCombat : Combat
    {
        private readonly HashSet<string> _previousTurns;

        public RecursiveCombat(string decks) : base(decks) =>
            _previousTurns = new HashSet<string>();

        private RecursiveCombat(int[] playerOne, int[] playerTwo)
            : base(playerOne, playerTwo) =>
            _previousTurns = new HashSet<string>();

        public override void PlayTurn()
        {
            if (HasThisGameOccurredBefore())
            {
                SecondPlayerLosesTheGame();
            }
            else
            {
                RecordThisGameConfiguration();
                DealCards();

                if (BothPlayersHaveEnoughCardsForMinigame())
                {
                    PlayMinigame();
                }
                else
                {
                    PlayerWithHighestCardWins();
                }
            }
        }

        private bool HasThisGameOccurredBefore()
        {
            var firstPlayer = string.Join("-", Players[FIRST_PLAYER]);
            var secondPlayer = string.Join("-", Players[SECOND_PLAYER]);
            var gameConfiguration = string.Concat(firstPlayer, "|", secondPlayer);

            return _previousTurns.Contains(gameConfiguration);
        }

        private void SecondPlayerLosesTheGame() =>
            Players[SECOND_PLAYER].Clear();

        private void RecordThisGameConfiguration()
        {
            var firstPlayer = string.Join("-", Players[FIRST_PLAYER]);
            var secondPlayer = string.Join("-", Players[SECOND_PLAYER]);
            var gameConfiguration = string.Concat(firstPlayer, "|", secondPlayer);
            _previousTurns.Add(gameConfiguration);
        }

        private bool BothPlayersHaveEnoughCardsForMinigame() =>
            Players[FIRST_PLAYER].Count >= _lastPlayedCards.Item1 && Players[SECOND_PLAYER].Count >= _lastPlayedCards.Item2;

        private void PlayMinigame()
        {
            var recursiveGame = new RecursiveCombat(Players[FIRST_PLAYER].ToArray()[0.._lastPlayedCards.Item1],
                                       Players[SECOND_PLAYER].ToArray()[0.._lastPlayedCards.Item2]);

            recursiveGame.Play();
            if (recursiveGame.HasPlayerOneWon())
            {
                PlayerOneWinsRound();
            }
            else
            {
                PlayerTwoWinsRound();
            }
        }

        private bool HasPlayerOneWon() => Players[SECOND_PLAYER].Count == 0;
    }
}