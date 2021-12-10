using System;

namespace Day10.Logic
{
    public class SyntaxChecker
    {
        private readonly string _code;

        public SyntaxChecker(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Invalid code");
            }

            _code = code;
        }
    }
}
