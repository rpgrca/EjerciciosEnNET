using System;
using System.Collections.Generic;

namespace Day16.Logic
{
    internal class LengthInPacketParser : ILengthParser
    {
        private readonly string _bits;
        private int _packetsToConsume;

        public int Consumed { get; private set; }
        public List<Packet> ParsedPackets { get; }
        public int SubPacketsLengthInBits { get; internal set; }

        public LengthInPacketParser(string bits)
        {
            _bits = bits;
            ParsedPackets = new List<Packet>();

            Parse();
        }

        private void Parse()
        {
            CalculateAmountOfPacketsToConsume();

            while (_packetsToConsume-- > 0)
            {
                var parser = new Parser(_bits[Consumed..]);
                ParsedPackets.Add(parser.ParsedPacket);
                Consumed += parser.Consumed;
                SubPacketsLengthInBits += parser.Consumed; // Unnecessary?
            }
        }

        private void CalculateAmountOfPacketsToConsume()
        {
            _packetsToConsume = Convert.ToInt32(_bits[Consumed..(Consumed + 11)], 2);
            Consumed += 11;
        }
    }
}