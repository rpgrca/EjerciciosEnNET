using System.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2020.Day22.UnitTests
{
    public class CombatMust
    {
        [Fact]
        public void CorrectlyLoadCardsFromDeck()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(9, p1),
                p2 => Assert.Equal(2, p2),
                p3 => Assert.Equal(6, p3),
                p4 => Assert.Equal(3, p4),
                p5 => Assert.Equal(1, p5));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(5, p1),
                p2 => Assert.Equal(8, p2),
                p3 => Assert.Equal(4, p3),
                p4 => Assert.Equal(7, p4),
                p5 => Assert.Equal(10, p5));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingATurn()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);

            sut.PlayTurn();
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(2, p1),
                p2 => Assert.Equal(6, p2),
                p3 => Assert.Equal(3, p3),
                p4 => Assert.Equal(1, p4),
                p5 => Assert.Equal(9, p5),
                p6 => Assert.Equal(5, p6));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(8, p1),
                p2 => Assert.Equal(4, p2),
                p3 => Assert.Equal(7, p3),
                p4 => Assert.Equal(10, p4));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingTwoTurns()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);

            sut.PlayTurn();
            sut.PlayTurn();
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(6, p1),
                p2 => Assert.Equal(3, p2),
                p3 => Assert.Equal(1, p3),
                p4 => Assert.Equal(9, p4),
                p5 => Assert.Equal(5, p5));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(4, p1),
                p2 => Assert.Equal(7, p2),
                p3 => Assert.Equal(10, p3),
                p4 => Assert.Equal(8, p4),
                p5 => Assert.Equal(2, p5));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingThreeTurns()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);

            sut.PlayTurn();
            sut.PlayTurn();
            sut.PlayTurn();
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(3, p1),
                p2 => Assert.Equal(1, p2),
                p3 => Assert.Equal(9, p3),
                p4 => Assert.Equal(5, p4),
                p5 => Assert.Equal(6, p5),
                p6 => Assert.Equal(4, p6));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(7, p1),
                p2 => Assert.Equal(10, p2),
                p3 => Assert.Equal(8, p3),
                p4 => Assert.Equal(2, p4));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingFourTurns()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);

            sut.PlayTurns(4);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(1, p1),
                p2 => Assert.Equal(9, p2),
                p3 => Assert.Equal(5, p3),
                p4 => Assert.Equal(6, p4),
                p5 => Assert.Equal(4, p5));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(10, p1),
                p2 => Assert.Equal(8, p2),
                p3 => Assert.Equal(2, p3),
                p4 => Assert.Equal(7, p4),
                p5 => Assert.Equal(3, p5));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingFiveTurns()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);

            sut.PlayTurns(5);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(9, p1),
                p2 => Assert.Equal(5, p2),
                p3 => Assert.Equal(6, p3),
                p4 => Assert.Equal(4, p4));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(8, p1),
                p2 => Assert.Equal(2, p2),
                p3 => Assert.Equal(7, p3),
                p4 => Assert.Equal(3, p4),
                p5 => Assert.Equal(10, p5),
                p6 => Assert.Equal(1, p6));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlaying26Turns()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);

            sut.PlayTurns(26);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(5, p1),
                p2 => Assert.Equal(4, p2),
                p3 => Assert.Equal(1, p3));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(8, p1),
                p2 => Assert.Equal(9, p2),
                p3 => Assert.Equal(7, p3),
                p4 => Assert.Equal(3, p4),
                p5 => Assert.Equal(2, p5),
                p6 => Assert.Equal(10, p6),
                p7 => Assert.Equal(6, p7));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlaying27Turns()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);

            sut.PlayTurns(27);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(4, p1),
                p2 => Assert.Equal(1, p2));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(9, p1),
                p2 => Assert.Equal(7, p2),
                p3 => Assert.Equal(3, p3),
                p4 => Assert.Equal(2, p4),
                p5 => Assert.Equal(10, p5),
                p6 => Assert.Equal(6, p6),
                p7 => Assert.Equal(8, p7),
                p8 => Assert.Equal(5, p8));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlaying28Turns()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);

            sut.PlayTurns(28);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(1, p1));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(7, p1),
                p2 => Assert.Equal(3, p2),
                p3 => Assert.Equal(2, p3),
                p4 => Assert.Equal(10, p4),
                p5 => Assert.Equal(6, p5),
                p6 => Assert.Equal(8, p6),
                p7 => Assert.Equal(5, p7),
                p8 => Assert.Equal(9, p8),
                p9 => Assert.Equal(4, p9));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlaying29Turns()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);

            sut.PlayTurns(29);
            Assert.Empty(sut.Players[0]);
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(3, p1),
                p2 => Assert.Equal(2, p2),
                p3 => Assert.Equal(10, p3),
                p4 => Assert.Equal(6, p4),
                p5 => Assert.Equal(8, p5),
                p6 => Assert.Equal(5, p6),
                p7 => Assert.Equal(9, p7),
                p8 => Assert.Equal(4, p8),
                p9 => Assert.Equal(7, p9),
                p10 => Assert.Equal(1, p10));
        }

        [Fact]
        public void ReturnPoints_WhenCalculatingWinnerPointsAfterTheGame()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);

            sut.PlayTurns(29);
            sut.CalculatePoints();
            Assert.Equal(306, sut.WinnerPoints);
        }

        [Fact]
        public void PlayTheGameAutomatically()
        {
            const string decks = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var sut = new Combat(decks);

            sut.PlayGame();
            sut.CalculatePoints();
            Assert.Equal(306, sut.WinnerPoints);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            const string decks = @"Player 1:
42
29
12
40
47
26
11
39
41
13
8
50
44
33
5
27
10
25
17
1
28
22
6
32
35

Player 2:
19
34
38
21
43
14
23
46
16
3
36
31
37
45
30
15
49
48
24
9
2
18
4
7
20";

            var sut = new Combat(decks);

            sut.PlayGame();
            sut.CalculatePoints();
            Assert.Equal(32495, sut.WinnerPoints);
        }
    }

    public class Combat
    {
        private const int FIRST_PLAYER = 0;
        private const int SECOND_PLAYER = 1;

        private readonly string _decks;

        public List<int>[] Players { get; }
        public long WinnerPoints { get; private set; }

        public Combat(string decks)
        {
            _decks = decks;
            Players = new List<int>[2];

            ParseDecks();
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
            var playerOneCard = Players[FIRST_PLAYER][0];
            var playerTwoCard = Players[SECOND_PLAYER][0];

            Players[FIRST_PLAYER].Remove(playerOneCard);
            Players[SECOND_PLAYER].Remove(playerTwoCard);

            if (playerOneCard > playerTwoCard)
            {
                Players[FIRST_PLAYER].Add(playerOneCard);
                Players[FIRST_PLAYER].Add(playerTwoCard);
            }
            else
            {
                Players[SECOND_PLAYER].Add(playerTwoCard);
                Players[SECOND_PLAYER].Add(playerOneCard);
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
    }
}
