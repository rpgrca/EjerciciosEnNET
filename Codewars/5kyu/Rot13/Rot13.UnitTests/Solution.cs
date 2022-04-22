namespace Solution
{
    using NUnit.Framework;
    using System;
    using System.Text.RegularExpressions;
    using System.Linq;
    using Rot13.Logic;

    [TestFixture]
    public class SystemTests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("ROT13 example.", Kata.Rot13("EBG13 rknzcyr."));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual("Ubj pna lbh gryy na rkgebireg sebz na\nvagebireg ng AFN? In the elevators,\nthe extrovert looks at the OTHER guy's shoes.", Kata.Rot13("How can you tell an extrovert from an\nintrovert at NSA? Va gur ryringbef,\ngur rkgebireg ybbxf ng gur BGURE thl'f fubrf."));
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual("123", Kata.Rot13("123"));
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual("This is actually the first kata I ever made. Thanks for finishing it! :)", Kata.Rot13("Guvf vf npghnyyl gur svefg xngn V rire znqr. Gunaxf sbe svavfuvat vg! :)"));
        }

        [Test]
        public void Test5()
        {
            Assert.AreEqual("@[`{", Kata.Rot13("@[`{"));
        }

        private static Random rnd = new Random();

        private static string solution(string message)
        {
            // Pattern which matches any letter, ignoring case
            Regex pattern = new Regex("([a-z])", RegexOptions.IgnoreCase);

            // Function which will evaulate a Regex match and return a new string
            // In this case shifting the letter by 13 (fake mod 26)
            Func<Match, string> shifter = (letter) => ((char)(letter.Value[0] + ((Char.ToLower(letter.Value[0]) >= 'n') ? -13 : 13))).ToString();

            // Return the modified string
            return pattern.Replace(message, new MatchEvaluator(shifter)); 
        }

        [Test, Description("Random Strings")]
        public void RandomTest()
        {
            const int Tests = 100;

            for (int i = 0; i < Tests; ++i)
            {
                string test = String.Concat(new char[50].Select(_ => (rnd.Next(0, 6) == 0) ? (char)rnd.Next(32, 127) : (rnd.Next(0, 2) == 0) ? (char)rnd.Next(65, 91) : (char)rnd.Next(97, 123)));
                string actual = solution(test);
                string expected = Kata.Rot13(test);

                Assert.AreEqual(expected, actual, String.Format("Input: {0}, Expected Output: {1}, Actual Output: {2}", test, expected, actual));
            }
        }
    }
}