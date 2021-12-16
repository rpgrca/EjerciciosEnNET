using System;
using System.Linq;
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

        public override int GetVersionSum() => Convert.ToInt32(Version, 2) + SubPackets.Sum(p => p.GetVersionSum());
    }

    public class SumOperatorPacket : OperatorPacket
    {
        public SumOperatorPacket(string bits) : base(bits)
        {
        }

        public override long Value => SubPackets.Sum(p => p.Value);
    }

    public class ProductOperatorPacket : OperatorPacket
    {
        public ProductOperatorPacket(string bits) : base(bits)
        {
        }

        public override long Value => SubPackets.Aggregate(1L, (t, i) => t *= i.Value);
    }

    public class MinimumOperatorPacket : OperatorPacket
    {
        public MinimumOperatorPacket(string bits) : base(bits)
        {
        }

        public override long Value => SubPackets.Min(p => p.Value);
    }

    public class MaximumOperatorPacket : OperatorPacket
    {
        public MaximumOperatorPacket(string bits) : base(bits)
        {
        }

        public override long Value => SubPackets.Max(p => p.Value);
    }

    public class GreaterThanOperatorPacket : OperatorPacket
    {
        public GreaterThanOperatorPacket(string bits) : base(bits)
        {
        }

        public override long Value => SubPackets[0].Value > SubPackets[1].Value ? 1 : 0;
    }

    public class LessThaOperatorPacket : OperatorPacket
    {
        public LessThaOperatorPacket(string bits) : base(bits)
        {
        }

        public override long Value => SubPackets[0].Value < SubPackets[1].Value ? 1 : 0;
    }
}