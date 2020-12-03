using System.Linq;

namespace AdventOfCode2020.Day2
{
    public class PasswordValidatorForFirstPuzzle
    {
        protected readonly string _rule;
        protected readonly string _range;
        protected readonly string _password;
        protected readonly char _requiredLetter;
        protected readonly int _minimum;
        protected readonly int _maximum;

        public PasswordValidatorForFirstPuzzle(string entry)
        {
            _rule = entry.Split(":")[0];
            _range = _rule.Split(" ")[0];
            _requiredLetter = _rule.Split(" ")[1][0];
            _minimum = int.Parse(_range.Split("-")[0]);
            _maximum = int.Parse(_range.Split("-")[1]);
            _password = entry.Split(":")[1].Trim();
        }

        public bool Verify()
        {
            var found = _password.Count(p => p == _requiredLetter);
            return found >= _minimum && found <= _maximum;
        }
    }
}