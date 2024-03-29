using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class LarioWorld
{
    [Test]
    public void FixThosePipes_t1()
    {
        Assert.AreEqual(new List<int>{1,2,3,4,5,6,7,8,9}, Fixer.PipeFix(new List<int>{1,2,3,5,6,8,9}));
    }

    [Test]
    public void FixThosePipes_t2()
    {
        Assert.AreEqual(new List<int>{1,2,3,4,5,6,7,8,9,10,11,12}, Fixer.PipeFix(new List<int>{1,2,3,12}));
    }

    [Test]
      public void FixThosePipes_t3()
      {
        Assert.AreEqual(new List<int>{6,7,8,9}, Fixer.PipeFix(new List<int>{6,9}));
      }

    [Test]
    public void SecretNegativeWorld()
    {
        Assert.AreEqual(new List<int>{-1,0,1,2,3,4}, Fixer.PipeFix(new List<int>{-1,4}));
    }

    [Test]
    public void LengthOfOne()
    {
        Assert.AreEqual(new List<int>{2}, Fixer.PipeFix(new List<int>{2}));
    }

    [Test]
    public static void RandomTest([Random(0,49,10)]int min, [Random(50,100,10)]int max)
    {
        List<int> pipes = new List<int>{ min, max };
        Assert.AreEqual(Solution(pipes), Fixer.PipeFix(pipes), string.Format("Should work for {0}", string.Join(", ", pipes)));
    }

    private static List<int> Solution(List<int> pipes)
    {
        return Enumerable.Range(pipes.Min(), pipes.Max()+1 - pipes.Min()).ToList();
    }
}