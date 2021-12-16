using System;
using System.Collections.Generic;

namespace Day16.Logic
{
    public class Parser
    {
        private readonly string _bits;

        public List<Packet> Packets { get; }
        public int Consumed { get; private set; }

        public Parser(string bits)
        {
            _bits = bits;
            Packets = new List<Packet>();

            Parse();
        }

        private void Parse()
        {
            if (IsFinalPadding())
            {
                Consumed = _bits.Length;
            }
            else
            {
                var packet = PacketFactory.Create(_bits);

                Packets.Add(packet);

                Consumed = packet.Consumed;
            }
        }

        private bool IsFinalPadding() =>
            string.IsNullOrEmpty(_bits.Replace("0", string.Empty));
    }
}