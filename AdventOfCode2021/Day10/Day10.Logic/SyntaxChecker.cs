using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10.Logic
{
    public class SyntaxChecker
    {
        private readonly string _code;
        private readonly List<string> _validLines;
        private readonly List<(string Line, int Score)> _invalidLines;
        private readonly List<(string Ending, int Score)> _missingEndings;

        public SyntaxChecker(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Invalid code");
            }

            _validLines = new List<string>();
            _invalidLines = new List<(string, int)>();
            _missingEndings = new List<(string, int)>();
            _code = code;

            Parse();
        }

        private void Parse()
        {
            List<char> stack = new();

            foreach (var line in _code.Split("\n"))
            {
                var isInvalid = false;
                stack.Clear();

                foreach (var character in line)
                {
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

                    if (isInvalid)
                    {
                        _invalidLines.Add((line, character switch {
                            ')' => 3,
                            ']' => 57,
                            '}' => 1197,
                            '>' => 25137
                        }));
                        break;
                    }
                }

                if (! isInvalid)
                {
                    _validLines.Add(line);
                    var missingEnding = string.Concat(stack.ConvertAll(p => p switch {
                        '(' => ')',
                        '[' => ']',
                        '<' => '>',
                        '{' => '}'
                    }));
                    var score = missingEnding.Aggregate(0, (t, i) => t * 5 + i switch {
                        ')' => 1,
                        ']' => 2,
                        '}' => 3,
                        '>' => 4
                    });

                    _missingEndings.Add((missingEnding, score));
                }
            }
        }

        public int GetAutcompleteScore()
        {
            var scores = GetAutocompleteScores().OrderBy(p => p).ToList();
            return scores[scores.Count / 2];
        }

        public List<int> GetAutocompleteScores() => _missingEndings.ConvertAll(p => p.Score);

        public List<string> GetSyntaxErrors() => _invalidLines.ConvertAll(p => p.Line);

        public int GetSyntaxErrorScore() => _invalidLines.ConvertAll(p => p.Score).Sum();

        public List<string> GetExpectedEndings() => _missingEndings.ConvertAll(p => p.Ending).ToList();
    }
}
