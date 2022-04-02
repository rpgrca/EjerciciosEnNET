using System;

namespace Day16.Logic
{
    internal static class LengthParserFactory
    {
        private static readonly Func<string, LengthParser>[] _parsers =
        {
            b => new LengthInBitParser(b),
            b => new LengthInPacketParser(b)
        };

        public static LengthParser Create(int type, string bits) => _parsers[type](bits);
    }
}