using System;
using System.Linq;

namespace AdventOfCode2020.Day6.Logic
{
    public class Questionnaires
    {
        private readonly string _answers;
        private readonly Func<string, IQuestionnaire> _affirmativeQuestionCounter;
        private string[] _answersPerGroup;

        public int TotalAffirmativeAnswers { get; private set; }

        public Questionnaires(string answers, Func<string, IQuestionnaire> affirmativeQuestionCounter)
        {
            _answers = answers;
            _answersPerGroup = Array.Empty<string>();
            _affirmativeQuestionCounter = affirmativeQuestionCounter;
            CountAffirmativeAnswers();
        }

        private void CountAffirmativeAnswers()
        {
            SplitGroupAnswers();
            FindCommonAnswers();
        }

        private void FindCommonAnswers() =>
            TotalAffirmativeAnswers = _answersPerGroup
                .Sum(p => _affirmativeQuestionCounter.Invoke(p).Yes);

        private void SplitGroupAnswers() =>
            _answersPerGroup = _answers.Split("\n\n");
    }
}