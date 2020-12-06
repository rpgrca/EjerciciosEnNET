using System;
using System.Linq;

namespace AdventOfCode2020.Day2.Logic
{
    public class SecondPuzzleValidation : PasswordValidation
    {
        public SecondPuzzleValidation(PasswordEntry anEntry) : base(anEntry) { }

        public override bool Verify() =>
            HasRequiredLetterAtMinimumPosition() ^ HasRequiredLetterAtMaximumPosition();

        private bool HasRequiredLetterAtMinimumPosition() =>
            _entry.Password[_entry.Minimum - 1] == _entry.RequiredLetter;

        private bool HasRequiredLetterAtMaximumPosition() =>
            _entry.Password.Length >= _entry.Maximum && _entry.Password[_entry.Maximum - 1] == _entry.RequiredLetter;
    }
}