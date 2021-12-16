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

        public TransmissionDecoder(string transmission)
        {
            if (string.IsNullOrWhiteSpace(transmission))
            {
                throw new ArgumentException("Invalid transmission");
            }

            _transmission = transmission;
            Packets = new List<Packet>();

            Parse();
        }

        private void Parse()
        {
            _bits = _transmission.Select(p => p switch {
                '0' => "0000",
                '1' => "0001",
                '2' => "0010",
                '3' => "0011",
                '4' => "0100",
                '5' => "0101",
                '6' => "0110",
                '7' => "0111",
                '8' => "1000",
                '9' => "1001",
                'A' => "1010",
                'B' => "1011",
                'C' => "1100",
                'D' => "1101",
                'E' => "1110",
                _ => "1111"
            }).Aggregate(string.Empty, (t, i) => t += i);

            var packet = new Packet
            {
                Version = _bits[0..3],
                TypeId = _bits[3..6]
            };
            Packets.Add(packet);
        }
    }

    public class Packet
    {
        public string Version { get; set; }
        public string TypeId { get; set; }
    }
}