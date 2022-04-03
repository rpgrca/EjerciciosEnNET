using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using DbScale.Logic;

namespace DbScale.UnitTests
{
    [TestFixture]
    public class RandomTest
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                const int Tests = 100;
                Random rnd = new Random();
        
                for (int i = 0; i < Tests; ++i)
                {
                    double intensity = rnd.NextDouble() * (1e-9 - 1e-12) + 1e-12;
                    double expected = Math.Round(Kata.DbScale(intensity));
          
                    yield return new TestCaseData(intensity).Returns(expected);
                }
            }
        }
  
        [Test, TestCaseSource("testCases")]
        public double Test(double intensity) =>
            Math.Round(Kata.DbScale(intensity), MidpointRounding.AwayFromZero);
    }
}