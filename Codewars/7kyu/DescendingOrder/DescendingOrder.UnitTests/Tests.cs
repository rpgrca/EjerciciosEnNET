using DescendingOrder.Logic;
using NUnit.Framework;
using System.Linq;
using System;

namespace DescendingOrder.UnitTests;

[TestFixture]
public class Tests
{
  [Test]
  public void Test0()
  {
    Assert.AreEqual(0, Kata.DescendingOrder(0));
  }  
  [Test]
  public void Test1()
  {
    Assert.AreEqual(1, Kata.DescendingOrder(1));
  }
  [Test]
  public void Test15()
  {
    Assert.AreEqual(51, Kata.DescendingOrder(15));
  }
  [Test]
  public void Test1021()
  {
    Assert.AreEqual(2110, Kata.DescendingOrder(1021));
  }
  [Test]
  public void Test123456789()
  {
    Assert.AreEqual(987654321, Kata.DescendingOrder(123456789));
  }
  [Test]
  public void RandomTests() {
    Random rand = new Random();
    int randomNum = 0;
    for (int i = 0; i < 50; i++) {
      randomNum = rand.Next(0, 999999999);
      Assert.AreEqual(DescendingSol(randomNum), Kata.DescendingOrder(randomNum));
    }
  }
  private int DescendingSol(int num) => int.Parse(string.Concat(num.ToString().OrderByDescending(c => c)));
}