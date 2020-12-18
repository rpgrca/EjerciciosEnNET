using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day18.Logic
{
    public class Calculator
    {
        private readonly string _expression;

        public Calculator(string expression)
        {
            _expression = expression;
        }

        public long Evaluate()
        {
            var parser = new Parser(_expression);
            return parser.Parse();
        }

        public long EvaluateAdvanced()
        {
            var parser = new AdvancedParser(_expression);
            return parser.Parse();
        }
    }
}