namespace Solution
{
    using NUnit.Framework;
    using System;
    using LastDigitOfHugeNumber.Logic;

    public struct LDCase {
        public int[] test;
        public int expect;
        public LDCase(int[] t, int e) {
            test = t;
            expect = e;
        }
    }

    [TestFixture]
    public class SolutionTest {
        [Test]
        public void SampleTest() {
            Random rnd = new Random();
            int rand1 = rnd.Next(0,100);
            int rand2 = rnd.Next(0,10);

            LDCase[] allCases = new LDCase[] {
                new LDCase(new int[0],           1),
                new LDCase(new int[] {0,0},      1),
                new LDCase(new int[] {0,0,0},    0),
                new LDCase(new int[] {1,2},      1),
                new LDCase(new int[] {3,4,5},    1),
                new LDCase(new int[] {4,3,6},    4),
                new LDCase(new int[] {7,6,21},   1),
                new LDCase(new int[] {12,30,21}, 6),
                new LDCase(new int[] {2,2,2,0},  4),
                new LDCase(new int[] {937640,767456,981242}, 0),
                new LDCase(new int[] {123232,694022,140249}, 6),
                new LDCase(new int[] {499942,898102,846073}, 6),

                new LDCase(new int[] {rand1}, rand1%10),
                new LDCase(new int[] {rand1,rand2}, (int)Math.Pow(rand1%10,rand2)%10)
            };
            for(int i=0; i<allCases.Length;i++) {
                Assert.AreEqual(allCases[i].expect, Calculator.LastDigit(allCases[i].test));
            }
        }
    }
}