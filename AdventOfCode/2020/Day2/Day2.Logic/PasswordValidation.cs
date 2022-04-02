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
            private readonly PasswordEntryParser _parser = new PasswordEntryParser();

            public Builder ForEntry(string entry)
            {
                _entry = entry;
                return this;
            }

            //public Builder WithParser(PasswordEntryParser parser)
            //{
            //    _parser = parser;
            //    return this;
            //}

            public Builder WithValidator(Func<PasswordEntry, PasswordValidation> validator)
            {
                _validator = validator;
                return this;
            }

            public PasswordValidation Build()
            {
                //if (string.IsNullOrWhiteSpace(_entry)) throw new ArgumentNullException(nameof(_entry));
                //if (_validator is null) throw new ArgumentNullException(nameof(_validator));
                //if (_parser is null) throw new ArgumentNullException(nameof(_parser));

                return _validator(_parser.Parse(_entry));
            }
        }

        protected readonly PasswordEntry _entry;

        protected PasswordValidation(PasswordEntry anEntry) => _entry = anEntry;

        public abstract bool Verify();
    }
}