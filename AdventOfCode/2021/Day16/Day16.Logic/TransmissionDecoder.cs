using System.Linq;
using System;
using System.Collections.Generic;

namespace Day16.Logic
{
    public class TransmissionDecoder
    {
        private readonly string _transmission;
        private string _bits;

        public List<Packet> Packets { get; }
        public string Ignored { get; private set; }
        public long Value => Packets[0].Value;

        public TransmissionDecoder(string transmission)
        {
            if (string.IsNullOrWhiteSpace(transmission))
            {
                throw new ArgumentException("Invalid transmission");
            }

            _transmission = transmission;
            _bits = string.Empty;
            Ignored = string.Empty;
            Packets = new List<Packet>();

            Parse();
        }

        private void Parse()
        {
            ConvertHexadecimalToBits();
            ParseBits();
        }

        private void ConvertHexadecimalToBits() =>
            _bits = Convert.FromHexString(_transmission)
                .Select(p => Convert.ToString(p, 2))
                .Select(p => p.PadLeft(8, '0'))
                .Aggregate(string.Empty, (t, i) => t += i);

        private void ParseBits()
        {
            var parser = new Parser(_bits);
            Packets.Add(parser.ParsedPacket);

            Ignored = _bits[parser.Consumed..];
        }

        public long GetVersionSum()
        {
            var visitor = new VersionSumVisitor();

            Packets.ForEach(p => p.Accept(visitor));

            return visitor.Sum;
        }
    }
}