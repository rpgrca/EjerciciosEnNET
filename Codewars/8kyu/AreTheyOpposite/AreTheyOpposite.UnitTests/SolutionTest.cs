using AreTheyOpposite.Logic;
using NUnit.Framework;
using System;
using System.Linq;

namespace AreTheyOpposite.UnitTests;

[TestFixture]
public class SolutionTest
{
    private static Random rnd = new Random();
    
    private static string lowerChars = "abcdefghijklmnopqrstuvwxyz";
    
    private static bool Solution(string s1, string s2)
    {
        if (s1 == s2 || s1.ToLower() != s2.ToLower()) return false;
      
        for (int i = 0; i < s1.Length; ++i)
        {
            if (s1[i] == s2[i]) return false;
        }
        return true;
    }
    
    private static string[] GetOppositeStrings()
    {
        string s1 = "";
        string s2 = "";
        int loops = rnd.Next(1, 21);
        for (int i = 0; i < loops; ++i)
        {
            char c = lowerChars[rnd.Next(0, lowerChars.Length)];

            if (rnd.Next(0, 2) == 0)
            {
                s1 += c;
                s2 += Char.ToUpper(c);
            }
            else
            {
                s1 += Char.ToUpper(c);
                s2 += c;
            }
        }
        return new string[2] {s1, s2};
    }
    
    private static string[] GetPsuedoOppositeStrings()
    {
        string s1 = "";
        string s2 = "";
        int loops = rnd.Next(1, 21);
        for (int i = 0; i < loops; ++i)
        {
            char c = lowerChars[rnd.Next(0, lowerChars.Length)];
            if (rnd.Next(0, 2) == 0)
            {
                s1 += c;
                s2 += c;
            }
            else
            {
                if (rnd.Next(0, 2) == 0)
                {
                    s1 += c;
                    s2 += Char.ToUpper(c);
                }
                else
                {
                    s1 += Char.ToUpper(c);
                    s2 += c;
                }
            }
        }
        return new string[2] {s1, s2};
    }
    
    private static string[] GetRandomStrings()
    {
        string s1 = "";
        string s2 = "";
        int loops = rnd.Next(1, 21);
        for (int i = 0; i < loops; ++i)
        {
            char c1 = lowerChars[rnd.Next(0, lowerChars.Length)];
            char c2 = lowerChars[rnd.Next(0, lowerChars.Length)];
            s1 += rnd.Next(0, 2) == 0 ? c1 : Char.ToUpper(c1);
            s2 += rnd.Next(0, 2) == 0 ? c2 : Char.ToUpper(c2);
        }
        return new string[2] {s1, s2};
    }
    
    private static string[] GetOneEmptyOneRandomString()
    {
        string s1 = "";
        string s2 = "";
        int loops = rnd.Next(1, 21);
        for (int i = 0; i < loops; ++i)
        {
            char c1 = lowerChars[rnd.Next(0, lowerChars.Length)];
            s1 += rnd.Next(0, 2) == 0 ? c1 : Char.ToUpper(c1);
        }
        return new string[2] {s1, s2};
    }
    
    private static string[] GetEmptyStrings() => new string[] {"", ""};
    
    private static string[] GetDiffLengthOpposite()
    {
        string[] result = GetOppositeStrings();
        int loops = rnd.Next(1, 6);
        if (rnd.Next(0, 2) == 0)
        {
            for (int i = 0; i < loops; ++i)
            {
                result[0] += lowerChars[rnd.Next(0, lowerChars.Length)];
            }
        }
        else
        {
            for (int i = 0; i < loops; ++i)
            {
                result[1] += lowerChars[rnd.Next(0, lowerChars.Length)];
            }
        }
        return result;
    }
    
    [Test, Description("Sample Tests")]
    public void SampleTest()
    {
        Action[] tests = new Action[]
        {
            () => Assert.AreEqual(true, Kata.IsOpposite("ab","AB"), "ab, AB => true"),
            () => Assert.AreEqual(true, Kata.IsOpposite("aB","Ab"), "aB, Ab => true"),
            () => Assert.AreEqual(true, Kata.IsOpposite("aBcd","AbCD"), "aBcd, AbCD => true"),
            () => Assert.AreEqual(false, Kata.IsOpposite("aBcde","AbCD"), "aBcde, AbCD => false"),
            () => Assert.AreEqual(false, Kata.IsOpposite("AB","Ab"), "AB, Ab => false"),
            () => Assert.AreEqual(false, Kata.IsOpposite("",""), "String.Empty, String.Empty => false"),
        };
        tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    delegate string[] TestGenerator();
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
        for (int i = 0; i < 1000; ++i)
        {
            string[] test = new TestGenerator[] 
            { 
                new TestGenerator(GetOppositeStrings), new TestGenerator(GetPsuedoOppositeStrings), 
                new TestGenerator(GetRandomStrings), new TestGenerator(GetRandomStrings),
                new TestGenerator(GetOneEmptyOneRandomString), new TestGenerator(GetEmptyStrings),
                new TestGenerator(GetDiffLengthOpposite)
            }[rnd.Next(0, 7)]();
            bool expected = Solution(test[0], test[1]);
            bool actual = Kata.IsOpposite(test[0], test[1]);
            Console.WriteLine($"Testing for \"{test[0]}\" and \"{test[1]}\":\nExpected: {expected}\nActual:   {actual}\n");
            Assert.AreEqual(expected, actual);
        }
    }
}