using System;
using System.Linq;

namespace AdventOfCode2020.Day18.Logic
{
    public class Parser
    {
        private readonly string _expression;
        private string _number;
        private int _index;

        public Parser(string expression) =>
            (_expression, _number) = (expression, string.Empty);

        public long Parse()
        {
            var leftSideOperand = 0L;
            var rightSideOperand = 0L;

            while (_index < _expression.Length)
            {
                var currentCharacter = _expression[_index];
                switch (currentCharacter)
                {
                    case '+':
                        leftSideOperand = long.Parse(_number);
                        rightSideOperand = ParseNextOperand();
                        _number = $"{leftSideOperand + rightSideOperand}";
                        break;

                    case '*':
                        leftSideOperand = long.Parse(_number);
                        rightSideOperand = ParseNextOperand();
                        _number = $"{leftSideOperand * rightSideOperand}";
                        break;

                    case '(':
                        _number = ParseUntilClosingParenthesis().ToString();
                        break;

                    case ')':
                        break;

                    case ' ':
                        break;

                    default:
                        _number += currentCharacter;
                        break;
                }

                _index++;
            }

            return long.Parse(_number);
        }

        private long ParseNextOperand()
        {
            _number = string.Empty;
            _index += 2;
            while (_index < _expression.Length)
            {
                var currentCharacter = _expression[_index];
                switch (currentCharacter)
                {
                    case '(':
                        _index++;
                        _number = ParseUntilClosingParenthesis().ToString();
                        break;

                    case ')':
                        _index--;
                        return long.Parse(_number);

                    case '+':
                        break;

                    case '*':
                        break;

                    case ' ':
                        var value = long.Parse(_number);
                        _number = string.Empty;
                        return value;

                    default:
                        _number += currentCharacter;
                        break;
                }

                _index++;
            }

            return long.Parse(_number);
        }

        private long ParseUntilClosingParenthesis()
        {
            var leftSideOperand = 0L;
            var rightSideOperand = 0L;

            while (_index < _expression.Length)
            {
                var currentCharacter = _expression[_index];
                switch (currentCharacter)
                {
                    case '*':
                        leftSideOperand = long.Parse(_number);
                        rightSideOperand = ParseNextOperand();
                        _number = $"{leftSideOperand * rightSideOperand}";
                        break;

                    case '+':
                        leftSideOperand = long.Parse(_number);
                        rightSideOperand = ParseNextOperand();
                        _number = $"{leftSideOperand + rightSideOperand}";
                        break;

                    case '(':
                        _index++;
                        _number = ParseUntilClosingParenthesis().ToString();
                        break;

                    case ')':
                        return long.Parse(_number);

                    case ' ':
                        break;

                    default:
                        _number += currentCharacter;
                        break;
                }

                _index++;
            }

            return long.Parse(_number);
        }
    }
}