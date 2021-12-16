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
                switch (typeId)
                {
                    case "100":
                        packet = new LiteralPacket(_bits[index..]);
                        index += packet.Consumed;

                        Packets.Add(packet);
                        break;

                    default:
                        packet = new OperatorPacket(_bits[index..]);
                        index += packet.Consumed;

                        Packets.Add(packet);
                        break;
                }

                Consumed = index;
            }
        }
    }
}