namespace Kata;

using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
    [Test]
    public void Test9()
    {
        var result = CircleAreaInsideSquare.Logic.Convert.SquareAreaToCircle(9);
        Assert.AreEqual(result.GetType(), typeof(double),"should a be double");
        Assert.AreEqual(Math.Round(result,8), Math.Round(7.0685834705770345d,8));
    }

    [Test]
    public void Test20()
    {
        var result = CircleAreaInsideSquare.Logic.Convert.SquareAreaToCircle(20);
        Assert.AreEqual(Math.Round(result,8), Math.Round(15.707963267948969d,8));
    }

    [Test]
    public void RandomTest()
    {
        var sqr = new Func<double, double>((size) => Math.Pow(Math.Sqrt(size) / 2,2) * Math.PI);
        var r = new Random();
        for(var i = 0; i < 10; i++){
            var input = r.NextDouble();
            Assert.AreEqual(Math.Round(CircleAreaInsideSquare.Logic.Convert.SquareAreaToCircle(input),8), Math.Round(sqr(input),8));
        }
    }
}