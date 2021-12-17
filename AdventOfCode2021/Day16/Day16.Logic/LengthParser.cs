using System.Collections.Generic;

namespace Day16.Logic
{
    internal abstract class LengthParser
    {
        protected string Bits { get; }
        public int Consumed { get; protected set; }
        public List<Packet> ParsedPackets { get; }
        public int SubPacketsLengthInBits { get; protected set; }

        protected LengthParser(string bits)
        {
            Bits = bits;
            ParsedPackets= new List<Packet>();

            Parse();
        }

        private void Parse()
        {
            CalculateSubPacketsLength();

            var consumed = 0;
            while (MustContinueParsing(consumed))
            {
                var parser = new Parser(Bits[(Consumed + consumed)..]);
                ParsedPackets.Add(parser.ParsedPacket);
                consumed += parser.Consumed;
            }

            SubPacketsLengthInBits = consumed;
            UpdateConsumedBitsAfterProcessing();
        }

        private void UpdateConsumedBitsAfterProcessing() =>
            Consumed += SubPacketsLengthInBits;

        protected abstract void CalculateSubPacketsLength();
        protected abstract bool MustContinueParsing(int consumed);
    }
}