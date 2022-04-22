namespace Solution;

using NUnit.Framework;
using System;
using CatYearsDogYears.Logic;

[TestFixture]
public class RandomTest
{
    private static int[] humanYearsCatYearsDogYears20180123(int h) {
        return new int[]{h, h==1 ? 15 : h==2 ? 24 : 24+4*(h-2), h==1 ? 15 : h==2 ? 24 : 24+5*(h-2)};
    }

    [Test]    
    public void random() {
        Random ran = new Random();
        for (int r = 0; r < 100; r++) {
            int humanYears = ran.Next(25) + 1;
            int[] expected = humanYearsCatYearsDogYears20180123(humanYears);
            int[] actual = Dinglemouse.HumanYearsCatYearsDogYears(humanYears);
            Console.WriteLine(string.Format("Random test {0}: human years {1} => {2}", r+1, humanYears, string.Join(",",expected)));
            Assert.AreEqual(expected, actual);
        }
    }
}