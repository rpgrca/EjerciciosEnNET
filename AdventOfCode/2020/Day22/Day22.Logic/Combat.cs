using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day22.Logic
{
    public class Combat
    {
        protected const int FIRST_PLAYER = 0;
        protected const int SECOND_PLAYER = 1;

        private readonly string _decks;
        protected (int, int) _lastPlayedCards;

        public List<int>[] Players { get; }
        public long WinnerPoints { get; private set; }

        public Combat(string decks)
        {
            _decks = decks;
            Players = new List<int>[2];

            ParseDecks();
        }

        protected Combat(int[] playerOne, int[] playerTwo)
        {
            Players = new List<int>[2];
            Players[FIRST_PLAYER] = playerOne.ToList();
            Players[SECOND_PLAYER] = playerTwo.ToList();
            _decks = string.Empty;
        }

        private void ParseDecks()
        {
            LoadPlayerDeck(_decks.Split("\n\n")[0]);
            LoadPlayerDeck(_decks.Split("\n\n")[1]);
        }

        private void LoadPlayerDeck(string deck)
        {
            var playerNumber = int.Parse(deck.Split(":")[0].Replace("Player ", string.Empty)) - 1;
            Players[playerNumber] = deck
                .Split(":\n")[1]
                .Split("\n")
                .Select(p => int.Parse(p))
                .ToList();
        }

        public void Play()
        {
            while (GameCanContinue())
            {
                PlayTurn();
            }
        }

        private bool GameCanContinue() =>
            Players[FIRST_PLAYER].Count > 0 && Players[SECOND_PLAYER].Count > 0;

        public virtual void PlayTurn()
        {
            DealCards();
            PlayerWithHighestCardWins();
        }

        protected void DealCards()
        {
            _lastPlayedCards = (Players[FIRST_PLAYER][0], Players[SECOND_PLAYER][0]);

            Players[FIRST_PLAYER].Remove(_lastPlayedCards.Item1);
            Players[SECOND_PLAYER].Remove(_lastPlayedCards.Item2);
        }

        protected void PlayerWithHighestCardWins() =>
            CardFromFirstPlayerBeatsCardFromSecondPlayer(PlayerOneWinsRound, PlayerTwoWinsRound);

        private void CardFromFirstPlayerBeatsCardFromSecondPlayer(Action whenPlayerOneBeatsPlayerTwo, Action whenPlayerTwoBeatsPlayerOne)
        {
            if (_lastPlayedCards.Item1 > _lastPlayedCards.Item2)
            {
                whenPlayerOneBeatsPlayerTwo();
            }
            else
            {
                whenPlayerTwoBeatsPlayerOne();
            }
        }

        protected void PlayerOneWinsRound()
        {
            Players[FIRST_PLAYER].Add(_lastPlayedCards.Item1);
            Players[FIRST_PLAYER].Add(_lastPlayedCards.Item2);
        }

        protected void PlayerTwoWinsRound()
        {
            Players[SECOND_PLAYER].Add(_lastPlayedCards.Item2);
            Players[SECOND_PLAYER].Add(_lastPlayedCards.Item1);
        }

        public void PlayTurns(int turns)
        {
            for (var index = 0; index < turns; index++)
            {
                PlayTurn();
            }
        }

        public void CalculatePointsForWinner()
        {
            var winnersDeck = GetWinnersDeck();

            WinnerPoints = 0;
            for (var i = 1; i <= winnersDeck.Count; i++)
            {
                WinnerPoints += i * winnersDeck[^i];
            }
        }

        private List<int> GetWinnersDeck() =>
            Players[FIRST_PLAYER].Count == 0
                ? Players[SECOND_PLAYER]
                : Players[FIRST_PLAYER];
    }
}