using System.Linq;

namespace MostRepeatedLetter.Logic
{
    public sealed class MostRepeatedLetter
    {
        public string Is { get; }

        public static MostRepeatedLetter In(string text) => new(text);

        private MostRepeatedLetter(string text) =>
            Is = text
                .GroupBy(p => p)
                .OrderByDescending(p => p.Count())
                .First()
                .Key.ToString();
    }
}