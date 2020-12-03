using System.Linq;

namespace AdventOfCode2020.Day2
{

    public class PasswordValidatorForSecondPuzzle
    {
        public PasswordValidatorForSecondPuzzle(string entry)
            : base(entry)
        {
        }

        public bool Verify()
        {
            return HasRequiredLetterAtMinimumPosition() ^ HasRequiredLetterAtMaximumPosition();
        }

        private bool HasRequiredLetterAtMinimumPosition() => _password[_minimum - 1] == _requiredLetter;

        private bool HasRequiredLetterAtMaximumPosition() => _password.Length >= _maximum && _password[_maximum - 1] == _requiredLetter;
    }
}