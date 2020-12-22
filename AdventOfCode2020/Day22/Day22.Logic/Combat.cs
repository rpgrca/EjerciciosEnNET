using System.Linq;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day22.Logic
{
    public class Combat
    {
        private const int FIRST_PLAYER = 0;
        private const int SECOND_PLAYER = 1;

        private readonly string _decks;
        private readonly HashSet<string> _previousTurns;
        private (int, int) _lastPlayedCards;

        public List<int>[] Players { get; }
        public long WinnerPoints { get; private set; }

        public Combat(string decks)
        {
            _decks = decks;
            _previousTurns = new HashSet<string>();
            Players = new List<int>[2];

            ParseDecks();
        }

        public Combat(int[] playerOne, int[] playerTwo)
        {
            _previousTurns = new HashSet<string>();
            Players = new List<int>[2];
            Players[FIRST_PLAYER] = playerOne.ToList();
            Players[SECOND_PLAYER] = playerTwo.ToList();
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

        public void PlayTurn()
        {
            _lastPlayedCards = (Players[FIRST_PLAYER][0], Players[SECOND_PLAYER][0]);

            Players[FIRST_PLAYER].Remove(_lastPlayedCards.Item1);
            Players[SECOND_PLAYER].Remove(_lastPlayedCards.Item2);

            PlayerWithHighestCardWins();
        }

        private void PlayerWithHighestCardWins()
        {
            if (_lastPlayedCards.Item1 > _lastPlayedCards.Item2)
            {
                Players[FIRST_PLAYER].Add(_lastPlayedCards.Item1);
                Players[FIRST_PLAYER].Add(_lastPlayedCards.Item2);
            }
            else
            {
                Players[SECOND_PLAYER].Add(_lastPlayedCards.Item2);
                Players[SECOND_PLAYER].Add(_lastPlayedCards.Item1);
            }
        }

        public void PlayTurns(int turns)
        {
            for (var index = 0; index < turns; index++)
            {
                PlayTurn();
            }
        }

        public void CalculatePoints()
        {
            var winnersDeck = Players[FIRST_PLAYER].Count == 0
                ? Players[SECOND_PLAYER]
                : Players[FIRST_PLAYER];

            WinnerPoints = 0;
            for (var i = 1; i <= winnersDeck.Count; i++)
            {
                WinnerPoints += i * winnersDeck[^i];
            }
        }

        public void PlayGame()
        {
            while (Players[FIRST_PLAYER].Count > 0 && Players[SECOND_PLAYER].Count > 0)
            {
                PlayTurn();
            }
        }

        public void PlayRecursiveTurn()
        {
            if (HasThisGameOccurredBefore())
            {
                Players[SECOND_PLAYER].Clear();
            }
            else
            {
                RecordThisGame();

                _lastPlayedCards = (Players[FIRST_PLAYER][0], Players[SECOND_PLAYER][0]);
                Players[FIRST_PLAYER].Remove(_lastPlayedCards.Item1);
                Players[SECOND_PLAYER].Remove(_lastPlayedCards.Item2);

                if (Players[FIRST_PLAYER].Count >= _lastPlayedCards.Item1 && Players[SECOND_PLAYER].Count >= _lastPlayedCards.Item2)
                {
                    var recursiveGame = new Combat(
                        Players[FIRST_PLAYER].ToArray()[0.._lastPlayedCards.Item1],
                        Players[SECOND_PLAYER].ToArray()[0.._lastPlayedCards.Item2]);
                    recursiveGame.PlayRecursiveGame();

                    if (recursiveGame.Players[FIRST_PLAYER].Count == 0)
                    {
                        Players[SECOND_PLAYER].Add(_lastPlayedCards.Item2);
                        Players[SECOND_PLAYER].Add(_lastPlayedCards.Item1);
                    }
                    else
                    {
                        Players[FIRST_PLAYER].Add(_lastPlayedCards.Item1);
                        Players[FIRST_PLAYER].Add(_lastPlayedCards.Item2);
                    }
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

        private void RecordThisGame()
        {
            var firstPlayer = string.Join("-", Players[FIRST_PLAYER]);
            var secondPlayer = string.Join("-", Players[SECOND_PLAYER]);
            var gameConfiguration = string.Concat(firstPlayer, "|", secondPlayer);
            _previousTurns.Add(gameConfiguration);
        }

        public void PlayRecursiveGame()
        {
            while (Players[FIRST_PLAYER].Count > 0 && Players[SECOND_PLAYER].Count > 0)
            {
                PlayRecursiveTurn();
            }
        }

        public void PlayRecursiveTurns(int turns)
        {
            for (var index = 0; index < turns; index++)
            {
                PlayRecursiveTurn();
            }
        }
    }
}