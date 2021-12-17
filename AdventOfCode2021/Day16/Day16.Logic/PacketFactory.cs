using System;

namespace Day16.Logic
{
    public static class PacketFactory
    {
        private static readonly Func<string, Packet>[] _operators =
        {
            x => new SumOperatorPacket(x),
            x => new ProductOperatorPacket(x),
            x => new MinimumOperatorPacket(x),
            x => new MaximumOperatorPacket(x),
            x => new LiteralPacket(x),
            x => new GreaterThanOperatorPacket(x),
            x => new LessThaOperatorPacket(x),
            x => new EqualThanOperatorPacket(x)
        };

        public static Packet Create(string bits) =>
            _operators[Convert.ToInt32(bits[3..6], 2)](bits[0..]);
    }
}