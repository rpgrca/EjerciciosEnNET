using System;
using System.Linq;

namespace AdventOfCode2020.Day2.Logic
{
    public class FirstPuzzleValidation : PasswordValidation
    {
        public FirstPuzzleValidation(PasswordEntry anEntry) : base(anEntry) { }

        public override bool Verify()
        {
            var found = _entry.Password.Count(p => p == _entry.RequiredLetter);
            return found >= _entry.Minimum && found <= _entry.Maximum;
        }
    }
}