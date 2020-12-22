using Xunit;
using AdventOfCode2020.Day22.Logic;

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

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingARecursiveTurn()
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

            sut.PlayRecursiveTurn();
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
        public void CorrectlyModifyPlayerCards_AfterPlayingTwoRecursiveTurns()
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

            sut.PlayRecursiveTurn();
            sut.PlayRecursiveTurn();
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
        public void CorrectlyModifyPlayerCards_AfterPlayingThreeRecursiveTurns()
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

            sut.PlayRecursiveTurn();
            sut.PlayRecursiveTurn();
            sut.PlayRecursiveTurn();
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
        public void CorrectlyModifyPlayerCards_AfterPlayingFourRecursiveTurns()
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

            sut.PlayRecursiveTurns(4);
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
        public void CorrectlyModifyPlayerCards_AfterPlayingFiveRecursiveTurns()
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

            sut.PlayRecursiveTurns(5);
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
        public void CorrectlyModifyPlayerCards_AfterPlayingSixRecursiveTurns()
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

            sut.PlayRecursiveTurns(6);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(5, p1),
                p2 => Assert.Equal(6, p2),
                p3 => Assert.Equal(4, p3),
                p4 => Assert.Equal(9, p4),
                p5 => Assert.Equal(8, p5));
            Assert.Collection(sut.Players[1],
                p2 => Assert.Equal(2, p2),
                p3 => Assert.Equal(7, p3),
                p4 => Assert.Equal(3, p4),
                p5 => Assert.Equal(10, p5),
                p6 => Assert.Equal(1, p6));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingSevenRecursiveTurns()
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

            sut.PlayRecursiveTurns(7);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(6, p1),
                p2 => Assert.Equal(4, p2),
                p3 => Assert.Equal(9, p3),
                p4 => Assert.Equal(8, p4),
                p5 => Assert.Equal(5, p5),
                p6 => Assert.Equal(2, p6));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(7, p1),
                p2 => Assert.Equal(3, p2),
                p3 => Assert.Equal(10, p3),
                p4 => Assert.Equal(1, p4));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingEightRecursiveTurns()
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

            sut.PlayRecursiveTurns(8);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(4, p1),
                p2 => Assert.Equal(9, p2),
                p3 => Assert.Equal(8, p3),
                p4 => Assert.Equal(5, p4),
                p5 => Assert.Equal(2, p5));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(3, p1),
                p2 => Assert.Equal(10, p2),
                p3 => Assert.Equal(1, p3),
                p4 => Assert.Equal(7, p4),
                p5 => Assert.Equal(6, p5));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingNineRecursiveTurns()
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

            sut.PlayRecursiveTurns(9);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(9, p1),
                p2 => Assert.Equal(8, p2),
                p3 => Assert.Equal(5, p3),
                p4 => Assert.Equal(2, p4));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(10, p1),
                p2 => Assert.Equal(1, p2),
                p3 => Assert.Equal(7, p3),
                p4 => Assert.Equal(6, p4),
                p5 => Assert.Equal(3, p5),
                p6 => Assert.Equal(4, p6));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingTenRecursiveTurns()
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

            sut.PlayRecursiveTurns(10);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(8, p1),
                p2 => Assert.Equal(5, p2),
                p3 => Assert.Equal(2, p3));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(1, p1),
                p2 => Assert.Equal(7, p2),
                p3 => Assert.Equal(6, p3),
                p4 => Assert.Equal(3, p4),
                p5 => Assert.Equal(4, p5),
                p6 => Assert.Equal(10, p6),
                p7 => Assert.Equal(9, p7));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingElevenRecursiveTurns()
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

            sut.PlayRecursiveTurns(11);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(5, p1),
                p2 => Assert.Equal(2, p2),
                p3 => Assert.Equal(8, p3),
                p4 => Assert.Equal(1, p4));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(7, p1),
                p2 => Assert.Equal(6, p2),
                p3 => Assert.Equal(3, p3),
                p4 => Assert.Equal(4, p4),
                p5 => Assert.Equal(10, p5),
                p6 => Assert.Equal(9, p6));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingTwelveRecursiveTurns()
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

            sut.PlayRecursiveTurns(12);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(2, p1),
                p2 => Assert.Equal(8, p2),
                p3 => Assert.Equal(1, p3));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(6, p1),
                p2 => Assert.Equal(3, p2),
                p3 => Assert.Equal(4, p3),
                p4 => Assert.Equal(10, p4),
                p5 => Assert.Equal(9, p5),
                p6 => Assert.Equal(7, p6),
                p7 => Assert.Equal(5, p7));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingThirteenRecursiveTurns()
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

            sut.PlayRecursiveTurns(13);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(8, p1),
                p2 => Assert.Equal(1, p2));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(3, p1),
                p2 => Assert.Equal(4, p2),
                p3 => Assert.Equal(10, p3),
                p4 => Assert.Equal(9, p4),
                p7 => Assert.Equal(7, p7),
                p8 => Assert.Equal(5, p8),
                p9 => Assert.Equal(6, p9),
                p10 => Assert.Equal(2, p10));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingFourteenRecursiveTurns()
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

            sut.PlayRecursiveTurns(14);
            Assert.Collection(sut.Players[0],
                p2 => Assert.Equal(1, p2),
                p1 => Assert.Equal(8, p1),
                p1 => Assert.Equal(3, p1));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(4, p1),
                p2 => Assert.Equal(10, p2),
                p3 => Assert.Equal(9, p3),
                p4 => Assert.Equal(7, p4),
                p5 => Assert.Equal(5, p5),
                p6 => Assert.Equal(6, p6),
                p7 => Assert.Equal(2, p7));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingFifteenRecursiveTurns()
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

            sut.PlayRecursiveTurns(15);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(8, p1),
                p2 => Assert.Equal(3, p2));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(10, p1),
                p2 => Assert.Equal(9, p2),
                p3 => Assert.Equal(7, p3),
                p4 => Assert.Equal(5, p4),
                p5 => Assert.Equal(6, p5),
                p6 => Assert.Equal(2, p6),
                p7 => Assert.Equal(4, p7),
                p8 => Assert.Equal(1, p8));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingSixteenRecursiveTurns()
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

            sut.PlayRecursiveTurns(16);
            Assert.Collection(sut.Players[0],
                p1 => Assert.Equal(3, p1));
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(9, p1),
                p2 => Assert.Equal(7, p2),
                p3 => Assert.Equal(5, p3),
                p4 => Assert.Equal(6, p4),
                p5 => Assert.Equal(2, p5),
                p6 => Assert.Equal(4, p6),
                p7 => Assert.Equal(1, p7),
                p7 => Assert.Equal(10, p7),
                p8 => Assert.Equal(8, p8));
        }

        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingSeventeenRecursiveTurns()
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

            sut.PlayRecursiveTurns(17);
            Assert.Empty(sut.Players[0]);
            Assert.Collection(sut.Players[1],
                p1 => Assert.Equal(7, p1),
                p2 => Assert.Equal(5, p2),
                p3 => Assert.Equal(6, p3),
                p4 => Assert.Equal(2, p4),
                p5 => Assert.Equal(4, p5),
                p6 => Assert.Equal(1, p6),
                p7 => Assert.Equal(10, p7),
                p8 => Assert.Equal(8, p8),
                p9 => Assert.Equal(9, p9),
                p10 => Assert.Equal(3, p10));
        }

        [Fact]
        public void ReturnPoints_WhenCalculatingWinnerPointsAfterTheRecursiveGame()
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

            sut.PlayRecursiveTurns(17);
            sut.CalculatePoints();
            Assert.Equal(291, sut.WinnerPoints);
        }

        [Fact]
        public void PlayRecursiveGameCorrectly()
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

            sut.PlayRecursiveGame();
            sut.CalculatePoints();
            Assert.Equal(291, sut.WinnerPoints);

        }

        [Fact]
        public void PreventInfiniteRecursion()
        {
            const string decks = @"Player 1:
43
19

Player 2:
2
29
14";

            var sut = new Combat(decks);
            sut.PlayRecursiveGame();
            sut.CalculatePoints();
            Assert.Equal(105, sut.WinnerPoints);
        }

        [Fact]
        public void SolveSecondPuzzle()
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

            sut.PlayRecursiveGame();
            sut.CalculatePoints();
            Assert.Equal(32665, sut.WinnerPoints);
            Assert.True(33701 > sut.WinnerPoints);
        }
    }
}