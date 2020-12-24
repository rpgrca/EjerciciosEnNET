using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2020.Day23.UnitTests
{
    public class CupGameWithLinkedListsMust
    {
        private const string SAMPLE_DATA = "32415";
        private const string SAMPLE_DATA_2 = "389125467";
        private const string PUZZLE_DATA = "853192647";

        [Fact]
        public void Test1()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA);
            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(4, c3),
                c4 => Assert.Equal(1, c4),
                c5 => Assert.Equal(5, c5));
        }

        [Fact]
        public void Test2()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA);

            sut.Step1();
            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(3, c1),
                c5 => Assert.Equal(5, c5));
        }

        [Fact]
        public void Test4()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA);
            sut.Step1();
            sut.Step2();
            sut.Step3();

            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(5, c2),
                c3 => Assert.Equal(2, c3),
                c4 => Assert.Equal(4, c4),
                c5 => Assert.Equal(1, c5));
        }

        [Fact]
        public void Test6()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);
            sut.Step1();

            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(5, c3),
                c4 => Assert.Equal(4, c4),
                c5 => Assert.Equal(6, c5),
                c6 => Assert.Equal(7, c6));
        }

        [Fact]
        public void Test7()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);
            sut.Moves(1);

            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(8, c3),
                c4 => Assert.Equal(9, c4),
                c5 => Assert.Equal(1, c5),
                c6 => Assert.Equal(5, c6),
                c7 => Assert.Equal(4, c7),
                c8 => Assert.Equal(6, c8),
                c9 => Assert.Equal(7, c9));
        }

        [Fact]
        public void Test8()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);
            sut.Moves(2);

            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(2, c2),
                c3 => Assert.Equal(5, c3),
                c4 => Assert.Equal(4, c4),
                c5 => Assert.Equal(6, c5),
                c6 => Assert.Equal(7, c6),
                c7 => Assert.Equal(8, c7),
                c8 => Assert.Equal(9, c8),
                c9 => Assert.Equal(1, c9));
        }

        [Fact]
        public void Test9()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);
            sut.Moves(3);

            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(3, c1),
                c2 => Assert.Equal(4, c2),
                c3 => Assert.Equal(6, c3),
                c4 => Assert.Equal(7, c4),
                c5 => Assert.Equal(2, c5),
                c6 => Assert.Equal(5, c6),
                c7 => Assert.Equal(8, c7),
                c8 => Assert.Equal(9, c8),
                c9 => Assert.Equal(1, c9));
        }

        [Fact]
        public void Test10()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);
            sut.Moves(4);

            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(4, c1),
                c2 => Assert.Equal(6, c2),
                c3 => Assert.Equal(7, c3),
                c4 => Assert.Equal(9, c4),
                c5 => Assert.Equal(1, c5),
                c6 => Assert.Equal(3, c6),
                c7 => Assert.Equal(2, c7),
                c8 => Assert.Equal(5, c8),
                c9 => Assert.Equal(8, c9));
        }

        [Fact]
        public void Test11()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);
            sut.Moves(5);

            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(4, c1),
                c2 => Assert.Equal(1, c2),
                c3 => Assert.Equal(3, c3),
                c4 => Assert.Equal(6, c4),
                c5 => Assert.Equal(7, c5),
                c6 => Assert.Equal(9, c6),
                c7 => Assert.Equal(2, c7),
                c8 => Assert.Equal(5, c8),
                c9 => Assert.Equal(8, c9));
        }

        [Fact]
        public void Test12()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);
            sut.Moves(6);

            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(4, c1),
                c2 => Assert.Equal(1, c2),
                c3 => Assert.Equal(9, c3),
                c4 => Assert.Equal(3, c4),
                c5 => Assert.Equal(6, c5),
                c6 => Assert.Equal(7, c6),
                c7 => Assert.Equal(2, c7),
                c8 => Assert.Equal(5, c8),
                c9 => Assert.Equal(8, c9));
        }

        [Fact]
        public void Test13()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);
            sut.Moves(7);

            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(4, c1),
                c2 => Assert.Equal(1, c2),
                c3 => Assert.Equal(9, c3),
                c4 => Assert.Equal(2, c4),
                c5 => Assert.Equal(5, c5),
                c6 => Assert.Equal(8, c6),
                c7 => Assert.Equal(3, c7),
                c8 => Assert.Equal(6, c8),
                c9 => Assert.Equal(7, c9));
        }

        [Fact]
        public void Test14()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);
            sut.Moves(8);

            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(4, c1),
                c2 => Assert.Equal(1, c2),
                c3 => Assert.Equal(5, c3),
                c4 => Assert.Equal(8, c4),
                c5 => Assert.Equal(3, c5),
                c6 => Assert.Equal(9, c6),
                c7 => Assert.Equal(2, c7),
                c8 => Assert.Equal(6, c8),
                c9 => Assert.Equal(7, c9));
        }

        [Fact]
        public void Test15()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);
            sut.Moves(9);

            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(5, c1),
                c2 => Assert.Equal(7, c2),
                c3 => Assert.Equal(4, c3),
                c4 => Assert.Equal(1, c4),
                c5 => Assert.Equal(8, c5),
                c6 => Assert.Equal(3, c6),
                c7 => Assert.Equal(9, c7),
                c8 => Assert.Equal(2, c8),
                c9 => Assert.Equal(6, c9));
        }

        [Fact]
        public void Test16()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);

            sut.Moves(10);
            Assert.Collection(sut.GetCupsInOrder(),
                c1 => Assert.Equal(5, c1),
                c2 => Assert.Equal(8, c2),
                c3 => Assert.Equal(3, c3),
                c4 => Assert.Equal(7, c4),
                c5 => Assert.Equal(4, c5),
                c6 => Assert.Equal(1, c6),
                c7 => Assert.Equal(9, c7),
                c8 => Assert.Equal(2, c8),
                c9 => Assert.Equal(6, c9));
        }

        [Fact]
        public void Test17()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);

            sut.Moves(10);
            Assert.Equal("92658374", sut.GetLabelsAfterCupOne());
        }

        [Fact]
        public void Test18()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2);

            sut.Moves(100);
            Assert.Equal("67384529", sut.GetLabelsAfterCupOne());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new CupGameWithLinkedLists(PUZZLE_DATA);

            sut.Moves(100);
            Assert.Equal("97624853", sut.GetLabelsAfterCupOne());
        }

        [Fact]
        public void Test19()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2, 1000000);
            Assert.Equal(1000000, sut.GetCupsInOrder().Count);
        }

        [Fact]
        public void Test20()
        {
            var sut = new CupGameWithLinkedLists(SAMPLE_DATA_2, 1000000);

            sut.Moves(10000000);
            Assert.Equal(934001, sut.FirstNumberAfterOne);
            Assert.Equal(159792, sut.SecondNumberAfterOne);
            Assert.Equal(149245887792UL, sut.MultiplyFirstAndSecondNumberAfterOne);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new CupGameWithLinkedLists(PUZZLE_DATA, 1000000);

            sut.Moves(10000000);
            Assert.Equal(776819, sut.FirstNumberAfterOne);
            Assert.Equal(855595, sut.SecondNumberAfterOne);
            Assert.Equal(664642452305UL, sut.MultiplyFirstAndSecondNumberAfterOne);
        }
    }
}