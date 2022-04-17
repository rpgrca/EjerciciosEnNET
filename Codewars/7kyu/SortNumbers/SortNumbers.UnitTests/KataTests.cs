namespace Solution
{
    using NUnit.Framework;
    using System;
    using SortNumbers.Logic;

    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            checkNums(new int[] { 1,2,3,10,5 }, new int[] { 1,2,3,5,10 });
            checkNums(null, new int[] { });
            checkNums(new int[] { }, new int[] {  });
            checkNums(new int[] { 20, 2, 10 }, new int[] { 2, 10, 20 });
            checkNums(new int[] { 2, 20, 10 }, new int[] { 2, 10, 20 });
            checkNums(new int[] { 2, 10, 20 }, new int[] { 2, 10, 20 });
        }

        private void checkNums(int[] nums, int[] expected)
        {
            var actual = Kata.SortNumbers(nums);
            Assert.AreEqual(expected, actual, nums != null ? "{" + string.Join(",", nums) + "}" : "null");
        }
    }
}