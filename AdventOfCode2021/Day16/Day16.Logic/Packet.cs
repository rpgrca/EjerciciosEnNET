namespace Day16.Logic
{
    public abstract class Packet
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

        public abstract int GetVersionSum();

        public virtual long Value { get; }
    }
}