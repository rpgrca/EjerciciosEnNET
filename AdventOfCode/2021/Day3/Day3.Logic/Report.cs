using System.Collections.Generic;

namespace Day3.Logic
{
    public abstract class Report
    {
        public abstract Report With(List<string> values);
        public int Value { get; protected set; }
    }
}