namespace Solution
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using PossibilitiesArray.Logic;

    [TestFixture]
    public class SolutionTest
    {
        [Test, Description("Sample Tests")]
        public void SampleTest()
        {
            Assert.AreEqual(true, Kata.IsAllPossibilities(new int[] {0, 1, 2, 3}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {1, 2, 3, 4}));
        }

        private static Random rnd = new Random();

        private int[][] b=new int[][] {new int[] {3,2,10,4,1,6,9},new int[] {0,1,3,-2,5,4},new int[] {3,2,10,4,1,6},new int[] {6,2,4,2,2,2,1,5,0,0},new int[] {6,2,4,2,2,2,1,5,0,-100},new int[] {0,0,0,0,0,0,0,0,0,0,1,1,1,-2,-1},new int[] {-6,-3,-3,8,-5,-4},
            new int[] {-6,-3,-3,8,-10,-4},new int[] {3,1,2,4,0},new int[] {0,1},new int[] {1,1,8,3,1,1},new int[] {9,0,6},new int[] {1,1,15,-1,-1},new int[] {0,0,0,0,0,0,0,0,0,0},
            new int[] {6,2,4,2,2,2,1,5,0,0,-12,13,-5,4,6},new int[] {-2,5,0,5,12},new int[] {2},new int[] {0},new int[] {1,3,9,8},new int[] {},new int[] {1,2,3,4,0},new int[] {6,2,4,2,2,2,1,5,0,0,-12,13,-5,4,1},new int[] {25},new int[] {1,2,0,4,3}};

        public static bool solution(int[] arr) =>
            arr.Any() && !Enumerable.Range(0, arr.Length).Except(arr).Any();

        [Test, Description("Random Tests")]
        public void RandomTest()
        {
            const int Tests = 100;

            for (int i = 0; i < 100; ++i)
            {
                int[] arr = b[rnd.Next(0, b.Length)];

                bool expected = solution(arr);
                bool actual = Kata.IsAllPossibilities(arr);

                Assert.AreEqual(expected, actual);
            }
        }

        [Test, Description("Edge Tests")]
        public void EdgeTest()
        {
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {0,2,19,4,4}));
            Assert.AreEqual(true, Kata.IsAllPossibilities(new int[] {3,2,1,0}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {3,2,10,4,1,6}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {1,1,8,3,1,1}));
            Assert.AreEqual(true, Kata.IsAllPossibilities(new int[] {0,1,2,3}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {1,2,3,4}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {0,-1,2,3}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {0,2,3}));
            Assert.AreEqual(true, Kata.IsAllPossibilities(new int[] {0}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {}));
            Assert.AreEqual(true, Kata.IsAllPossibilities(new int[] {0,1,2,3,4,5,6,7,8,9}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {0,1,3,-2,5,4}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {0,-1,-2,-3,4}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {1,-1,3}));
            Assert.AreEqual(false, Kata.IsAllPossibilities(new int[] {1,-1,2,-2,3,-3,6}));
        }
    }
}