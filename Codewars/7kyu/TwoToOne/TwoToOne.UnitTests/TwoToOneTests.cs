using System;
using NUnit.Framework;
using TwoToOne.Logic;

namespace TwoToOne.UnitTests;

[TestFixture]
public static class TwoToOneTests 
{
    [Test]
    public static void test1() 
    {
        Assert.AreEqual("aehrsty", Logic.TwoToOne.Longest("aretheyhere", "yestheyarehere"));
        Assert.AreEqual("abcdefghilnoprstu", Logic.TwoToOne.Longest("loopingisfunbutdangerous", "lessdangerousthancoding"));
        Assert.AreEqual("acefghilmnoprstuy", Logic.TwoToOne.Longest("inmanylanguages", "theresapairoffunctions"));
    }    
}