namespace Solution
{
    using NUnit.Framework;
    using CatYearsDogYears.Logic;
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void One()
        {
            Assert.AreEqual(new int[]{1,15,15}, Dinglemouse.HumanYearsCatYearsDogYears(1));
        }

        [Test]
        public void Two()
        {
            Assert.AreEqual(new int[]{2,24,24}, Dinglemouse.HumanYearsCatYearsDogYears(2));
        }

        [Test]
        public void Ten()
        {
            Assert.AreEqual(new int[]{10,56,64}, Dinglemouse.HumanYearsCatYearsDogYears(10));
        }
    }
}