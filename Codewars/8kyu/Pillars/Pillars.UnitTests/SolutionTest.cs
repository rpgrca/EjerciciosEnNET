using System.Security;
using System;
using NUnit.Framework;
using Pillars.Logic;

namespace Pillars.UnitTests
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void BasicTest1()
        {
           Assert.AreEqual(0, Kata.Pillars(1,10,10), "Testing for number of pillars: 1, distance: 10 m and width: 10 cm");
        }
    
        [Test]
        public void BasicTest2()
        {
            Assert.AreEqual(2000, Kata.Pillars(2,20,25), "Testing for number of pillars: 2, distance: 20 m and width: 25 cm");
        }
    
        [Test]
        public void BasicTest3()
        {
            Assert.AreEqual(15270, Kata.Pillars(11,15,30), "Testing for number of pillars: 11, distance: 15 m and width: 30 cm");
        }

        [Test]
        public void RandomTests()
        {
            Random r = new Random();
            for(int i = 0; i < 50; i++)
            {
                int n = r.Next(1, 1000);
                int d = r.Next(10, 30);
                int w = r.Next(10, 50);
        
                int result = (n-1)*d*100 + Math.Max(0, n-2)*w;
        
                Assert.AreEqual(result, Kata.Pillars(n,d,w), 
                    "Testing for number of pillars: " + n + ", distance: " + d + " and width: " + w + " cm");
            }      
        }
    }
}