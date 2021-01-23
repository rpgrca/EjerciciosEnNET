using System.Collections.Generic;
using Xunit;

namespace BiValuedArray
{
    public class SolutionMust
    {
        [Theory]
        [MemberData(nameof(SolutionFeeder))]
        public void ReturnCorrectLength(int[] sampleArray, int expectedLength)
        {
            var sut = new Solution();
            var length = sut.solution(sampleArray);
            Assert.Equal(expectedLength, length);
        }

        public static IEnumerable<object[]> SolutionFeeder()
        {
            yield return new object[] { new int[] { 4, 2, 2, 4, 2 }, 5 };
            yield return new object[] { new int[] { 1, 2, 3, 2 }, 3 };
            yield return new object[] { new int[] { 0, 5, 4, 4, 5, 12 }, 4 };
            yield return new object[] { new int[] { 4, 4, }, 2 };
            yield return new object[] { new int[] { 4, 2, 2, 4, 5, 4, 4, 4, 4, 4, 2, 2 }, 7 };
            yield return new object[] { new int[] { 1, 1, 3, 2, 2, 1, 3 }, 3 };
        }
   }

   public class SolutionAsObjectOrientedMust
   {
       [Theory]
       [MemberData(nameof(SolutionFeeder))]
        public void ReturnCorrectLength(int[] sampleArray, int expectedLength)
        {
            var sut = new SolutionAsObjectOriented(sampleArray);
            var length = sut.Calculate();
            Assert.Equal(expectedLength, length);
        }

        public static IEnumerable<object[]> SolutionFeeder()
        {
            yield return new object[] { new int[] { 4, 2, 2, 4, 2 }, 5 };
            yield return new object[] { new int[] { 1, 2, 3, 2 }, 3 };
            yield return new object[] { new int[] { 0, 5, 4, 4, 5, 12 }, 4 };
            yield return new object[] { new int[] { 4, 4, }, 2 };
            yield return new object[] { new int[] { 4, 2, 2, 4, 5, 4, 4, 4, 4, 4, 2, 2 }, 7 };
            yield return new object[] { new int[] { 1, 1, 3, 2, 2, 1, 3 }, 3 };
        }
    }
}