using System;
using System.Linq;

namespace AdventOfCode2020.Day2.Logic
{
    public abstract class PasswordValidation
    {
        public class Builder
        {
            private Func<PasswordEntry, PasswordValidation> _validator;
            private string _entry;
            private readonly PasswordEntryParser _parser;

            public Builder()
            {
                _parser = new PasswordEntryParser();
                _entry = string.Empty;
                _validator = _ => Build();
            }

            public Builder ForEntry(string entry)
            {
                _entry = entry;
                return this;
            }

            public Builder WithValidator(Func<PasswordEntry, PasswordValidation> validator)
            {
                _validator = validator;
                return this;
            }

            public PasswordValidation Build() =>
                _validator(_parser.Parse(_entry));
        }

        protected readonly PasswordEntry _entry;

        protected PasswordValidation(PasswordEntry anEntry) => _entry = anEntry;

        public abstract bool Verify();
    }
}