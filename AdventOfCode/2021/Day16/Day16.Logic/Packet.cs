using System;

namespace Day16.Logic
{
    public abstract class Packet : IVisitable
    {
        public int Version { get; }
        public int TypeId { get; }
        public int Consumed { get; protected set; }
        public long Value { get; protected set; }

        protected Packet(string bits)
        {
            Version = Convert.ToInt32(bits[0..3], 2);
            TypeId = Convert.ToInt32(bits[3..6], 2);

            Consumed = 6;
        }

        public abstract void Accept(VersionSumVisitor visitor);
    }
}