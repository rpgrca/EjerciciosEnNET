namespace Solution {
  using NUnit.Framework;
  using CorrectTheMistakesOfTheCharacterRecognitionSoftware.Logic;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void CorrectTests()
    {
      Assert.AreEqual("LONDON", Kata.Correct("L0ND0N"));
      Assert.AreEqual("DUBLIN", Kata.Correct("DUBL1N"));
      Assert.AreEqual("SINGAPORE", Kata.Correct("51NGAP0RE"));
      Assert.AreEqual("BUDAPEST", Kata.Correct("BUDAPE5T"));
      Assert.AreEqual("PARIS", Kata.Correct("PAR15"));
    }
  }
}