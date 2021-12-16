using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16.Logic
{
    public class Packet
    {
        public string Version { get; }
        public string TypeId { get; }
        public int Consumed { get; protected set; }

        protected Packet(string bits)
        {
            Version = bits[0..3];
            TypeId = bits[3..6];

            Consumed = 6;
        }
    }

    public class LiteralPacket : Packet
    {
        private string _bits;

        public List<string> Groups { get; }
        public int Value { get; private set; }
        public string Ignored { get; private set; }

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

            var padding = Consumed % 4;
            if (padding != 0)
            {
                Ignored = _bits[Consumed..(Consumed + padding)];
                Consumed += padding;
            }

            _bits = _bits[6..Consumed];

            CalculateValue();
        }

        private void CalculateValue()
        {
            Value = Convert.ToInt32(Groups.Select(p => p[1..]).Aggregate(string.Empty, (t, i) => t += i), 2);
        }
    }

    public class OperatorPacket : Packet
    {
        public OperatorPacket(string bits) : base(bits)
        {
        }
    }
}