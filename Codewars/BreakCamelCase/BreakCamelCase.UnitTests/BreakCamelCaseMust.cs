using System.Reflection;
using System;
using System.Collections.Generic;
using Xunit;
using BreakCamelCase.Logic;

namespace BreakCamelCase.UnitTests
{
    public class BreakCamelCaseMust
    {
        public static IEnumerable<object[]> TestCases
        {
            get
            {
                yield return new object[] { "camelCasing", "camel Casing" };
                yield return new object[] { "camelCasingTest", "camel Casing Test" };
            }
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Test(string source, string expectedResult)
        {
            Assert.Equal(expectedResult, Kata.BreakCamelCase(source));
        }
    }
}
