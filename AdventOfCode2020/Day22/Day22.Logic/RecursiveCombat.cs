using System;
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
                BothPlayersHaveEnoughCardsForMinigame(PlayMinigame, PlayerWithHighestCardWins);
            }
        }

        private bool HasThisGameOccurredBefore() =>
            _previousTurns.Contains(GetGameConfiguration());

        private void SecondPlayerLosesTheGame() =>
            Players[SECOND_PLAYER].Clear();

        private void RecordThisGameConfiguration() =>
            _previousTurns.Add(GetGameConfiguration());

        private void BothPlayersHaveEnoughCardsForMinigame(Action whenTheyHave, Action whenTheyDont)
        {
            if (Players[FIRST_PLAYER].Count >= _lastPlayedCards.Item1 && Players[SECOND_PLAYER].Count >= _lastPlayedCards.Item2)
            {
                whenTheyHave();
            }
            else
            {
                whenTheyDont();
            }
        }

        private string GetGameConfiguration() =>
            $"{string.Join("-", Players[FIRST_PLAYER])}|{string.Join("-", Players[SECOND_PLAYER])}";

        private void PlayMinigame()
        {
            var recursiveGame = new RecursiveCombat(
                Players[FIRST_PLAYER].ToArray()[0.._lastPlayedCards.Item1],
                Players[SECOND_PLAYER].ToArray()[0.._lastPlayedCards.Item2]);

            recursiveGame.Play();
            recursiveGame.HasPlayerOneWon(PlayerOneWinsRound, PlayerTwoWinsRound);
        }

        private void HasPlayerOneWon(Action whenTheyHave, Action whenTheyHavent)
        {
            if (Players[SECOND_PLAYER].Count == 0)
            {
                whenTheyHave();
            }
            else
            {
                whenTheyHavent();
            }
        }
    }
}