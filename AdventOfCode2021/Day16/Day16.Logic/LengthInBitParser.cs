using System;
using System.Collections.Generic;

namespace Day16.Logic
{
    internal class LengthInBitParser : ILengthParser
    {
        private readonly string _bits;

        public int Consumed { get; private set; }
        public List<Packet> ParsedPackets { get; }
        public int SubPacketsLengthInBits { get; private set; }

        public LengthInBitParser(string bits)
        {
            _bits = bits;
            ParsedPackets = new List<Packet>();

            Parse();
        }

        private void Parse()
        {
            CalculateSubPacketsLengthSize();

            var consumed = 0;
            while (consumed < SubPacketsLengthInBits)
            {
                var parser = new Parser(_bits[(Consumed + consumed)..]);
                ParsedPackets.Add(parser.ParsedPacket);
                consumed += parser.Consumed;
            }

            UpdateConsumedBitsAfterProcessing();
        }

        private void CalculateSubPacketsLengthSize()
        {
            SubPacketsLengthInBits = Convert.ToInt32(_bits[Consumed..(Consumed + 15)], 2);
            Consumed += 15;
        }

        private void UpdateConsumedBitsAfterProcessing() =>
            Consumed += SubPacketsLengthInBits;
    }
}