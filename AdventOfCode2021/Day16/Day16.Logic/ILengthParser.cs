using System.Collections.Generic;

namespace Day16.Logic
{
    internal interface ILengthParser
    {
        int Consumed { get; }
        List<Packet> ParsedPackets { get; }
        int SubPacketsLengthInBits { get; }
    }
}