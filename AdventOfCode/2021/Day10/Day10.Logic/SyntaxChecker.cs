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
        private readonly List<(string Ending, long Score)> _missingEndings;
        private readonly Dictionary<char, int> _invalidCharacterPoints;
        private readonly Dictionary<char, int> _autocompleteCharacterPoints;
        private readonly Dictionary<char, char> _opposites;

        public SyntaxChecker(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Invalid code");
            }

            _validLines = new List<string>();
            _invalidLines = new List<(string, int)>();
            _missingEndings = new List<(string, long)>();
            _code = code;

            _invalidCharacterPoints = new()
            {
                { ')', 3 },
                { ']', 57 },
                { '}', 1197 },
                { '>', 25137 }
            };

            _opposites = new()
            {
                { '(', ')' },
                { '{', '}' },
                { '<', '>' },
                { '[', ']' }
            };

            _autocompleteCharacterPoints = new()
            {
                { ')', 1 },
                { ']', 2 },
                { '}', 3 },
                { '>', 4 }
            };

            Parse();
        }

        private bool InsertIntoList(char value, List<char> list)
        {
            list.Insert(0, _opposites[value]);
            return true;
        }

        private static bool RemoveIfExpected(char value, List<char> list)
        {
            if (list[0] == value)
            {
                list.RemoveAt(0);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Parse()
        {
            var expectedEnding = new List<char>();
            var machine = new Dictionary<char, Func<char, bool>>
            {
                { '(', c => InsertIntoList(c, expectedEnding) },
                { '[', c => InsertIntoList(c, expectedEnding) },
                { '{', c => InsertIntoList(c, expectedEnding) },
                { '<', c => InsertIntoList(c, expectedEnding) },
                { ')', c => RemoveIfExpected(c, expectedEnding) },
                { '}', c => RemoveIfExpected(c, expectedEnding) },
                { ']', c => RemoveIfExpected(c, expectedEnding) },
                { '>', c => RemoveIfExpected(c, expectedEnding) }
            };

            foreach (var line in _code.Split("\n"))
            {
                var isInvalid = false;

                foreach (var character in line)
                {
                    isInvalid = !machine[character](character);
                    if (isInvalid)
                    {
                        _invalidLines.Add((line, _invalidCharacterPoints[character]));
                        break;
                    }
                }

                if (! isInvalid)
                {
                    _validLines.Add(line);
                    var score = expectedEnding.Aggregate(0L, (t, i) => (t * 5) + _autocompleteCharacterPoints[i]);
                    _missingEndings.Add((string.Concat(expectedEnding), score));
                }

                expectedEnding.Clear();
            }
        }

        public long GetAutcompleteScore()
        {
            var scores = GetAutocompleteScores().OrderBy(p => p).ToList();
            return scores[scores.Count / 2];
        }

        public List<long> GetAutocompleteScores() => _missingEndings.ConvertAll(p => p.Score);

        public List<string> GetSyntaxErrors() => _invalidLines.ConvertAll(p => p.Line);

        public int GetSyntaxErrorScore() => _invalidLines.ConvertAll(p => p.Score).Sum();

        public List<string> GetExpectedEndings() => _missingEndings.ConvertAll(p => p.Ending).ToList();
    }
}