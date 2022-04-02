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
            sut.CalculatePointsForWinner();
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

            sut.Play();
            sut.CalculatePointsForWinner();
            Assert.Equal(306, sut.WinnerPoints);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new Combat(PuzzleData.PUZZLE_DATA);

            sut.Play();
            sut.CalculatePointsForWinner();
            Assert.Equal(32495, sut.WinnerPoints);
        }
    }
}