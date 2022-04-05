namespace Day16.Logic
{
    public class Parser
    {
        private readonly string _bits;

        public Packet ParsedPacket { get; }
        public int Consumed { get; }

        public Parser(string bits)
        {
            _bits = bits;

            ParsedPacket = PacketFactory.Create(_bits);
            Consumed = ParsedPacket.Consumed;
        }
    }
}