using NUnit.Framework;
using System.Collections.Generic;
using System;
using JadenCasingStrings.Logic;

[TestFixture]
public class JadenCaseTest
{
    [Test, TestCaseSource("FixedTests")]
    public string FixedTest(string input)
    {
        return input.ToJadenCase();
    }

    [Test, TestCaseSource("RandomTests")]
    public string RandomTest(string input)
    {
        return input.ToJadenCase();
    }

    private static TestCaseData[] FixedTests =
    {
        new TestCaseData("most trees are blue")
            .Returns("Most Trees Are Blue"),
            
        new TestCaseData("How can mirrors be real if our eyes aren't real") 
            .Returns("How Can Mirrors Be Real If Our Eyes Aren't Real"),
            
        new TestCaseData("All the rules in this world were made by someone no smarter than you. So make your own.")
            .Returns("All The Rules In This World Were Made By Someone No Smarter Than You. So Make Your Own."),
            
        new TestCaseData("School is the tool to brainwash the youth.")
            .Returns("School Is The Tool To Brainwash The Youth."),
            
        new TestCaseData("If newborn babies could speak they would be the most intelligent beings on planet Earth.")
            .Returns("If Newborn Babies Could Speak They Would Be The Most Intelligent Beings On Planet Earth."),
            
        new TestCaseData("If everybody in the world dropped out of school we would have a much more intelligent society.")
            .Returns("If Everybody In The World Dropped Out Of School We Would Have A Much More Intelligent Society."),
            
        new TestCaseData("Trees are never sad look at them every once in awhile they're quite beautiful.")
            .Returns("Trees Are Never Sad Look At Them Every Once In Awhile They're Quite Beautiful."),
            
        new TestCaseData("When I die. then you will realize")
            .Returns("When I Die. Then You Will Realize"),
            
        new TestCaseData("I should just stop tweeting, the human conciousness must raise before I speak my juvenile philosophy.")
            .Returns("I Should Just Stop Tweeting, The Human Conciousness Must Raise Before I Speak My Juvenile Philosophy."),
            
        new TestCaseData("Jonah Hill is a genius")
            .Returns("Jonah Hill Is A Genius"),
            
        new TestCaseData("Dying is mainstream")
            .Returns("Dying Is Mainstream"),
            
        new TestCaseData("If there is bread winners, there is bread losers. But you can't toast what isn't real.")
            .Returns("If There Is Bread Winners, There Is Bread Losers. But You Can't Toast What Isn't Real."),
            
        new TestCaseData("You Can Discover Everything You Need to Know About Everything by Looking at your Hands")
            .Returns("You Can Discover Everything You Need To Know About Everything By Looking At Your Hands"),
            
        new TestCaseData("Fixed habits to respond to authority takes 12 years. Have fun")
            .Returns("Fixed Habits To Respond To Authority Takes 12 Years. Have Fun"),
            
        new TestCaseData("When you Live your Whole life In a Prison freedom Can be So dull.")
            .Returns("When You Live Your Whole Life In A Prison Freedom Can Be So Dull."),
            
        new TestCaseData("Young Jaden: Here's the deal for every time out you give me, you'll give me 15 dollars for therapy when I get older.")
            .Returns("Young Jaden: Here's The Deal For Every Time Out You Give Me, You'll Give Me 15 Dollars For Therapy When I Get Older."),
            
        new TestCaseData("The moment that truth is organized it becomes a lie.")
            .Returns("The Moment That Truth Is Organized It Becomes A Lie."),
            
        new TestCaseData("Three men, six options, don't choose.")
            .Returns("Three Men, Six Options, Don't Choose."),
            
        new TestCaseData("Water in the eyes and alcohol in the eyes are pretty much the same I know This from first Hand Experience.")
            .Returns("Water In The Eyes And Alcohol In The Eyes Are Pretty Much The Same I Know This From First Hand Experience."),
            
        new TestCaseData("Pay attention to the numbers in your life they are vastly important.")
            .Returns("Pay Attention To The Numbers In Your Life They Are Vastly Important."),
            
        new TestCaseData("We need to stop teaching the Youth about the Past and encourage them to change the Future.")
            .Returns("We Need To Stop Teaching The Youth About The Past And Encourage Them To Change The Future."),
            
        new TestCaseData("If a book store never runs out of a certain book, dose that mean that nobody reads it, or everybody reads it")
            .Returns("If A Book Store Never Runs Out Of A Certain Book, Dose That Mean That Nobody Reads It, Or Everybody Reads It"),
            
        new TestCaseData("People tell me to smile I tell them the lack of emotion in my face doesn't mean I'm unhappy")
            .Returns("People Tell Me To Smile I Tell Them The Lack Of Emotion In My Face Doesn't Mean I'm Unhappy"),
            
        new TestCaseData("I watch Twilight every night")
            .Returns("I Watch Twilight Every Night")
    };

    private static Random random = new Random();
    private static IEnumerable<TestCaseData> RandomTests
    {
        get
        {
            for(int i = 0; i < 20; i++)
            {
                string phrase = GeneratePhrase();
                yield return new TestCaseData( phrase.ToLower() ).Returns( phrase );
            }
        }
    }

    private static string GeneratePhrase()
    {
        int wordCount = random.Next(5,15);
        var words = new List<string>();

        for(int i = 0; i < wordCount; i++)
        {
            words.Add(GenerateWord());
        }

        return String.Join(" ", words);
    }

    private static string GenerateWord()
    {
        int wordLen = random.Next(1,10);
        string result = "" + Char.ToUpper(GenerateChar());

        for(int i = 0; i < wordLen; i++)
        {
            result += GenerateChar();
        }

        return result;
    }

    private static char GenerateChar()
    {
        return (char)('a' + random.Next(26));
    }
}