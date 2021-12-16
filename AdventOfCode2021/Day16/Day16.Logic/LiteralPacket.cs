using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16.Logic
{
    public class LiteralPacket : Packet
    {
        private string _bits;
        private readonly bool _padWithIgnored;

        public List<string> Groups { get; }
        public int Value { get; private set; }

        public LiteralPacket(string bits) : base(bits)
        {
            _bits = bits;
            Groups = new List<string>();

            Parse();
        }

        private void Parse()
        {
            while (_bits[Consumed] == '1')
            {
                Groups.Add(_bits[Consumed..(Consumed + 5)]);
                Consumed += 5;
            }

            Groups.Add(_bits[Consumed..(Consumed + 5)]);
            Consumed += 5;

            _bits = _bits[6..Consumed];

            CalculateValue();
        }

        private void CalculateValue()
        {
            Value = Convert.ToInt32(Groups.Select(p => p[1..]).Aggregate(string.Empty, (t, i) => t += i), 2);
        }
    }
}