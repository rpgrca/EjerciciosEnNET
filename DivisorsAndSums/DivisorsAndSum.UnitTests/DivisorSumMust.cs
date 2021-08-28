using System;
using Xunit;
using DivisorsAndSum.Logic;
using System.Collections.Generic;

namespace DivisorsAndSum.UnitTests
{
    public class DivisorSumMust
    {
        [Fact]
        public void ReturnEquationFor6_WhenAskedForFirstValueFulfillingCondition()
        {
            var sut = new DivisorSum.Builder()
                .UpTo(1)
                .Build();

            Assert.Equal("1 + 2 + 3 = 6", sut.Result);
        }

        [Fact]
        public void ReturnEquationsFor6And28_WhenAskedForFirstTwoValuesFulfillingCondition()
        {
            var sut = new DivisorSum.Builder()
                .UpTo(2)
                .Build();

            Assert.Equal("1 + 2 + 3 = 6\n1 + 2 + 4 + 7 + 14 = 28", sut.Result);
        }

        [Fact]
        public void ReturnEquationsFor6And28And496_WhenAskedForFirstThreeValuesFulfillingConditions()
        {
            var sut = new DivisorSum.Builder()
                .UpTo(3)
                .Build();

            Assert.Equal("1 + 2 + 3 = 6\n1 + 2 + 4 + 7 + 14 = 28\n1 + 2 + 4 + 8 + 16 + 31 + 62 + 124 + 248 = 496", sut.Result);
        }

        private static IEnumerable<int> ValueGeneratorUsingMersennePrimes()
        {
            foreach (var value in new List<int>() { 2, 3, 5, 7, 13, 17, 19, 31, 61, 89, 107, 127, 521, 607, 1279, 2203, 2281, 3217, 4253, 4423, 9689, 9941 })
            {
                yield return (int)Math.Pow(2, value - 1) * ((int)Math.Pow(2, value) - 1);
            }
        }

        [Fact]
        public void ReturnEquationsFor6And28And496And8128_WhenAskedForFirstFourValuesUsingMersennePrimes()
        {
            const string expectedResult = @"1 + 2 + 3 = 6
1 + 2 + 4 + 7 + 14 = 28
1 + 2 + 4 + 8 + 16 + 31 + 62 + 124 + 248 = 496
1 + 2 + 4 + 8 + 16 + 32 + 64 + 127 + 254 + 508 + 1016 + 2032 + 4064 = 8128";

            var sut = new DivisorSum.Builder()
                .UsingGenerator(ValueGeneratorUsingMersennePrimes)
                .UpTo(4)
                .Build();

            Assert.Equal(expectedResult, sut.Result);
        }

        [Fact]
        public void ReturnEquationsFor6And28And496And8218And33550336_WhenAskedForFirstFiveValuesUsingMersennePrimes()
        {
            const string expectedResult = @"1 + 2 + 3 = 6
1 + 2 + 4 + 7 + 14 = 28
1 + 2 + 4 + 8 + 16 + 31 + 62 + 124 + 248 = 496
1 + 2 + 4 + 8 + 16 + 32 + 64 + 127 + 254 + 508 + 1016 + 2032 + 4064 = 8128
1 + 2 + 4 + 8 + 16 + 32 + 64 + 128 + 256 + 512 + 1024 + 2048 + 4096 + 8191 + 16382 + 32764 + 65528 + 131056 + 262112 + 524224 + 1048448 + 2096896 + 4193792 + 8387584 + 16775168 = 33550336";

            var sut = new DivisorSum.Builder()
                .UsingGenerator(ValueGeneratorUsingMersennePrimes)
                .UpTo(5)
                .Build();

            Assert.Equal(expectedResult, sut.Result);
        }
    }
}