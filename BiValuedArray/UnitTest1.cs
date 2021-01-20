using System;
using Xunit;
using System.Linq;

namespace BiValuedArray
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sut = new Solution();
            var length = sut.solution(new [] { 4, 2, 2, 4, 2 });
            Assert.Equal(5, length);
        }

        [Fact]
        public void Test2()
        {
            var sut = new Solution();
            var length = sut.solution(new [] { 1, 2, 3, 2 });
            Assert.Equal(3, length);
        }

        [Fact]
        public void Test3()
        {
            var sut = new Solution();
            var length = sut.solution(new [] { 0, 5, 4, 4, 5, 12 });
            Assert.Equal(4, length);
        }

        [Fact]
        public void Test4()
        {
            var sut = new Solution();
            var length = sut.solution(new [] { 4, 4 });
            Assert.Equal(2, length);
        }

        [Fact]
        public void Test5()
        {
            var sut = new Solution();
            var length = sut.solution(new [] { 4, 2, 2, 4, 5, 4, 4, 4, 4, 4, 2, 2 });
            Assert.Equal(7, length);
        }
    }

    public class Solution
    {
        public int solution(int[] A)
        {
            var maximumLength = 0;
            var currentLength = 2;

            if (A.Length >= 2)
            {
                var values = (A[0], A[1]);
                for (var index = 2; index < A.Length; index++)
                {
                    if (values.Item1 == A[index] || values.Item2 == A[index])
                    {
                        currentLength++;
                    }
                    else
                    {
                        if (values.Item1 == values.Item2)
                        {
                            values = (values.Item2, A[index]);
                            currentLength++;
                        }
                        else
                        {
                            if (maximumLength < currentLength)
                            {
                                maximumLength = currentLength;
                            }

                            values = (A[index - 1], A[index]);
                            currentLength = 2;
                        }
                    }
                }

                if (currentLength > maximumLength)
                {
                    maximumLength = currentLength;
                }
            }

            return maximumLength;
        }
    }
}
