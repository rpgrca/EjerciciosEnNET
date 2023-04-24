namespace Solution;

using NUnit.Framework;
using Holiday4SharkPontoon.Logic;

[TestFixture]
public class BasicTests
{
    [TestCase(12, 50, 4, 8, true)]
    [TestCase(12, 50, 4, 8, false)]
    [TestCase(7, 55, 4, 16, true)]
    [TestCase(7, 8, 3, 4, true)]
    public void MustCoverAliveCases(int pontoonDistance, int sharkDistance, int yourSpeed, int sharkSpeed, bool dolphin) =>
        Assert.AreEqual("Alive!", Kata.Shark(pontoonDistance, sharkDistance, yourSpeed, sharkSpeed, dolphin));

    [TestCase(24, 0, 4, 8, true)]
    [TestCase(40, 35, 3, 20, true)]
    [TestCase(7, 8, 3, 4, false)]
    public void MustCoverSharkBaitCases(int pontoonDistance, int sharkDistance, int yourSpeed, int sharkSpeed, bool dolphin) =>
        Assert.AreEqual("Shark Bait!", Kata.Shark(pontoonDistance, sharkDistance, yourSpeed, sharkSpeed, dolphin));

    [Test]
    public void MustBeEaten_WhenDistanceToSharkIsEqualAtBeginning() =>
        Assert.AreEqual("Shark Bait!", Kata.Shark(35, 35, 3, 3, false));

    [Test]
    public void MustBeEaten_WhenBothReachAtExactlyTheSameTime() =>
        Assert.AreEqual("Shark Bait!", Kata.Shark(10, 50, 3, 15, false));
}