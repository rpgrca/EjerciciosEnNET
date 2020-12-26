namespace AdventOfCode2020.Day18.Logic
{
    public class Calculator
    {
        private readonly string _expression;

        public Calculator(string expression) =>
            _expression = expression;

        public long Evaluate() =>
            new Parser(_expression).Parse();

        public long EvaluateAdvanced() =>
            new AdvancedParser(_expression).Parse();
    }
}