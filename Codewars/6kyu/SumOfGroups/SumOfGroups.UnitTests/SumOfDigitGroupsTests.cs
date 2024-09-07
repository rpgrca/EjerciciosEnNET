using System;
using System.Numerics;
using NUnit.Framework;
using SumOfGroups.Logic;

namespace SumOfGroups.UnitTests;

[TestFixture]
public class SumOfDigitGroupsTests
{
     [Test]
     public void ExampleTest1()
     {
         var numbers = new BigInteger[] { 1234, 3142, 66654, 65466, 2143 };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(19, result);
     }

     [Test]
     public void ExampleTest2()
     {
         var numbers = new BigInteger[] { 12345, 54321, 98765, 56789, 12354, 54312 };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(23, result);
     }

     [Test]
     public void ExampleTest3()
     {
         var numbers = new BigInteger[] { 111, 11, 1, 222, 22, 2 };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(0, result);
     }

}