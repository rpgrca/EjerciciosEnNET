namespace Solution
{
    using NUnit.Framework;
    using System;
    using System.Linq;
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

        [Test]
        public void RandomTests()
        {
            var rand = new Random();

            Func<int[],int[]> mySortNumbers = delegate (int[] nums)
            {
                return nums == null ? new int[0] : nums.OrderBy(o => o).ToArray();
            };

            for(int i=0;i<30;i++)
            {
                var length = rand.Next(2,10);
                var nums = Enumerable.Range(0,length).Select(o => rand.Next(0, 20)).ToArray();
                checkNums(nums, mySortNumbers(nums));
            }
        }

        private void checkNums(int[] nums, int[] expected)
        {
            var actual = Kata.SortNumbers(nums);

            Assert.AreEqual(expected, actual, nums != null ? "{" + string.Join(",", nums) + "}" : "null");
        }
    }
}