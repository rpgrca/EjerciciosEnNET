namespace Day16.Logic
{
    public class Parser
    {
        private readonly string _bits;

        public Packet ParsedPacket { get; private set; }
        public int Consumed { get; private set; }

        public Parser(string bits)
        {
            _bits = bits;
            Parse();
        }

        private void Parse()
        {
            ParsedPacket = PacketFactory.Create(_bits);
            Consumed = ParsedPacket.Consumed;
        }
    }
}