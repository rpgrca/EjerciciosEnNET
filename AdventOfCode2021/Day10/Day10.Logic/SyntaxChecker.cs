using System;
using System.Collections.Generic;

namespace Day10.Logic
{
    public class SyntaxChecker
    {
        private readonly string _code;
        private readonly List<string> _validLines;
        private readonly List<string> _invalidLines;

        public SyntaxChecker(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Invalid code");
            }

            _validLines = new List<string>();
            _invalidLines = new List<string>();
            _code = code;

            Parse();
        }

        private void Parse()
        {
            List<char> stack = new();
            var line = string.Empty;
            var isInvalid = false;

            foreach (var character in _code)
            {
                line += character;

                switch (character)
                {
                    case '(':
                    case '{':
                    case '[':
                    case '<':
                        stack.Insert(0, character);
                        break;

                    case ')':
                        if (stack[0] != '(')
                        {
                            isInvalid = true;
                        }
                        stack.RemoveAt(0);
                        break;

                    case ']':
                        if (stack[0] != '[')
                        {
                            isInvalid = true;
                        }
                        stack.RemoveAt(0);
                        break;

                    case '}':
                        if (stack[0] != '{')
                        {
                            isInvalid = true;
                        }
                        stack.RemoveAt(0);
                        break;

                    case '>':
                        if (stack[0] != '<')
                        {
                            isInvalid = true;
                        }
                        stack.RemoveAt(0);
                        break;
                }

                if (stack.Count == 0)
                {
                    if (isInvalid)
                    {
                        _invalidLines.Add(line);
                        isInvalid = false;
                    }
                    else
                    {
                        _validLines.Add(line);
                    }
                }
            }
        }

        public List<string> GetSyntaxErrors() => _invalidLines;
    }
}
