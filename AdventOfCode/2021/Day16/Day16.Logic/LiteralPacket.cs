using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16.Logic
{
    public class LiteralPacket : Packet
    {
        private string _bits;

        public List<string> Groups { get; }

        public LiteralPacket(string bits) : base(bits)
        {
            _bits = bits;
            Groups = new List<string>();

            Parse();
        }

        private void Parse()
        {
            ParseGroupsOfFiveBitsUntilPrefixIsZero();
            UpdateBitsWithConsumedOnes();
            CalculateValue();
        }

        private void ParseGroupsOfFiveBitsUntilPrefixIsZero()
        {
            do
            {
                Groups.Add(_bits[Consumed..(Consumed + 5)]);
                Consumed += 5;
            }
            while (Groups.Last()[0] != '0');
        }

        private void UpdateBitsWithConsumedOnes() =>
            _bits = _bits[6..Consumed];

        private void CalculateValue() =>
            Value = Convert.ToInt64(Groups.Select(p => p[1..]).Aggregate(string.Empty, (t, i) => t += i), 2);

        public override void Accept(VersionSumVisitor visitor) =>
            visitor.Visit(this);
    }
}