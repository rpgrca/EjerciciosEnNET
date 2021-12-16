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
            if (string.IsNullOrEmpty(_bits.Replace("0", string.Empty)))
            {
                Consumed = _bits.Length;
            }
            else
            {
                var index = 0;
                var typeId = _bits[(index + 3)..(index + 6)];
                Packet packet;

                var operators = new Dictionary<string, Func<string, Packet>>
                {
                    { "000", x => new SumOperatorPacket(x) },
                    { "001", x => new ProductOperatorPacket(x) },
                    { "010", x => new MinimumOperatorPacket(x) },
                    { "011", x => new MaximumOperatorPacket(x) },
                    { "100", x => new LiteralPacket(x) },
                    { "101", x => new GreaterThanOperatorPacket(x) },
                    { "110", x => new LessThaOperatorPacket(x) }
                };

                if (operators.ContainsKey(typeId))
                {
                    packet = operators[typeId](_bits[index..]);
                    index += packet.Consumed;
                    Packets.Add(packet);
                }
                else
                {
                    packet = new OperatorPacket(_bits[index..]);
                    index += packet.Consumed;
                    Packets.Add(packet);
                }

                Consumed = index;
            }
        }
    }
}