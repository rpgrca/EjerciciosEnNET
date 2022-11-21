using NUnit.Framework;
using NextPalindromicNumber.Logic;

namespace NextPalindromicNumber.Solution;

public class NextPalMust
{
    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(22, Kata.NextPal(11));
            Assert.AreEqual(191, Kata.NextPal(188));
            Assert.AreEqual(202, Kata.NextPal(191));
            Assert.AreEqual(2552, Kata.NextPal(2541));
        }

        [Test]
        public void RandomTests()
        {
            var rand = new Random();
            
            Func<int,int> myNextPal = delegate (int val)
            {
                do
                {
                  val++;
                }
                while(val.ToString() != string.Concat(val.ToString().Reverse()));
             
                return val;
            };
            
            Action<int,int> TestFor = delegate (int rStart, int rEnd)
            {      
                for(var i=0;i<40;i++)
                {
                  var val = rand.Next(rStart, rEnd);
                  Console.WriteLine("val = " + val);
                  Assert.AreEqual(myNextPal(val), Kata.NextPal(val));
                }
            };
            
            TestFor(100,10001);
            TestFor(10000,100001);
            TestFor(100000,1000001);
            TestFor(1000000,10000001);
            TestFor(10000000,100000001);
        }
    }
}