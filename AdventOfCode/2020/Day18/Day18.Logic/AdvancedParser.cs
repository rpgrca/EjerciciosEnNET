using System.Collections.Generic;

namespace AdventOfCode2020.Day18.Logic
{
    public class AdvancedParser
    {
        private readonly string _expression;
        private readonly List<string> _stack;
        private readonly List<List<string>> _operatorStack;

        public AdvancedParser(string expression)
        {
            _expression = expression;
            _stack = new List<string>();
            _operatorStack = new List<List<string>>
            {
                new List<string>()
            };
        }

        public long Parse()
        {
            var tokens = _expression.Replace("(", "( ").Replace(")", " )").Split(" ");

            foreach (var token in tokens)
            {
                switch (token)
                {
                    case "(":
                        _operatorStack.Add(new List<string>());
                        break;

                    case ")":
                        MoveOperatorsFromSecondaryStackToStack();
                        break;

                    default:
                        if (long.TryParse(token, out var tokenizedValue))
                        {
                            _stack.Add(tokenizedValue.ToString());
                        }
                        else
                        {
                            if (_operatorStack[^1].Count != 0)
                            {
                                if ((_operatorStack[^1][^1] == "+") || token == "*")
                                {
                                    var last = _operatorStack[^1][^1];
                                    _operatorStack[^1].RemoveAt(_operatorStack[^1].Count - 1);
                                    _stack.Add(last);
                                }
                            }

                            _operatorStack[^1].Add(token);
                        }

                        break;
                }
            }

            if (_operatorStack[^1].Count > 0)
            {
                MoveOperatorsFromSecondaryStackToStack();
            }

            return Execute();
        }

        private void MoveOperatorsFromSecondaryStackToStack()
        {
            _operatorStack[^1].Reverse();
            _operatorStack[^1].ForEach(o => _stack.Add(o));
            _operatorStack.RemoveAt(_operatorStack.Count - 1);
        }

        public long Execute()
        {
            var ip = 0;

            while (ip < _stack.Count)
            {
                switch (_stack[ip])
                {
                    case "+":
                        _stack[ip - 2] = $"{long.Parse(_stack[ip - 2]) + long.Parse(_stack[ip - 1])}";
                        _stack.RemoveAt(ip);
                        _stack.RemoveAt(ip - 1);
                        ip--;
                        break;

                    case "*":
                        _stack[ip - 2] = $"{long.Parse(_stack[ip - 2]) * long.Parse(_stack[ip - 1])}";
                        _stack.RemoveAt(ip);
                        _stack.RemoveAt(ip - 1);
                        ip--;
                        break;

                    default:
                        ip++;
                        break;
                }
            }

            return long.Parse(_stack[0]);
        }
    }
}