using Xunit;
using AdventOfCode2020.Day6.Logic;

namespace AdventOfCode2020.Day6.UnitTests
{
    public class QuestionnairesMust
    {
       [Fact]
        public void CountNumberOfTotalUniqueAnswers()
        {
            const string answers =
@"abc

a
b
c

ab
ac

a
a
a
a

b";

            var sut = new Questionnaires(answers, s => new TotalAnswersInAGroup(s));
            Assert.Equal(11, sut.TotalAffirmativeAnswers);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new Questionnaires(PuzzleData.ANSWERS, s => new TotalAnswersInAGroup(s));
            Assert.Equal(6335, sut.TotalAffirmativeAnswers);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new Questionnaires(PuzzleData.ANSWERS, s => new AnswersInCommonInAGroup(s));
            Assert.Equal(3392, sut.TotalAffirmativeAnswers);
        }
    }
}