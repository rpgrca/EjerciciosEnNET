using Xunit;
using AdventOfCode2020.Day22.Logic;

namespace AdventOfCode2020.Day22.UnitTests
{
    public class RecursiveCombatMust
    {
        [Fact]
        public void CorrectlyModifyPlayerCards_AfterPlayingARecursiveTurn()
        {
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

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
        public void CorrectlyModifyPlayerCards_AfterPlayingTwoRecursiveTurns()
        {
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

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
        public void CorrectlyModifyPlayerCards_AfterPlayingThreeRecursiveTurns()
        {
            var sut =new RecursiveCombat(PuzzleData.SAMPLE_DATA);

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
        public void CorrectlyModifyPlayerCards_AfterPlayingFourRecursiveTurns()
        {
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

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
        public void CorrectlyModifyPlayerCards_AfterPlayingFiveRecursiveTurns()
        {
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

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
        public void CorrectlyModifyPlayerCards_AfterPlayingSixRecursiveTurns()
        {
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(6);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(7);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(8);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(9);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(10);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(11);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(12);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(13);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(14);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(15);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(16);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(17);
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
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.PlayTurns(17);
            sut.CalculatePointsForWinner();
            Assert.Equal(291, sut.WinnerPoints);
        }

        [Fact]
        public void PlayRecursiveGameCorrectly()
        {
            var sut = new RecursiveCombat(PuzzleData.SAMPLE_DATA);

            sut.Play();
            sut.CalculatePointsForWinner();
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

            var sut = new RecursiveCombat(decks);
            sut.Play();
            sut.CalculatePointsForWinner();
            Assert.Equal(105, sut.WinnerPoints);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new RecursiveCombat(PuzzleData.PUZZLE_DATA);

            sut.Play();
            sut.CalculatePointsForWinner();
            Assert.Equal(32665, sut.WinnerPoints);
        }
    }
}