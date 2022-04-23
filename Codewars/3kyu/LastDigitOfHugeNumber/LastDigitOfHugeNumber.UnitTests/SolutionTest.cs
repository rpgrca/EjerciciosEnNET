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
        public void SampleTest()
        {
            Random rnd = new Random();
            int rand1 = rnd.Next(0,100);
            int rand2 = rnd.Next(0,10);

            LDCase[] allCases = new LDCase[] {
                new LDCase(new int[] {rand1}, rand1%10),
                new LDCase(new int[] {rand1,rand2}, (int)Math.Pow(rand1%10,rand2)%10)
            };

            for(int i=0; i<allCases.Length;i++) {
                Assert.AreEqual(allCases[i].expect, Calculator.LastDigit(allCases[i].test));
            }
        }

        [Test]
        public void Test1() =>
            Assert.AreEqual(1, Calculator.LastDigit(Array.Empty<int>()));

        [Test]
        public void Test2() =>
            Assert.AreEqual(1, Calculator.LastDigit(new int[] { 0, 0 }));

        [Test]
        public void Test3() =>
            Assert.AreEqual(0, Calculator.LastDigit(new int[] { 0, 0, 0 }));

        [Test]
        public void Test4() =>
            Assert.AreEqual(1, Calculator.LastDigit(new int[] { 1, 2 }));

        [Test]
        public void Test5() =>
            Assert.AreEqual(1, Calculator.LastDigit(new int[] { 3, 4, 5 }));

        [Test]
        public void Test6() =>
            Assert.AreEqual(4, Calculator.LastDigit(new int[] { 4, 3, 6 }));

        [Test]
        public void Test7() =>
            Assert.AreEqual(1, Calculator.LastDigit(new int[] { 7, 6, 21 }));

        [Test]
        public void Test8() =>
            Assert.AreEqual(6, Calculator.LastDigit(new int[] { 12, 30, 21 }));

        [Test]
        public void Test9() =>
            Assert.AreEqual(4, Calculator.LastDigit(new int[] { 2, 2, 2, 0 }));

        [Test]
        public void Test10() =>
            Assert.AreEqual(0, Calculator.LastDigit(new int[] { 937640, 767456, 981242 }));

        [Test]
        public void Test11() =>
            Assert.AreEqual(6, Calculator.LastDigit(new int[] { 123232, 694022, 140249 }));

        [Test]
        public void Test12() =>
            Assert.AreEqual(6, Calculator.LastDigit(new int[] { 499942, 898102, 846073 }));

        [Test]
        public void TestA() =>
            Assert.AreEqual(1, Calculator.LastDigit(new int[] { 331, 8 }));
    }
}