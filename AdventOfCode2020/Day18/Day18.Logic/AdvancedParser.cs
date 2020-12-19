using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day18.Logic
{
    public class AdvancedParser
    {
        private readonly string _expression;

        public AdvancedParser(string expression)
        {
            _expression = expression;
        }

        public long Parse()
        {
            var stack = new List<string>();
            var operatorStack = new List<List<string>>
            {
                new List<string>()
            };
            var tokens = _expression.Replace("(", "( ").Replace(")", " )").Split(" ");

            foreach (var token in tokens)
            {
                if (token == "(")
                {
                    operatorStack.Add(new List<string>());
                }
                else
                {
                    if (token == ")")
                    {
                        operatorStack[^1].Reverse();
                        foreach (var op in operatorStack[^1])
                        {
                            stack.Add(op);
                        }
                        operatorStack.RemoveAt(operatorStack.Count - 1);
                    }
                    else
                    {
                        if (long.TryParse(token, out var tokenizedValue))
                        {
                            stack.Add(tokenizedValue.ToString());
                        }
                        else
                        {
                            if (operatorStack.Last().Count == 0)
                            {
                                operatorStack.Last().Add(token);
                            }
                            else
                            {
                                if ((operatorStack.Last()[^1] == "+") || token == "*")
                                {
                                    var last = operatorStack.Last()[^1];
                                    operatorStack.Last().RemoveAt(operatorStack.Last().Count - 1);
                                    stack.Add(last);
                                    operatorStack.Last().Add(token);
                                }
                                else
                                {
                                    operatorStack.Last().Add(token);
                                }
                            }
                        }
                    }
                }
            }

            if (operatorStack.Last().Count > 0)
            {
                operatorStack.Last().Reverse();
                foreach (var op in operatorStack.Last())
                {
                    stack.Add(op);
                }
            }

            return Execute(stack);
        }

        public long Execute(List<string> stack)
        {
            var ip = 0;

            while (ip < stack.Count)
            {
                switch (stack[ip])
                {
                    case "+":
                        stack[ip - 2] = $"{long.Parse(stack[ip - 2]) + long.Parse(stack[ip - 1])}";
                        stack.RemoveAt(ip);
                        stack.RemoveAt(ip - 1);
                        ip--;
                        break;

                    case "*":
                        stack[ip - 2] = $"{long.Parse(stack[ip - 2]) * long.Parse(stack[ip - 1])}";
                        stack.RemoveAt(ip);
                        stack.RemoveAt(ip - 1);
                        ip--;
                        break;

                    default:
                        ip++;
                        break;
                }
            }

            return long.Parse(stack[0]);
        }
    }
}