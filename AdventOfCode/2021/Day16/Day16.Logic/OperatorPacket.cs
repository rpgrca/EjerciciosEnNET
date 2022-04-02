using System.Linq;
using System.Collections.Generic;

namespace Day16.Logic
{
    public abstract class OperatorPacket : Packet
    {
        private readonly string _bits;

        public int LengthTypeId { get; private set; }
        public int SubPacketsLengthInBits { get; set; }
        public List<Packet> SubPackets { get; }

        protected OperatorPacket(string bits) : base(bits)
        {
            _bits = bits;
            SubPackets = new List<Packet>();

            Parse();
        }

        private void Parse()
        {
            CalculateLengthTypeId();
            ParseAccordingToLengthTypeId();
        }

        private void CalculateLengthTypeId() =>
            LengthTypeId = _bits[Consumed++] - '0';

        private void ParseAccordingToLengthTypeId()
        {
            var parser = LengthParserFactory.Create(LengthTypeId, _bits[Consumed..]);

            SubPacketsLengthInBits = parser.SubPacketsLengthInBits;
            SubPackets.AddRange(parser.ParsedPackets);
            Consumed += parser.Consumed;
        }

        public override void Accept(VersionSumVisitor visitor) =>
            visitor.Visit(this);
    }

    internal class SumOperatorPacket : OperatorPacket
    {
        public SumOperatorPacket(string bits) : base(bits) =>
            Value = SubPackets.Sum(p => p.Value);
    }

    internal class ProductOperatorPacket : OperatorPacket
    {
        public ProductOperatorPacket(string bits) : base(bits) =>
            Value = SubPackets.Aggregate(1L, (t, i) => t *= i.Value);
    }

    internal class MinimumOperatorPacket : OperatorPacket
    {
        public MinimumOperatorPacket(string bits) : base(bits) =>
            Value = SubPackets.Min(p => p.Value);
    }

    internal class MaximumOperatorPacket : OperatorPacket
    {
        public MaximumOperatorPacket(string bits) : base(bits) =>
            Value = SubPackets.Max(p => p.Value);
    }

    internal class GreaterThanOperatorPacket : OperatorPacket
    {
        public GreaterThanOperatorPacket(string bits) : base(bits) =>
            Value = SubPackets[0].Value > SubPackets[1].Value ? 1 : 0;
    }

    internal class LessThaOperatorPacket : OperatorPacket
    {
        public LessThaOperatorPacket(string bits) : base(bits) =>
            Value = SubPackets[0].Value < SubPackets[1].Value ? 1 : 0;
    }

    internal class EqualThanOperatorPacket : OperatorPacket
    {
        public EqualThanOperatorPacket(string bits) : base(bits) =>
            Value = SubPackets[0].Value == SubPackets[1].Value ? 1 : 0;
    }
}