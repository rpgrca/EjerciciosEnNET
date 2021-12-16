using System;
using System.Collections.Generic;

namespace Day16.Logic
{
    public static class PacketFactory
    {
        private static readonly Dictionary<string, Func<string, Packet>> _operators = new()
        {
            { "000", x => new SumOperatorPacket(x) },
            { "001", x => new ProductOperatorPacket(x) },
            { "010", x => new MinimumOperatorPacket(x) },
            { "011", x => new MaximumOperatorPacket(x) },
            { "100", x => new LiteralPacket(x) },
            { "101", x => new GreaterThanOperatorPacket(x) },
            { "110", x => new LessThaOperatorPacket(x) },
            { "111", x => new EqualThanOperatorPacket(x) }
        };

        public static Packet Create(string bits) =>
            _operators[bits[3..6]](bits[0..]);
    }
}