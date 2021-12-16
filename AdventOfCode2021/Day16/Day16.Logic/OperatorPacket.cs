using System;
using System.Collections.Generic;

namespace Day16.Logic
{
    public class OperatorPacket : Packet
    {
        private readonly string _bits;

        public int LengthTypeId { get; private set; }
        public int SubPacketsLengthInBits { get; set; }
        public List<Packet> SubPackets { get; }

        public OperatorPacket(string bits) : base(bits)
        {
            _bits = bits;
            SubPackets = new List<Packet>();

            Parse();
        }

        private void Parse()
        {
            LengthTypeId = _bits[Consumed++] - '0';
            if (LengthTypeId == 0)
            {
                SubPacketsLengthInBits = Convert.ToInt32(_bits[Consumed..(Consumed + 15)], 2);
                Consumed += 15;

                var consumed = 0;
                while (consumed < SubPacketsLengthInBits)
                {
                    var parser = new Parser(_bits[(Consumed + consumed)..]);
                    SubPackets.AddRange(parser.Packets);
                    consumed += parser.Consumed;
                }

                Consumed += SubPacketsLengthInBits;
            }
            else // LengthTypeID == 1
            {
                var toConsume = Convert.ToInt32(_bits[Consumed..(Consumed + 11)], 2);
                Consumed += 11;

                while (toConsume > 0)
                {
                    var parser = new Parser(_bits[Consumed..]);
                    toConsume -= parser.Packets.Count;
                    SubPackets.AddRange(parser.Packets);
                    Consumed += parser.Consumed;
                    SubPacketsLengthInBits += parser.Consumed; // Unnecessary?
                }
            }
        }
    }
}