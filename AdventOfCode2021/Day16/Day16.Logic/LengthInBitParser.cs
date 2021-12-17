using System;

namespace Day16.Logic
{
    internal class LengthInBitParser : LengthParser
    {
        public LengthInBitParser(string bits) : base(bits)
        {
        }

        protected override bool MustContinueParsing(int consumed) =>
            consumed < SubPacketsLengthInBits;

        protected override void CalculateSubPacketsLength()
        {
            SubPacketsLengthInBits = Convert.ToInt32(Bits[Consumed..(Consumed + 15)], 2);
            Consumed += 15;
        }
    }
}