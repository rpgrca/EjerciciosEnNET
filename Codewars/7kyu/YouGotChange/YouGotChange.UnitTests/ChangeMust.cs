namespace Solution;

using NUnit.Framework;
using System;
using YouGotChange.Logic;

[TestFixture]
public class ChangeMust
{
    [Test]
    public void ThrowException_WhenAmountIsInvalid() =>
        Assert.Throws<ArgumentNullException>(() => new Change.Builder().For(-1).Build());

    [Test]
    public void ThrowException_WhenBillsAreInvalid() =>
        Assert.Throws<ArgumentNullException>(() => new Change.Builder().With(Array.Empty<int>()).Build());

    [Test]
    public void CalculateCorrectExchange()
    {
        var sut = new Change.Builder().For(39).With(new int[] { 1 }).Build();
        Assert.AreEqual(new int[] { 39 }, sut.OptimizedChange);
    }
}