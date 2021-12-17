using System;

namespace Day16.Logic
{
    internal class LengthInPacketParser : LengthParser
    {
        private int _packetsToConsume;

        public LengthInPacketParser(string bits) : base(bits)
        {
        }

        protected override bool MustContinueParsing(int _) =>
            _packetsToConsume-- > 0;

        protected override void CalculateSubPacketsLength()
        {
            _packetsToConsume = Convert.ToInt32(Bits[Consumed..(Consumed + 11)], 2);
            Consumed += 11;
        }
    }
}