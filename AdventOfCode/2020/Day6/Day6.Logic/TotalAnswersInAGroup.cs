using System.Linq;

namespace AdventOfCode2020.Day6.Logic
{
    public class TotalAnswersInAGroup : IQuestionnaire
    {
        public TotalAnswersInAGroup(string answers) =>
            Yes = answers
                .Distinct()
                .Count(p => p != '\n');

        public int Yes { get; }
    }
}