using NUnit.Framework;
using System.Linq;
using System;
using CharacterCounter.Logic;

[TestFixture]
public class ValidateWordTest
{
    [Test]
    public void GenericTests()
    {
        Assert.AreEqual(true,Kata.ValidateWord("abcabc"), "The word was: \"abcabc\"");
        Assert.AreEqual(true,Kata.ValidateWord("Abcabc"), "The word was: \"Abcabc\"");
        Assert.AreEqual(true,Kata.ValidateWord("abc123"), "The word was: \"abc123\"");
        Assert.AreEqual(false,Kata.ValidateWord("abcabcd"), "The word was: \"abcabcd\"");
        Assert.AreEqual(true,Kata.ValidateWord("abc!abc!"), "The word was: \"abc!abc!\"");
        Assert.AreEqual(false,Kata.ValidateWord("abc:abc"), "The word was: \"abc:abc\"");
    }

    public static bool ValidateWordT(string s)
    {
        s = s.ToLower();
        int minimumCount = 0;
        int currentCount = 0;
        for (int i = 0; i<s.Length; i++)
        {
            currentCount = s.Count(x => x == s[i]);
            if (currentCount == minimumCount || i == 0)
                minimumCount = currentCount;
            else
                return false;
        }
        return true;
    }

    [Test]
    public static void RandomStringTests(){
        Console.WriteLine("\n ********** 50 Random String Tests **********");
        string alph = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*?:";
        Random rnd = new Random();
        for (int i = 0; i < 50; i++) {
            int trueOrFalse = rnd.Next(1,3);
            string randomString = "";

            if(trueOrFalse == 1)
            {
                int rando = rnd.Next(1,100);
                for(int j = 0; j<rando; j++)
                {
                    int n = rnd.Next(0,alph.Length);
                    randomString += alph[n];
                }
            }

            if (trueOrFalse == 2)
            {
                int rando = rnd.Next(1,50);
                for(int j = 0; j<rando; j++)
                {
                    int n = rnd.Next(0,alph.Length);
                    randomString += alph[n];
                }

                randomString = randomString.ToLower();
                int highestCount = randomString.Count(x => x == (randomString.GroupBy(y => y).OrderByDescending(y => y.Count()).First().Key));
                foreach(char c in randomString)
                {
                    while(randomString.Count(x => x == c) < highestCount)
                    {
                        randomString +=c;
                    }
                }
            }

            Assert.AreEqual(ValidateWordT(randomString), Kata.ValidateWord(randomString), "The word was: " + randomString);
        }
    }
}