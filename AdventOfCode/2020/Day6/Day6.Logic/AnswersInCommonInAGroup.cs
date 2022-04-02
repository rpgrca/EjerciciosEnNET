using System.Linq;

namespace AdventOfCode2020.Day6.Logic
{
    public class AnswersInCommonInAGroup : IQuestionnaire
    {
        private readonly string _answers;
        private string[] _answersPerGroup;

        public int Yes { get; private set; }

        public AnswersInCommonInAGroup(string answers)
        {
            _answers = answers;
            CountCommonAffirmativeAnswersInGroup();
        }

        private void CountCommonAffirmativeAnswersInGroup()
        {
            SplitGroupAnswers();
            FindCommonIndividualAnswers();
        }

        private void SplitGroupAnswers() =>
            _answersPerGroup = _answers.Split("\n");

        private void FindCommonIndividualAnswers() =>
            Yes = _answersPerGroup
                .Select(p => p.AsEnumerable())
                .Aggregate((a, b) => a.Intersect(b.AsEnumerable()))
                .Count();
    }
}